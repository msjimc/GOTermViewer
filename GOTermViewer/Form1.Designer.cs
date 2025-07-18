﻿
namespace GOTermViewer
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnGOTerms = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tv = new System.Windows.Forms.TreeView();
            this.cmFind = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.findGOTermToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findCommonPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.moveTermUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveTermDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.hideunhideTermsDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDataFolder = new System.Windows.Forms.Button();
            this.chkLimit = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnImportGOList = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSignificant = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.nupLabelWidth = new System.Windows.Forms.NumericUpDown();
            this.tScrollReDraw = new System.Windows.Forms.Timer(this.components);
            this.tTVclick = new System.Windows.Forms.Timer(this.components);
            this.gbTreeview = new System.Windows.Forms.GroupBox();
            this.gbOptions = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnExportSelectedGOTerms = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.gbDisplayOption = new System.Windows.Forms.GroupBox();
            this.rdoBoth = new System.Windows.Forms.RadioButton();
            this.rdoOdds = new System.Windows.Forms.RadioButton();
            this.rdoFoldDiff = new System.Windows.Forms.RadioButton();
            this.btnOrder = new System.Windows.Forms.Button();
            this.chkDEG = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkOdds = new System.Windows.Forms.CheckBox();
            this.chkHighlightData = new System.Windows.Forms.CheckBox();
            this.chkNames = new System.Windows.Forms.CheckBox();
            this.chkJustLabelsWithData = new System.Windows.Forms.CheckBox();
            this.chkEndent = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.rdoFilteredData = new System.Windows.Forms.RadioButton();
            this.rdoAllData = new System.Windows.Forms.RadioButton();
            this.label11 = new System.Windows.Forms.Label();
            this.btnFilter = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.rdoCC = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.rdoMF = new System.Windows.Forms.RadioButton();
            this.rdoBP = new System.Windows.Forms.RadioButton();
            this.gbTreeViewOptions = new System.Windows.Forms.GroupBox();
            this.chkToolTips = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tTitle = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nupSaveWidth = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cmFind.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupLabelWidth)).BeginInit();
            this.gbTreeview.SuspendLayout();
            this.gbOptions.SuspendLayout();
            this.gbDisplayOption.SuspendLayout();
            this.gbTreeViewOptions.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupSaveWidth)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGOTerms
            // 
            this.btnGOTerms.Location = new System.Drawing.Point(203, 11);
            this.btnGOTerms.Margin = new System.Windows.Forms.Padding(2);
            this.btnGOTerms.Name = "btnGOTerms";
            this.btnGOTerms.Size = new System.Drawing.Size(75, 23);
            this.btnGOTerms.TabIndex = 3;
            this.btnGOTerms.Text = "Select";
            this.btnGOTerms.UseVisualStyleBackColor = true;
            this.btnGOTerms.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Open GO.obo file";
            // 
            // tv
            // 
            this.tv.CheckBoxes = true;
            this.tv.ContextMenuStrip = this.cmFind;
            this.tv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv.Location = new System.Drawing.Point(3, 16);
            this.tv.Name = "tv";
            this.tv.ShowNodeToolTips = true;
            this.tv.Size = new System.Drawing.Size(451, 685);
            this.tv.TabIndex = 46;
            this.tv.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.tv_BeforeCheck);
            this.tv.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.Tv_AfterCheck);
            this.tv.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.Tv_BeforeExpand);
            this.tv.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tv_MouseUp);
            // 
            // cmFind
            // 
            this.cmFind.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.cmFind.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findGOTermToolStripMenuItem,
            this.findCommonPathToolStripMenuItem,
            this.toolStripMenuItem1,
            this.moveTermUpToolStripMenuItem,
            this.moveTermDownToolStripMenuItem,
            this.toolStripMenuItem2,
            this.hideunhideTermsDataToolStripMenuItem});
            this.cmFind.Name = "cmFind";
            this.cmFind.Size = new System.Drawing.Size(204, 126);
            // 
            // findGOTermToolStripMenuItem
            // 
            this.findGOTermToolStripMenuItem.Name = "findGOTermToolStripMenuItem";
            this.findGOTermToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.findGOTermToolStripMenuItem.Text = "Find GO term";
            this.findGOTermToolStripMenuItem.Click += new System.EventHandler(this.findGOTermToolStripMenuItem_Click);
            // 
            // findCommonPathToolStripMenuItem
            // 
            this.findCommonPathToolStripMenuItem.Name = "findCommonPathToolStripMenuItem";
            this.findCommonPathToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.findCommonPathToolStripMenuItem.Text = "Find common path";
            this.findCommonPathToolStripMenuItem.Click += new System.EventHandler(this.findCommonPathToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(200, 6);
            // 
            // moveTermUpToolStripMenuItem
            // 
            this.moveTermUpToolStripMenuItem.Name = "moveTermUpToolStripMenuItem";
            this.moveTermUpToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.moveTermUpToolStripMenuItem.Text = "Move term up";
            this.moveTermUpToolStripMenuItem.Click += new System.EventHandler(this.moveTermUpToolStripMenuItem_Click);
            // 
            // moveTermDownToolStripMenuItem
            // 
            this.moveTermDownToolStripMenuItem.Name = "moveTermDownToolStripMenuItem";
            this.moveTermDownToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.moveTermDownToolStripMenuItem.Text = "Move term down";
            this.moveTermDownToolStripMenuItem.Click += new System.EventHandler(this.moveTermDownToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(200, 6);
            // 
            // hideunhideTermsDataToolStripMenuItem
            // 
            this.hideunhideTermsDataToolStripMenuItem.Name = "hideunhideTermsDataToolStripMenuItem";
            this.hideunhideTermsDataToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.hideunhideTermsDataToolStripMenuItem.Text = "Hide/Unhide Terms data";
            this.hideunhideTermsDataToolStripMenuItem.Click += new System.EventHandler(this.hideUnhideTermsDataToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 43);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Add significant terms";
            // 
            // btnDataFolder
            // 
            this.btnDataFolder.Enabled = false;
            this.btnDataFolder.Location = new System.Drawing.Point(203, 38);
            this.btnDataFolder.Margin = new System.Windows.Forms.Padding(2);
            this.btnDataFolder.Name = "btnDataFolder";
            this.btnDataFolder.Size = new System.Drawing.Size(75, 23);
            this.btnDataFolder.TabIndex = 5;
            this.btnDataFolder.Text = "Select";
            this.btnDataFolder.UseVisualStyleBackColor = true;
            this.btnDataFolder.Click += new System.EventHandler(this.button2_Click);
            // 
            // chkLimit
            // 
            this.chkLimit.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkLimit.Checked = true;
            this.chkLimit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLimit.Location = new System.Drawing.Point(8, 83);
            this.chkLimit.Margin = new System.Windows.Forms.Padding(2);
            this.chkLimit.Name = "chkLimit";
            this.chkLimit.Size = new System.Drawing.Size(270, 18);
            this.chkLimit.TabIndex = 15;
            this.chkLimit.Text = "Only show terms with data in them or their children";
            this.chkLimit.UseVisualStyleBackColor = true;
            this.chkLimit.CheckedChanged += new System.EventHandler(this.ChkLimit_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Import list of GO terms";
            // 
            // btnImportGOList
            // 
            this.btnImportGOList.Enabled = false;
            this.btnImportGOList.Location = new System.Drawing.Point(203, 66);
            this.btnImportGOList.Name = "btnImportGOList";
            this.btnImportGOList.Size = new System.Drawing.Size(75, 23);
            this.btnImportGOList.TabIndex = 7;
            this.btnImportGOList.Text = "Import";
            this.btnImportGOList.UseVisualStyleBackColor = true;
            this.btnImportGOList.Click += new System.EventHandler(this.ImportGOTerms_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "Significance cutoff";
            // 
            // txtSignificant
            // 
            this.txtSignificant.Location = new System.Drawing.Point(203, 16);
            this.txtSignificant.Name = "txtSignificant";
            this.txtSignificant.Size = new System.Drawing.Size(75, 20);
            this.txtSignificant.TabIndex = 33;
            this.txtSignificant.Text = "0.05";
            this.txtSignificant.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSignificant.TextChanged += new System.EventHandler(this.TxtSignificant_TextChanged);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(203, 15);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 42;
            this.button5.Text = "Save";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 150);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Change width of label area";
            // 
            // nupLabelWidth
            // 
            this.nupLabelWidth.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nupLabelWidth.Location = new System.Drawing.Point(206, 148);
            this.nupLabelWidth.Margin = new System.Windows.Forms.Padding(2);
            this.nupLabelWidth.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nupLabelWidth.Minimum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.nupLabelWidth.Name = "nupLabelWidth";
            this.nupLabelWidth.Size = new System.Drawing.Size(72, 20);
            this.nupLabelWidth.TabIndex = 28;
            this.nupLabelWidth.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nupLabelWidth.ValueChanged += new System.EventHandler(this.nupLabelWidth_ValueChanged);
            // 
            // tScrollReDraw
            // 
            this.tScrollReDraw.Tick += new System.EventHandler(this.tScrollReDraw_Tick);
            // 
            // tTVclick
            // 
            this.tTVclick.Tick += new System.EventHandler(this.tTVclick_Tick);
            // 
            // gbTreeview
            // 
            this.gbTreeview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbTreeview.Controls.Add(this.tv);
            this.gbTreeview.Location = new System.Drawing.Point(315, 12);
            this.gbTreeview.Name = "gbTreeview";
            this.gbTreeview.Size = new System.Drawing.Size(457, 704);
            this.gbTreeview.TabIndex = 45;
            this.gbTreeview.TabStop = false;
            this.gbTreeview.Text = "GO term selection";
            // 
            // gbOptions
            // 
            this.gbOptions.Controls.Add(this.label8);
            this.gbOptions.Controls.Add(this.btnExportSelectedGOTerms);
            this.gbOptions.Controls.Add(this.label1);
            this.gbOptions.Controls.Add(this.btnGOTerms);
            this.gbOptions.Controls.Add(this.label2);
            this.gbOptions.Controls.Add(this.btnDataFolder);
            this.gbOptions.Controls.Add(this.label4);
            this.gbOptions.Controls.Add(this.btnImportGOList);
            this.gbOptions.Location = new System.Drawing.Point(12, 12);
            this.gbOptions.Name = "gbOptions";
            this.gbOptions.Size = new System.Drawing.Size(283, 126);
            this.gbOptions.TabIndex = 1;
            this.gbOptions.TabStop = false;
            this.gbOptions.Tag = "1";
            this.gbOptions.Text = "Input options";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(149, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Save list of selected GO terms";
            // 
            // btnExportSelectedGOTerms
            // 
            this.btnExportSelectedGOTerms.Enabled = false;
            this.btnExportSelectedGOTerms.Location = new System.Drawing.Point(203, 93);
            this.btnExportSelectedGOTerms.Name = "btnExportSelectedGOTerms";
            this.btnExportSelectedGOTerms.Size = new System.Drawing.Size(75, 23);
            this.btnExportSelectedGOTerms.TabIndex = 9;
            this.btnExportSelectedGOTerms.Text = "Export";
            this.btnExportSelectedGOTerms.UseVisualStyleBackColor = true;
            this.btnExportSelectedGOTerms.Click += new System.EventHandler(this.btnExportSelectedGOTerms_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuit.Location = new System.Drawing.Point(694, 722);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 23);
            this.btnQuit.TabIndex = 47;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // gbDisplayOption
            // 
            this.gbDisplayOption.Controls.Add(this.rdoBoth);
            this.gbDisplayOption.Controls.Add(this.rdoOdds);
            this.gbDisplayOption.Controls.Add(this.rdoFoldDiff);
            this.gbDisplayOption.Controls.Add(this.btnOrder);
            this.gbDisplayOption.Controls.Add(this.chkDEG);
            this.gbDisplayOption.Controls.Add(this.label3);
            this.gbDisplayOption.Controls.Add(this.chkOdds);
            this.gbDisplayOption.Controls.Add(this.chkHighlightData);
            this.gbDisplayOption.Controls.Add(this.chkNames);
            this.gbDisplayOption.Controls.Add(this.chkJustLabelsWithData);
            this.gbDisplayOption.Controls.Add(this.chkEndent);
            this.gbDisplayOption.Controls.Add(this.nupLabelWidth);
            this.gbDisplayOption.Controls.Add(this.label7);
            this.gbDisplayOption.Enabled = false;
            this.gbDisplayOption.Location = new System.Drawing.Point(12, 279);
            this.gbDisplayOption.Name = "gbDisplayOption";
            this.gbDisplayOption.Size = new System.Drawing.Size(283, 208);
            this.gbDisplayOption.TabIndex = 17;
            this.gbDisplayOption.TabStop = false;
            this.gbDisplayOption.Text = "Image display options";
            // 
            // rdoBoth
            // 
            this.rdoBoth.AutoSize = true;
            this.rdoBoth.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rdoBoth.Checked = true;
            this.rdoBoth.Location = new System.Drawing.Point(228, 104);
            this.rdoBoth.Name = "rdoBoth";
            this.rdoBoth.Size = new System.Drawing.Size(47, 17);
            this.rdoBoth.TabIndex = 24;
            this.rdoBoth.TabStop = true;
            this.rdoBoth.Text = "Both";
            this.rdoBoth.UseVisualStyleBackColor = true;
            this.rdoBoth.CheckedChanged += new System.EventHandler(this.rdoBoth_CheckedChanged);
            // 
            // rdoOdds
            // 
            this.rdoOdds.AutoSize = true;
            this.rdoOdds.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rdoOdds.Location = new System.Drawing.Point(106, 104);
            this.rdoOdds.Name = "rdoOdds";
            this.rdoOdds.Size = new System.Drawing.Size(93, 17);
            this.rdoOdds.TabIndex = 23;
            this.rdoOdds.Text = "Just odds ratio";
            this.rdoOdds.UseVisualStyleBackColor = true;
            this.rdoOdds.CheckedChanged += new System.EventHandler(this.rdoOdds_CheckedChanged);
            // 
            // rdoFoldDiff
            // 
            this.rdoFoldDiff.AutoSize = true;
            this.rdoFoldDiff.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rdoFoldDiff.Location = new System.Drawing.Point(6, 104);
            this.rdoFoldDiff.Name = "rdoFoldDiff";
            this.rdoFoldDiff.Size = new System.Drawing.Size(81, 17);
            this.rdoFoldDiff.TabIndex = 22;
            this.rdoFoldDiff.Text = "Just fold diff";
            this.rdoFoldDiff.UseVisualStyleBackColor = true;
            this.rdoFoldDiff.CheckedChanged += new System.EventHandler(this.rdoFoldDiff_CheckedChanged);
            // 
            // btnOrder
            // 
            this.btnOrder.Location = new System.Drawing.Point(206, 173);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(75, 23);
            this.btnOrder.TabIndex = 30;
            this.btnOrder.Text = "Reorder";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // chkDEG
            // 
            this.chkDEG.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkDEG.Checked = true;
            this.chkDEG.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDEG.Location = new System.Drawing.Point(7, 127);
            this.chkDEG.Margin = new System.Windows.Forms.Padding(2);
            this.chkDEG.Name = "chkDEG";
            this.chkDEG.Size = new System.Drawing.Size(161, 17);
            this.chkDEG.TabIndex = 25;
            this.chkDEG.Text = "Fold change of linked genes";
            this.chkDEG.UseVisualStyleBackColor = true;
            this.chkDEG.CheckedChanged += new System.EventHandler(this.chkDEG_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Change order files are displayed ";
            // 
            // chkOdds
            // 
            this.chkOdds.AutoSize = true;
            this.chkOdds.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkOdds.Location = new System.Drawing.Point(204, 127);
            this.chkOdds.Margin = new System.Windows.Forms.Padding(2);
            this.chkOdds.Name = "chkOdds";
            this.chkOdds.Size = new System.Drawing.Size(74, 17);
            this.chkOdds.TabIndex = 26;
            this.chkOdds.Text = "Odds ratio";
            this.chkOdds.UseVisualStyleBackColor = true;
            this.chkOdds.CheckedChanged += new System.EventHandler(this.chkOdds_CheckedChanged);
            // 
            // chkHighlightData
            // 
            this.chkHighlightData.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkHighlightData.Checked = true;
            this.chkHighlightData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHighlightData.Location = new System.Drawing.Point(8, 82);
            this.chkHighlightData.Name = "chkHighlightData";
            this.chkHighlightData.Size = new System.Drawing.Size(270, 17);
            this.chkHighlightData.TabIndex = 21;
            this.chkHighlightData.Text = "Highlight GO terms with linked data";
            this.chkHighlightData.UseVisualStyleBackColor = true;
            this.chkHighlightData.CheckedChanged += new System.EventHandler(this.chkHighlightData_CheckedChanged);
            // 
            // chkNames
            // 
            this.chkNames.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkNames.Checked = true;
            this.chkNames.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNames.Location = new System.Drawing.Point(8, 39);
            this.chkNames.Margin = new System.Windows.Forms.Padding(2);
            this.chkNames.Name = "chkNames";
            this.chkNames.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkNames.Size = new System.Drawing.Size(270, 17);
            this.chkNames.TabIndex = 19;
            this.chkNames.Text = "Highlight names already present in image";
            this.chkNames.UseVisualStyleBackColor = true;
            this.chkNames.CheckedChanged += new System.EventHandler(this.chkNames_CheckedChanged);
            // 
            // chkJustLabelsWithData
            // 
            this.chkJustLabelsWithData.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkJustLabelsWithData.Location = new System.Drawing.Point(8, 60);
            this.chkJustLabelsWithData.Margin = new System.Windows.Forms.Padding(2);
            this.chkJustLabelsWithData.Name = "chkJustLabelsWithData";
            this.chkJustLabelsWithData.Size = new System.Drawing.Size(270, 17);
            this.chkJustLabelsWithData.TabIndex = 20;
            this.chkJustLabelsWithData.Text = "Just Show GO terms with data";
            this.chkJustLabelsWithData.UseVisualStyleBackColor = true;
            this.chkJustLabelsWithData.CheckedChanged += new System.EventHandler(this.chkJustLabelsWithData_CheckedChanged);
            // 
            // chkEndent
            // 
            this.chkEndent.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkEndent.Checked = true;
            this.chkEndent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEndent.Location = new System.Drawing.Point(8, 18);
            this.chkEndent.Margin = new System.Windows.Forms.Padding(2);
            this.chkEndent.Name = "chkEndent";
            this.chkEndent.Size = new System.Drawing.Size(270, 17);
            this.chkEndent.TabIndex = 18;
            this.chkEndent.Text = "Indent labels to show relationships";
            this.chkEndent.UseVisualStyleBackColor = true;
            this.chkEndent.CheckedChanged += new System.EventHandler(this.chkEndent_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 77);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(204, 13);
            this.label10.TabIndex = 36;
            this.label10.Text = "Select to draw just filtered data or all data:";
            // 
            // rdoFilteredData
            // 
            this.rdoFilteredData.AutoSize = true;
            this.rdoFilteredData.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rdoFilteredData.Enabled = false;
            this.rdoFilteredData.Location = new System.Drawing.Point(8, 93);
            this.rdoFilteredData.Name = "rdoFilteredData";
            this.rdoFilteredData.Size = new System.Drawing.Size(125, 17);
            this.rdoFilteredData.TabIndex = 37;
            this.rdoFilteredData.TabStop = true;
            this.rdoFilteredData.Text = "Just filtered GO terms";
            this.rdoFilteredData.UseVisualStyleBackColor = true;
            this.rdoFilteredData.CheckedChanged += new System.EventHandler(this.rdoFilteredData_CheckedChanged);
            // 
            // rdoAllData
            // 
            this.rdoAllData.AutoSize = true;
            this.rdoAllData.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rdoAllData.Checked = true;
            this.rdoAllData.Location = new System.Drawing.Point(218, 93);
            this.rdoAllData.Name = "rdoAllData";
            this.rdoAllData.Size = new System.Drawing.Size(60, 17);
            this.rdoAllData.TabIndex = 38;
            this.rdoAllData.TabStop = true;
            this.rdoAllData.Text = "All data";
            this.rdoAllData.UseVisualStyleBackColor = true;
            this.rdoAllData.CheckedChanged += new System.EventHandler(this.rdoAllData_CheckedChanged);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(8, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(191, 26);
            this.label11.TabIndex = 41;
            this.label11.Text = "Save image of currently selected GO to image file";
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(203, 42);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 23);
            this.btnFilter.TabIndex = 35;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(191, 26);
            this.label5.TabIndex = 34;
            this.label5.Text = "Filter terms by p value of specific file(s)";
            // 
            // rdoCC
            // 
            this.rdoCC.AutoSize = true;
            this.rdoCC.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rdoCC.Enabled = false;
            this.rdoCC.Location = new System.Drawing.Point(162, 42);
            this.rdoCC.Name = "rdoCC";
            this.rdoCC.Size = new System.Drawing.Size(115, 17);
            this.rdoCC.TabIndex = 13;
            this.rdoCC.TabStop = true;
            this.rdoCC.Text = "Cellular component";
            this.rdoCC.UseVisualStyleBackColor = true;
            this.rdoCC.CheckedChanged += new System.EventHandler(this.rdoCC_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Select the GO data set";
            // 
            // rdoMF
            // 
            this.rdoMF.AutoSize = true;
            this.rdoMF.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rdoMF.Enabled = false;
            this.rdoMF.Location = new System.Drawing.Point(166, 63);
            this.rdoMF.Name = "rdoMF";
            this.rdoMF.Size = new System.Drawing.Size(112, 17);
            this.rdoMF.TabIndex = 14;
            this.rdoMF.TabStop = true;
            this.rdoMF.Text = "Molecular function";
            this.rdoMF.UseVisualStyleBackColor = true;
            this.rdoMF.CheckedChanged += new System.EventHandler(this.rdoMF_CheckedChanged);
            // 
            // rdoBP
            // 
            this.rdoBP.AutoSize = true;
            this.rdoBP.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rdoBP.Enabled = false;
            this.rdoBP.Location = new System.Drawing.Point(166, 20);
            this.rdoBP.Name = "rdoBP";
            this.rdoBP.Size = new System.Drawing.Size(111, 17);
            this.rdoBP.TabIndex = 12;
            this.rdoBP.TabStop = true;
            this.rdoBP.Text = "Biological Process";
            this.rdoBP.UseVisualStyleBackColor = true;
            this.rdoBP.CheckedChanged += new System.EventHandler(this.rdoBP_CheckedChanged);
            // 
            // gbTreeViewOptions
            // 
            this.gbTreeViewOptions.Controls.Add(this.chkToolTips);
            this.gbTreeViewOptions.Controls.Add(this.rdoBP);
            this.gbTreeViewOptions.Controls.Add(this.rdoMF);
            this.gbTreeViewOptions.Controls.Add(this.label9);
            this.gbTreeViewOptions.Controls.Add(this.rdoCC);
            this.gbTreeViewOptions.Controls.Add(this.chkLimit);
            this.gbTreeViewOptions.Enabled = false;
            this.gbTreeViewOptions.Location = new System.Drawing.Point(12, 144);
            this.gbTreeViewOptions.Name = "gbTreeViewOptions";
            this.gbTreeViewOptions.Size = new System.Drawing.Size(283, 129);
            this.gbTreeViewOptions.TabIndex = 10;
            this.gbTreeViewOptions.TabStop = false;
            this.gbTreeViewOptions.Text = "Data tree view options";
            // 
            // chkToolTips
            // 
            this.chkToolTips.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkToolTips.Location = new System.Drawing.Point(8, 106);
            this.chkToolTips.Name = "chkToolTips";
            this.chkToolTips.Size = new System.Drawing.Size(270, 17);
            this.chkToolTips.TabIndex = 16;
            this.chkToolTips.Text = "Show GO term descriptions";
            this.chkToolTips.UseVisualStyleBackColor = true;
            this.chkToolTips.CheckedChanged += new System.EventHandler(this.ChkToolTips_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Location = new System.Drawing.Point(12, 693);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(283, 23);
            this.groupBox2.TabIndex = 41;
            this.groupBox2.TabStop = false;
            // 
            // tTitle
            // 
            this.tTitle.Interval = 1500;
            this.tTitle.Tick += new System.EventHandler(this.tTitle_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nupSaveWidth);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(12, 618);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(283, 69);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Save image";
            // 
            // nupSaveWidth
            // 
            this.nupSaveWidth.Location = new System.Drawing.Point(203, 44);
            this.nupSaveWidth.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nupSaveWidth.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nupSaveWidth.Name = "nupSaveWidth";
            this.nupSaveWidth.Size = new System.Drawing.Size(72, 20);
            this.nupSaveWidth.TabIndex = 44;
            this.nupSaveWidth.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 48);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 13);
            this.label12.TabIndex = 43;
            this.label12.Text = "Graph width ";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdoAllData);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.rdoFilteredData);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.btnFilter);
            this.groupBox3.Controls.Add(this.txtSignificant);
            this.groupBox3.Enabled = false;
            this.groupBox3.Location = new System.Drawing.Point(12, 493);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(283, 119);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Filter data";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(230, 722);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 48;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 757);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbTreeViewOptions);
            this.Controls.Add(this.gbDisplayOption);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.gbTreeview);
            this.Controls.Add(this.gbOptions);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(800, 796);
            this.Name = "Form1";
            this.Text = "GO Term Viewer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.cmFind.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nupLabelWidth)).EndInit();
            this.gbTreeview.ResumeLayout(false);
            this.gbOptions.ResumeLayout(false);
            this.gbOptions.PerformLayout();
            this.gbDisplayOption.ResumeLayout(false);
            this.gbDisplayOption.PerformLayout();
            this.gbTreeViewOptions.ResumeLayout(false);
            this.gbTreeViewOptions.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupSaveWidth)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGOTerms;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView tv;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDataFolder;
        private System.Windows.Forms.CheckBox chkLimit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnImportGOList;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSignificant;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nupLabelWidth;
        private System.Windows.Forms.Timer tScrollReDraw;
        private System.Windows.Forms.Timer tTVclick;
        private System.Windows.Forms.GroupBox gbTreeview;
        private System.Windows.Forms.GroupBox gbOptions;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnExportSelectedGOTerms;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.GroupBox gbDisplayOption;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rdoCC;
        private System.Windows.Forms.RadioButton rdoMF;
        private System.Windows.Forms.RadioButton rdoBP;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkJustLabelsWithData;
        private System.Windows.Forms.CheckBox chkEndent;
        private System.Windows.Forms.CheckBox chkNames;
        private System.Windows.Forms.GroupBox gbTreeViewOptions;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RadioButton rdoFilteredData;
        private System.Windows.Forms.RadioButton rdoAllData;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkHighlightData;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox chkDEG;
        private System.Windows.Forms.CheckBox chkOdds;
        private System.Windows.Forms.CheckBox chkToolTips;
        private System.Windows.Forms.Timer tTitle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown nupSaveWidth;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RadioButton rdoBoth;
        private System.Windows.Forms.RadioButton rdoOdds;
        private System.Windows.Forms.RadioButton rdoFoldDiff;
        private System.Windows.Forms.ContextMenuStrip cmFind;
        private System.Windows.Forms.ToolStripMenuItem findGOTermToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findCommonPathToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem moveTermUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveTermDownToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem hideunhideTermsDataToolStripMenuItem;
        private System.Windows.Forms.Button button1;
    }
}
