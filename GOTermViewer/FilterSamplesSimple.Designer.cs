
namespace GOTermViewer
{
    partial class FilterSamplesSimple
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilterSamplesSimple));
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboSignificant = new System.Windows.Forms.ComboBox();
            this.btnSignificantRemove = new System.Windows.Forms.Button();
            this.cboSamples = new System.Windows.Forms.ComboBox();
            this.btnSignificantAdd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label4);
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.cboSignificant);
            this.groupBox6.Controls.Add(this.btnSignificantRemove);
            this.groupBox6.Controls.Add(this.cboSamples);
            this.groupBox6.Controls.Add(this.btnSignificantAdd);
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Location = new System.Drawing.Point(12, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(776, 150);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Most be significant";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(253, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Term most be significantly enriched in these samples";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(406, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select the file below, then add to \'Significant\' filter sets by pressing the \'Sel" +
    "ect\' button";
            // 
            // cboSignificant
            // 
            this.cboSignificant.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSignificant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSignificant.FormattingEnabled = true;
            this.cboSignificant.Location = new System.Drawing.Point(9, 91);
            this.cboSignificant.Name = "cboSignificant";
            this.cboSignificant.Size = new System.Drawing.Size(761, 21);
            this.cboSignificant.TabIndex = 6;
            // 
            // btnSignificantRemove
            // 
            this.btnSignificantRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSignificantRemove.Enabled = false;
            this.btnSignificantRemove.Location = new System.Drawing.Point(695, 118);
            this.btnSignificantRemove.Name = "btnSignificantRemove";
            this.btnSignificantRemove.Size = new System.Drawing.Size(75, 23);
            this.btnSignificantRemove.TabIndex = 7;
            this.btnSignificantRemove.Text = "Remove";
            this.btnSignificantRemove.UseVisualStyleBackColor = true;
            this.btnSignificantRemove.Click += new System.EventHandler(this.btnSignificantRemove_Click);
            // 
            // cboSamples
            // 
            this.cboSamples.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSamples.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSamples.FormattingEnabled = true;
            this.cboSamples.Location = new System.Drawing.Point(9, 32);
            this.cboSamples.Name = "cboSamples";
            this.cboSamples.Size = new System.Drawing.Size(761, 21);
            this.cboSamples.TabIndex = 3;
            // 
            // btnSignificantAdd
            // 
            this.btnSignificantAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSignificantAdd.Location = new System.Drawing.Point(695, 62);
            this.btnSignificantAdd.Name = "btnSignificantAdd";
            this.btnSignificantAdd.Size = new System.Drawing.Size(75, 23);
            this.btnSignificantAdd.TabIndex = 5;
            this.btnSignificantAdd.Text = "Select";
            this.btnSignificantAdd.UseVisualStyleBackColor = true;
            this.btnSignificantAdd.Click += new System.EventHandler(this.btnSignificantAdd_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "To remove from set press \'remove\'";
            // 
            // btnAccept
            // 
            this.btnAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAccept.Location = new System.Drawing.Point(632, 168);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 8;
            this.btnAccept.Text = "Ok";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(713, 168);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FilterSamplesSimple
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 206);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FilterSamplesSimple";
            this.Text = "Go term filtering";
            this.Load += new System.EventHandler(this.FilterSamplesSimple_Load);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboSamples;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboSignificant;
        private System.Windows.Forms.Button btnSignificantRemove;
        private System.Windows.Forms.Button btnSignificantAdd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
    }
}