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
    public partial class FilterSamplesSimple : Form
    {
        private List<string> significant = null;
        private readonly List<string> samples = null;

        public FilterSamplesSimple(List<string> Samples)
        {
            InitializeComponent();
            samples = Samples;
            cboSamples.Items.AddRange(samples.ToArray());
            cboSamples.SelectedIndex = 0;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSignificantAdd_Click(object sender, EventArgs e)
        {
            string sample = cboSamples.Text;
            if (cboSignificant.Items.Contains(sample) == false)
            {
                cboSignificant.Items.Add(sample);
                cboSignificant.SelectedIndex = 0;
                if (cboSignificant.Items.Count > 0)
                { btnSignificantRemove.Enabled = true; }
            }
            MakeSignificantList();
        }

        private void btnSignificantRemove_Click(object sender, EventArgs e)
        {
            cboSignificant.Items.RemoveAt(cboSignificant.SelectedIndex);
            if (cboSignificant.Items.Count > 0)
            {
                cboSignificant.SelectedIndex = 0;
                btnSignificantRemove.Enabled = true;
            }
            else { btnSignificantRemove.Enabled = false; }

            MakeSignificantList();
        }

        private void MakeSignificantList()
        {
            significant = new List<string>();
            for (int index = 0; index < cboSignificant.Items.Count; index++)
            { significant.Add(cboSignificant.Items[index].ToString()); }
        }

        public List<string> SignificantSampleList
        { get { return significant; } }

        private void FilterSamplesSimple_Load(object sender, EventArgs e)
        {

        }
    }
}
