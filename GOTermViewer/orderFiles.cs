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
    public partial class orderFiles : Form
    {
        List<string> samples = null;
        Dictionary<string, string> newName = new Dictionary<string, string>();

        public orderFiles(List<string> files, Dictionary<string, string> editedNames)
        {
            InitializeComponent();

            cboCurrentList.Items.AddRange(files.ToArray());
            newName = new Dictionary<string, string>();
            foreach (string k in editedNames.Keys)
            {
                newName.Add(k, editedNames[k]);
            }
        }

        private void orderFiles_Load(object sender, EventArgs e)
        {
            cboCurrentList.SelectedIndex = 0;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (cboCurrentList.Items.Count == 0) { return; }

            cboNewList.Items.Add(cboCurrentList.SelectedItem);

            cboCurrentList.Items.RemoveAt(cboCurrentList.SelectedIndex);
            if (cboCurrentList.Items.Count == 0)
            { btnSelect.Enabled = false; }
            else
            { cboCurrentList.SelectedIndex = 0; }

            if (cboNewList.Items.Count > 0)
            {
                btnRemove.Enabled = true;
                txtNewName.Enabled = true;
                cboNewList.SelectedIndex = cboNewList.Items.Count - 1;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (cboNewList.Items.Count == 0) { return; }

            cboCurrentList.Items.Add(cboNewList.SelectedItem);
            cboNewList.Items.RemoveAt(cboNewList.SelectedIndex);
            if (cboNewList.Items.Count == 0)
            { btnRemove.Enabled = false; }
            else { cboNewList.SelectedIndex = 0; }

            if (cboCurrentList.Items.Count > 0)
            { btnSelect.Enabled = true; }

            if (cboCurrentList.Items.Count > 0)
            {
                btnRemove.Enabled = true;
                cboCurrentList.SelectedIndex = 0;
                txtNewName.Enabled = true;
            }

            if (cboNewList.Items.Count == 0)
            {
                cboNewList.Text = "";
                txtNewName.Enabled = false;
                txtNewName.Text = "";
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            samples = new List<string>();
            for (int index = 0; index < cboNewList.Items.Count; index++)
            {
                samples.Add(cboNewList.Items[index].ToString());
            }
            Close();
        }

        public List<string> FileList
        { get { return samples; } }

        public Dictionary<string, string> getEditedNames
        { get { return newName; } }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cboNewList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (newName.ContainsKey(cboNewList.Text) == true)
            { txtNewName.Text = newName[cboNewList.Text]; }
            else
            { txtNewName.Text = cboNewList.Text; }
        }

        private void txtNewName_TextChanged(object sender, EventArgs e)
        {
            string name = txtNewName.Text.Trim();
            if (string.IsNullOrEmpty(name) == false)
            { newName[cboNewList.Text] = name; }
            else
            { newName[cboNewList.Text] = cboNewList.Text; }
        }
    }
}