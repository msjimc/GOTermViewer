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
    public partial class FindGOTerm : Form
    {
        private Dictionary<string, term> terms;
        private List<string> names;
        private term root;
        private List<string> selectedAnswers;

        private bool filterNow = false;
        public FindGOTerm(Dictionary<string, term> Terms, term Root)
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

        private void FindGOTerm_Load(object sender, EventArgs e)
        {

        }

        private void txtTerm_TextChanged(object sender, EventArgs e)
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

        private void cboTerms_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterNow = false;
            tFilter.Enabled = true;
        }

        private void txtLimit_TextChanged(object sender, EventArgs e)
        {
            tFilter.Interval = 250;
            filterNow = false;
            tFilter.Enabled = true;
        }

        private void filterPhrases()
        {
            string[] items = txtLimit.Text.Trim().Split(';');

            cblAnswers.Items.Clear();
            string target = cboTerms.Text.Replace(" (NO DATA)", "");
            if (string.IsNullOrEmpty(target) == true) { return; }
            List<string> answer = new List<string>();

            answer = getPaths(root, root.Name, answer, target);
            List<string> filteredAnswer = new List<string>();
            foreach (string phrase in answer)
            {
                bool add = true;
                for (int index = 0; index < items.Length; index++)
                {
                    if (items[index].Trim().StartsWith("NOT ") == false)
                    {
                        if (phrase.ToLower().Contains(items[index].ToLower()) == false)
                        {
                            add = false;
                            index = items.Length;
                        }
                    }
                    else
                    {
                        string clean = items[index].Trim().Substring(4).Trim();
                        if (phrase.ToLower().Contains(clean.ToLower()) == true)
                        {
                            add = false;
                            index = items.Length;
                        }
                    }
                }
                if (add == true) { filteredAnswer.Add(phrase); }
            }

            filteredAnswer.Sort();

            cblAnswers.Items.AddRange(filteredAnswer.ToArray());
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

        private void btnAccept_Click(object sender, EventArgs e)
        {
            selectedAnswers = new List<string>();
            foreach (string s in cblAnswers.CheckedItems)
            {
                selectedAnswers.Add(s);
            }

        }

        public List<string> GetSelectedAnswers
        { get { return selectedAnswers; } }

        private void tFilter_Tick(object sender, EventArgs e)
        {
            if (filterNow == false)
            { filterNow = true; }
            else
            {
                filterNow = false;
                tFilter.Enabled = false;
                filterPhrases();
            }
        }
    }
}