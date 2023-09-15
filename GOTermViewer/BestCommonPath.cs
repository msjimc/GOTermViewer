using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GOTermViewer
{
    public partial class BestCommonPath : Form
    {
        private Dictionary<string, term> terms = null;
        private List<string> names = null;
        private term root = null;
        private List<string> selectedAnswers;
        private bool typing = false;
        public BestCommonPath(Dictionary<string, term> Terms, term Root)
        {
            InitializeComponent();

            terms = Terms;
            names = new List<string>();
            root = Root;
            foreach (term t in terms.Values)
            {
                if (t.getDataCount > 0)
                { names.Add(t.Name); }
                else
                { names.Add(t.Name + " (NO DATA)"); }
            }

            names.Sort();
        }

        private void BestCommonPath_Load(object sender, EventArgs e)
        {

        }

        private void txtTerm_TextChanged(object sender, EventArgs e)
        {
            typing = true;
            tTextChanged.Enabled = true;
        }

        private void UpdateList()
        {
            cblAnswers.Items.Clear();
            cboTerms.Items.Clear();
            cboTerms.Text = "";
            if (txtTerm.Text.Trim().Length >= 3)
            {
                string query = txtTerm.Text.ToLower().Trim();
                string[] items = query.Split(';');
                string queryStart = items[0].Trim();

                foreach (string name in names)
                {
                    if (name.ToLower().Contains(queryStart) == true)
                    { cboTerms.Items.Add(name); }
                }
            }
            if (cboTerms.Items.Count > 0)
            { cboTerms.SelectedIndex = 0; }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cboTerms.SelectedIndex > -1)
            {
                string name = cboTerms.Text.Replace(" (NO DATA)", "");
                if (cboSelectedTerms.Items.Contains(name) == false)
                {
                    cboSelectedTerms.Items.Add(name);
                    cboSelectedTerms.SelectedIndex = 0;
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (cboSelectedTerms.Items.Count > 0)
            {
                cboSelectedTerms.Items.Remove(cboSelectedTerms.Text);
                if (cboSelectedTerms.Items.Count > 0)
                { cboSelectedTerms.SelectedIndex = 0; }
                else
                { cboSelectedTerms.Text = ""; }
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {

            if (cboSelectedTerms.Items.Count == 0) { return; }

            btnAccept.Enabled = false;
            cblAnswers.Items.Clear();
            int count = int.MaxValue;
            List<string[]> smallest = null;

            Dictionary<string, List<string[]>> TermPaths = new Dictionary<string, List<string[]>>();
            for (int index = 0; index < cboSelectedTerms.Items.Count; index++)
            {
                string target = cboSelectedTerms.Items[index].ToString();
                List<string> answer = new List<string>();
                answer = getPathsList(root, root.Name, answer, target);
                answer.Sort();

                List<string[]> answerArray = new List<string[]>();

                foreach (string s in answer)
                {
                    string[] items = s.Split('\t');
                    answerArray.Add(items);
                }

                if (answerArray.Count < count)
                {
                    count = answerArray.Count;
                    smallest = answerArray;
                }
                TermPaths.Add(target, answerArray);
            }

            List<string> allTerms = GetAllTerms(smallest);

            getBestPaths(allTerms, TermPaths);

        }

        private void getBestPaths(List<string> allTerms, Dictionary<string, List<string[]>> TermPaths)
        {
            int bestScore = int.MaxValue;
            List<string> commonTerm = new List<string>();
            int score = 0;
            foreach (string term in allTerms)
            {
                foreach (List<string[]> paths in TermPaths.Values)
                {
                    int localScore = 1000;
                    foreach (string[] path in paths)
                    {
                        for (int index = 0; index < path.Length; index++)
                        {
                            if (term.Equals(path[index]) == true)
                            {
                                if (index < localScore)
                                { localScore = index; }
                                index = path.Length;
                            }
                        }
                    }
                    score += localScore;
                }
                if (bestScore > score)
                {
                    bestScore = score;
                    commonTerm = new List<string>();
                    commonTerm.Add(term);
                }
                else if (bestScore == score)
                { commonTerm.Add(term); }
                score = 0;
            }

            if (bestScore < 1000)
            {
                List<string> answers = new List<string>();
                foreach (string aTerm in commonTerm)
                {
                    List<string> answer = new List<string>();
                    answer = getPaths(root, root.Name, answer, aTerm);
                    answers.AddRange(answer);
                }
                answers.Sort();
                cblAnswers.Items.AddRange(answers.ToArray());
            }

        }

        private List<string> GetAllTerms(List<string[]> paths)
        {
            List<string> answer = new List<string>();
            foreach (string[] path in paths)
            {
                foreach (string item in path)
                {
                    if (answer.Contains(item) == false)
                    { answer.Add(item); }
                }
            }

            answer.Sort();
            return answer;
        }

        private List<string> getPaths(term t, string thisAnswer, List<string> answers, string target)
        {
            foreach (term c in t.Children)
            {
                if (c.Name.Equals(target) == true)
                {
                    answers.Add(target + " <- " + thisAnswer);
                }
                else
                {
                    answers = getPaths(c, c.Name + " <- " + thisAnswer, answers, target);
                }
            }

            return answers;
        }

        private List<string> getPathsList(term t, string thisAnswer, List<string> answers, string target)
        {
            foreach (term c in t.Children)
            {
                if (c.Name.Equals(target) == true)
                {
                    answers.Add(target + "\t" + thisAnswer);
                }
                else
                {
                    answers = getPathsList(c, c.Name + "\t" + thisAnswer, answers, target);
                }
            }
            return answers;
        }

        public List<string> GetSelectedAnswers
        { get { return selectedAnswers; } }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            selectedAnswers = new List<string>();
            foreach (string s in cblAnswers.CheckedItems)
            {
                selectedAnswers.Add(s);
            }
        }

        private void cblAnswers_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            btnAccept.Enabled = true;
        }

        private void tTextChanged_Tick(object sender, EventArgs e)
        {
            if (typing == true)
            { typing = false; }
            else
            {
                tTextChanged.Enabled = false;
                UpdateList();
            }
        }
    }
}