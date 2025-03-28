using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace GOTermViewer
{
    public class term
    {
        public enum relationship { is_a, part_of, has_part, occurs_in, happens_during, ends_during, regulates, negatively_regulates, positively_regulates, not_set, is_obsolete };
        public enum space { molecular_function, biological_process, cellular_component }

        private string name = "";
        private string description;
        private space set;
        private string id;
        private string comment;
        private List<string> links;
        private List<term> children;
        private Dictionary<string, termData> values = new Dictionary<string, termData>();
        private bool hasDataInTree = false;
        private bool nodeSelected = false;
        private bool childSelected = false;
        private int significantHits = 0;
        private bool passedFilterIntree = false;
        private bool passedFilter = false;
        private bool hide = false;

        public term()
        {
            links = new List<string>();
            children = new List<term>();
        }

        public term(Dictionary<string, string> data, List<string> Relationship)
        {
            links = Relationship;

            if (data.ContainsKey("name") == true)
            {
                name = data["name"].Substring(6);

                if (char.IsLower(name[0]) == true)
                {
                    bool hasCapital = false;
                    int space = name.IndexOf(" ");
                    if (space == -1 || space > 4) { space = 4; }

                    for (int index = 1; index < space; index++)
                    {
                        if (char.IsUpper(name[index]) == true)
                        {
                            hasCapital = true;
                            break;
                        }
                    }
                    if (hasCapital == false)
                    { name = name.Substring(0, 1).ToUpper() + name.Substring(1); }
                }
            }

            if (data.ContainsKey("namespace") == true)
            {
                switch (data["namespace"].Substring(11))
                {
                    case "molecular_function":
                        set = space.molecular_function;
                        break;
                    case "biological_process":
                        set = space.biological_process;
                        break;
                    case "cellular_component":
                        set = space.cellular_component;
                        break;
                }
            }
            if (data.ContainsKey("id") == true)
            { id = data["id"].Substring(4); }
            if (data.ContainsKey("def") == true)
            { description = data["def"].Substring(5); }
            if (data.ContainsKey("comment") == true)
            { comment = data["comment"].Substring(9); }

            children = new List<term>();

            string goID = "";
            foreach (string line in Relationship)
            {
                if (line.StartsWith("is_obsolete") == true) { goID = "is_obsolete"; }
                else if (line.StartsWith("positively_regulates") == true) { goID = getTerm(line); }
                else if (line.StartsWith("negatively_regulates") == true) { goID = getTerm(line); }
                else if (line.StartsWith("regulates") == true) { goID = getTerm(line); }
                else if (line.StartsWith("ends_during") == true) { goID = getTerm(line); }
                else if (line.StartsWith("happens_during") == true) { goID = getTerm(line); }
                else if (line.StartsWith("occurs_in") == true) { goID = getTerm(line); }
                else if (line.StartsWith("has_part") == true) { goID = getTerm(line); }
                else if (line.StartsWith("part_of") == true) { goID = getTerm(line); }
                else if (line.StartsWith("is_a") == true) { goID = getTerm(line); }
            }

        }

        private string getTerm(string line)
        {
            string answer = "";
            int indexColon = line.IndexOf(":") + 2;
            int indexExclaimation = line.IndexOf("!") - 1;
            answer = line.Substring(indexColon, indexExclaimation - indexColon);
            return answer;
        }

        public void AddAChild(term child)
        { children.Add(child); }

        public void addDataRow(string data, string fileName, double cutOff)
        {
            termData td = new termData(data, fileName);
            if (td.IsGood == true)
            {
                if (values.ContainsKey(fileName) == false)
                {
                    values.Add(fileName, td);
                    if (td.GetPValue <= cutOff)
                    {
                        hasDataInTree = true;
                        significantHits++;
                    }
                }
                else
                {
                    if (td.GetPValue < values[fileName].GetPValue)
                    {
                        if (values[fileName].GetPValue > cutOff && td.GetPValue <= cutOff)
                        {
                            hasDataInTree = true;
                            significantHits++;
                        }
                        values[fileName] = td;
                    }
                }
            }
        }

        public termData getAdataRow(string fileName)
        {
            if (values.ContainsKey(fileName) == true)
            { return values[fileName]; }
            else { return null; }
        }

        public bool HaveChildrenGotData(Dictionary<string, term> terms)
        {
            foreach (term c in children)
            {
                if (c.HaveChildrenGotData(terms) == true)
                { hasDataInTree = true; }
            }
            return hasDataInTree;
        }

        public bool HaveChildrenGotFilteredData(Dictionary<string, term> terms)
        {
            foreach (term c in children)
            {
                if (c.HaveChildrenGotFilteredData(terms) == true)
                { passedFilterIntree = true; }
            }
            return passedFilterIntree;
        }

        public bool AreChildrenSelected(Dictionary<string, term> terms)
        {
            foreach (term c in children)
            {
                if (c.AreChildrenSelected(terms) == true)
                { childSelected = true; }
            }
            if (childSelected == false && significantHits > 0 && nodeSelected == true)
            { childSelected = true; }
            return childSelected;
        }

        public void removeFilter()
        {
            passedFilterIntree = true;
            passedFilter = true;
        }

        public void Filter(List<string> Significant, double cutOff)
        {
            passedFilterIntree = false;
            passedFilter = false;
            if (values.Count > 0)
            {
                foreach (string key in Significant)
                {
                    if (values.ContainsKey(key) == false || values[key].GetPValue > cutOff)
                    {
                        passedFilterIntree = false;
                        passedFilter = false;
                        return;
                    }
                }
                passedFilterIntree = true;
                passedFilter = true;
            }
        }

        public void Hide_Unhide()
        {
            hide = !hide;
        }

        public bool Hidden
        { get { return hide; } }

        public void Draw(Graphics g, int top, Rectangle[] regions, List<string> samples, double cutOff, int drawThese, bool justValues, StringBuilder sb)
        {
            if (justValues == false)
            {
                Pen dots = new Pen(Color.Black, 0.5f);
                float[] dashes = { 1, 15 };
                dots.DashPattern = dashes;

                for (int index = 0; index < regions.Length; index++)
                {
                    g.DrawLine(dots, regions[index].Left, top + 10, regions[index].Right, top + 10);
                }
            }

            for (int index = 0; index < samples.Count; index++)
            {
                if (values.ContainsKey(samples[index]) == true)
                {
                    termData td = values[samples[index]];
                    td.DrawData(g, regions[index], top, cutOff, drawThese, justValues, sb);
                }
                else if (sb != null)
                { sb.Append("\t-\t-\t-\t-"); }
            }
        }

        public bool HasDataInTree
        {
            set { hasDataInTree = value; }
            get { return hasDataInTree; }
        }

        public bool HasFilteredDataInTree
        {
            set { passedFilterIntree = value; }
            get { return passedFilterIntree; }
        }

        public bool HasFilteredData
        { get { return passedFilter; } }

        public bool WasNodeSelected
        {
            set { nodeSelected = value; }
            get { return nodeSelected; }
        }

        public int getDataCount { get { return significantHits; } }
        public List<term> Children { get { return children; } }
        public string Name { get { return name; } }
        public string Description { get { return description; } }

        public string DescriptionToolTip()
        {
            string answer = "";
            string[] items = description.Split(' ');
            int length = 0;
            for (int index = 0; index < items.Length; index++)
            {
                if (length + (" " + items[index]).Length > 70)
                {
                    answer += "\n" + items[index];
                    length = items[index].Length;
                }
                else
                {
                    answer += " " + items[index];
                    length += items[index].Length;
                }

            }
            return answer;
        }
        public space Set { get { return set; } }
        public List<string> Relationships
        {
            get { return links; }
            set { links = value; }
        }
        public string ID { get { return id; } }

        public override string ToString()
        {
            return name;
        }

    }
}