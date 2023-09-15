using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GoTermViewer;
using Microsoft.VisualBasic;


namespace GOTermViewer
{
    public partial class StartMain : Form
    {        
        private List<term> terms = new List<term>();
        private Dictionary<string, term> molecular_function;
        private Dictionary<string, term> biological_process;
        private Dictionary<string, term> cellular_component;
        private Dictionary<string, term> selectedData;
        private term root_molecular_function;
        private term root_biological_process;
        private term root_cellular_component;
        //private term root_selectedData;
        private TreeNode tn_molecular_function;
        private TreeNode tn_biological_process;
        private TreeNode tn_cellular_component;
        private TreeNode tn_selectedNode;
        private bool limitNodes = false;
        private double cutOff = 0.05;
        private string titleText = "";

        //drawing variables
        private ImageViewer iv;
        private int numberOfSamples = 0;
        private List<string> samples;
        private List<string> samplesOriginal;
        private Rectangle[] regions;
        private Bitmap btm;
        private Graphics g;
        private int labelWidth = 500;
        private static int topOffP1Image = 0;
        private bool tvCheckedTimer = false;
        private bool drawFilteredData = false;
        private List<Point[]> lines = null;

        private bool scrolling = false;

        Dictionary<string, string> editedNames = null;
        public StartMain()
        {
            InitializeComponent();

            iv = new ImageViewer(this);
        }

        private void CleanUP()
        {
            rdoBP.Enabled = false;
            rdoCC.Enabled = false;
            rdoMF.Enabled = false;
            rdoBP.Checked = false;
            rdoCC.Checked = false;
            rdoMF.Checked = false;

            cellular_component = null;
            root_cellular_component = null;
            molecular_function = null;
            root_molecular_function = null;
            biological_process = null;
            root_biological_process = null;
            selectedData = null;
            //root_selectedData = null;
            tn_selectedNode = null;

            gbDisplayOption.Enabled = false;
            gbTreeViewOptions.Enabled = false;
            btnDataFolder.Enabled = false;
            btnImportGOList.Enabled = false;
            btnExportSelectedGOTerms.Enabled = false;
            groupBox1.Enabled = false;
            groupBox3.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string GO_oboFile = FileAccessClass.FileString(FileAccessClass.FileJob.Open, "Select the GO term file", "GO term text file (*.obo)|*.obo");
            if (System.IO.File.Exists(GO_oboFile) == false) { return; }

            titleText = Text;
            Text = "Loading phrases";

            System.IO.StreamReader fs = null;
            tv.Enabled = false;
            CleanUP();

            try
            {
                fs = new System.IO.StreamReader(GO_oboFile);
                terms = new List<term>();

                string line = "";
                Dictionary<string, string> data = new Dictionary<string, string>();
                List<string> relaionships = new List<string>();
                while (fs.Peek() > 0)
                {
                    line = fs.ReadLine();

                    if (line.ToLower().Equals("[typedef]") == true)
                    {
                        break;
                    }
                    else if (line.StartsWith("id:") == true)
                    { data.Add("id", line.Trim()); }
                    else if (line.StartsWith("namespace:") == true)
                    { data.Add("namespace", line.Trim()); }
                    else if (line.StartsWith("name:") == true)
                    { data.Add("name", line.Trim()); }
                    else if (line.StartsWith("def:") == true)
                    { data.Add("def", line.Trim()); }
                    else if (line.StartsWith("comment:") == true)
                    { data.Add("comment", line.Trim()); }
                    else if (line.StartsWith("is_a") == true)
                    { relaionships.Add(line.Trim()); }
                    else if (line.StartsWith("is_obsolete:") == true)
                    { relaionships.Add(line.Trim()); }
                    else if (line.StartsWith("relationship: regulates ") == true)
                    { relaionships.Add(line.Substring(14).Trim()); }
                    else if (line.StartsWith("relationship: negatively_regulates") == true)
                    { relaionships.Add(line.Substring(14).Trim()); }
                    else if (line.StartsWith("relationship: positively_regulates") == true)
                    { relaionships.Add(line.Substring(14).Trim()); }
                    else if (line.StartsWith("relationship: has_part") == true)
                    { relaionships.Add(line.Substring(14).Trim()); }
                    else if (line.StartsWith("relationship: part_of") == true)
                    { relaionships.Add(line.Substring(14).Trim()); }
                    else if (line.StartsWith("relationship: occurs_in") == true)
                    { relaionships.Add(line.Substring(14).Trim()); }
                    else if (line.StartsWith("relationship: happens_during") == true)
                    { relaionships.Add(line.Substring(14).Trim()); }
                    else if (line.StartsWith("relationship: ends_during") == true)
                    { relaionships.Add(line.Substring(14).Trim()); }
                    else if (string.IsNullOrEmpty(line) == true)
                    {
                        if (data.Count > 0)
                        {
                            term currentTerm = new term(data, relaionships);
                            if (currentTerm != null)
                            { terms.Add(currentTerm); }
                        }
                        data = new Dictionary<string, string>();
                        relaionships = new List<string>();
                    }
                }

                Text = "Added " + terms.Count.ToString("N0") + ", now forming tree";


                term_sorter ts = new term_sorter();
                terms.Sort(ts);

                PutInSpace(terms);
                LinkTogether();
                terms = null;

                AddTermsToNodes();

                btnDataFolder.Enabled = true;
            }
            catch (Exception ex)
            {
                btnDataFolder.Enabled = false;
                btnExportSelectedGOTerms.Enabled = false;
                btnImportGOList.Enabled = false;
                gbDisplayOption.Enabled = false;
                gbTreeViewOptions.Enabled = false;
                groupBox1.Enabled = false;
                groupBox3.Enabled = false;
            }
            finally
            {
                tTitle.Enabled = true;
                if (fs != null) { fs.Close(); }
            }
        }

        private void AddTermsToNodes()
        {
            tv.Nodes.Clear();

            foreach (term t in biological_process.Values)
            {
                if (t.Relationships.Count == 0)
                {
                    root_biological_process = t;
                    tn_biological_process = new TreeNode("Biological process");
                    tn_biological_process.Tag = t.ID;
                    tn_biological_process.Nodes.Add(new TreeNode("dummy"));
                    tv.Nodes.Add(tn_biological_process);
                }
            }

            foreach (term t in cellular_component.Values)
            {
                if (t.Relationships.Count == 0)
                {
                    root_cellular_component = t;
                    tn_cellular_component = new TreeNode("Cellular component");
                    tn_cellular_component.Tag = t.ID;
                    tn_cellular_component.Nodes.Add(new TreeNode("dummy"));
                    tv.Nodes.Add(tn_cellular_component);
                }
            }

            foreach (term t in molecular_function.Values)
            {
                if (t.Relationships.Count == 0)
                {
                    root_molecular_function = t;
                    tn_molecular_function = new TreeNode("Molecular function");
                    tn_molecular_function.Tag = t.ID;
                    tn_molecular_function.Nodes.Add(new TreeNode("dummy"));
                    tv.Nodes.Add(tn_molecular_function);
                }
            }

            //tv.Sort();
        }

        private void PutInSpace(List<term> terms)
        {
            molecular_function = new Dictionary<string, term>();
            biological_process = new Dictionary<string, term>();
            cellular_component = new Dictionary<string, term>();

            foreach (term t in terms)
            {
                switch (t.Set)
                {
                    case term.space.biological_process:
                        biological_process.Add(t.ID, t);
                        break;
                    case term.space.cellular_component:
                        cellular_component.Add(t.ID, t);
                        break;
                    case term.space.molecular_function:
                        molecular_function.Add(t.ID, t);
                        break;
                    default:
                        throw new Exception();

                }
            }
        }

        private void LinkTogether()
        {
            foreach (term t in biological_process.Values)
            {
                string id = t.ID;
                foreach (string lk in t.Relationships)
                {
                    string key = GetTerm(lk);
                    if (biological_process.ContainsKey(key) == true)
                    { biological_process[key].AddAChild(t); }
                    if (cellular_component.ContainsKey(key) == true)
                    { cellular_component[key].AddAChild(t); }
                    if (molecular_function.ContainsKey(key) == true)
                    { molecular_function[key].AddAChild(t); }
                }
            }
            foreach (term t in cellular_component.Values)
            {
                string id = t.ID;
                foreach (string lk in t.Relationships)
                {
                    string key = GetTerm(lk);
                    if (biological_process.ContainsKey(key) == true)
                    { biological_process[key].AddAChild(t); }
                    if (cellular_component.ContainsKey(key) == true)
                    { cellular_component[key].AddAChild(t); }
                    if (molecular_function.ContainsKey(key) == true)
                    { molecular_function[key].AddAChild(t); }
                }
            }
            foreach (term t in molecular_function.Values)
            {
                string id = t.ID;
                foreach (string lk in t.Relationships)
                {
                    string key = GetTerm(lk);
                    if (biological_process.ContainsKey(key) == true)
                    { biological_process[key].AddAChild(t); }
                    if (cellular_component.ContainsKey(key) == true)
                    { cellular_component[key].AddAChild(t); }
                    if (molecular_function.ContainsKey(key) == true)
                    { molecular_function[key].AddAChild(t); }
                }
            }
        }

        private string GetTerm(string line)
        {
            string answer = "";
            int indexColon = line.IndexOf(":") + 2;
            int indexExclaimation = line.IndexOf("!") - 1;
            if (indexColon > 1 && indexExclaimation > -1)
            { answer = line.Substring(indexColon, indexExclaimation - indexColon); }
            else if (indexColon > 1 && indexExclaimation == -2)
            { answer = line.Substring(indexColon).Trim(); }

            return answer;
        }

        private term GetTermFromCollection(string id)
        {
            if (molecular_function.ContainsKey(id) == true)
            { return (molecular_function[id]); }
            if (cellular_component.ContainsKey(id) == true)
            { return (cellular_component[id]); }
            if (biological_process.ContainsKey(id) == true)
            { return (biological_process[id]); }
            return new term();
        }

        private void StartMain_Load(object sender, EventArgs e)
        {
            SetTreeviewImages();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string folder = FileAccessClass.FileString(FileAccessClass.FileJob.Directory, "Select the folder of GO data", "");
            if (System.IO.Directory.Exists(folder) == false) { return; }

            string input = Interaction.InputBox("Enter the p value cut off. If a term as no data below this value it will be ignored. (0.01 - 1)"
                , "p Value input cut off", "0.05");
            double inputCutOff = 0;
            try
            {
                inputCutOff = Convert.ToDouble(input);
                if (inputCutOff > 1 || inputCutOff < 0.01)
                {
                    MessageBox.Show("The value: " + input + " is not in the range 0.05 to 1.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch
            {
                if (string.IsNullOrEmpty(input) == false)
                { MessageBox.Show("The value: " + input + "is not a decimal number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                return;
            }

            tTitle.Enabled = false;

            string[] files = System.IO.Directory.GetFiles(folder, "*.xls");
            samples = new List<string>();
            editedNames = new Dictionary<string, string>();
            bool OK = true;

            foreach (string fileName in files)
            {
                bool dataAdded = false;


                string file = fileName.Substring(fileName.LastIndexOf('\\') + 1);
                file = file.Substring(0, file.Length - 4);

                Text = "Processing: " + file;
                Application.DoEvents();
                System.IO.StreamReader fs = null;
                try
                {
                    fs = new System.IO.StreamReader(fileName);
                    fs.ReadLine();
                    string line;
                    string id;
                    while (fs.Peek() > 0)
                    {
                        line = fs.ReadLine();
                        int GOIndex = line.IndexOf("GO");
                        int spaceIndex = line.IndexOf("\t", GOIndex + 1);
                        if (GOIndex > -1 && spaceIndex > 0)
                        {
                            id = line.Substring(GOIndex, spaceIndex - GOIndex);

                            if (molecular_function.ContainsKey(id) == true)
                            {
                                molecular_function[id].addDataRow(line, file, inputCutOff);
                                dataAdded = true;
                            }
                            if (cellular_component.ContainsKey(id) == true)
                            {
                                cellular_component[id].addDataRow(line, file, inputCutOff);
                                dataAdded = true;
                            }
                            if (biological_process.ContainsKey(id) == true)
                            {
                                biological_process[id].addDataRow(line, file, inputCutOff);
                                dataAdded = true;
                            }
                        }
                    }
                    if (dataAdded == true)
                    {
                        numberOfSamples++;
                        samples.Add(file);
                        editedNames.Add(file, file);
                    }


                }
                catch (Exception ex)
                {
                    OK = false;
                    MessageBox.Show("Error reading: " + file, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (fs != null) { fs.Close(); }
                }
            }

            tTitle.Enabled = true;

            if (OK == true)
            {
                gbDisplayOption.Enabled = true;
                groupBox1.Enabled = true;
                groupBox3.Enabled = true;
                gbTreeViewOptions.Enabled = true;
                btnExportSelectedGOTerms.Enabled = true;
                btnImportGOList.Enabled = true;
                btnDataFolder.Enabled = false;
                tv.Enabled = true;
            }
            else
            {
                gbDisplayOption.Enabled = false;
                groupBox1.Enabled = false;
                groupBox3.Enabled = false;
                gbTreeViewOptions.Enabled = false;
                btnExportSelectedGOTerms.Enabled = false;
                btnImportGOList.Enabled = false;
                btnDataFolder.Enabled = false;
                tv.Enabled = false;
            }

            samplesOriginal = samples;

            SetTermStatus();

            limitNodes = chkLimit.Checked;
            if (root_biological_process.HasDataInTree == true)
            {
                tn_biological_process.ImageIndex = 1;
                tn_biological_process.SelectedImageIndex = 1;
                rdoBP.Enabled = true;
                rdoBP.Checked = true;
            }
            tn_biological_process.Collapse();
            if (root_cellular_component.HasDataInTree == true)
            {
                tn_cellular_component.ImageIndex = 1;
                tn_cellular_component.SelectedImageIndex = 1;
                rdoCC.Enabled = true;
                rdoCC.Checked = true;
            }
            tn_cellular_component.Collapse();
            if (root_molecular_function.HasDataInTree == true)
            {
                tn_molecular_function.ImageIndex = 1;
                tn_molecular_function.SelectedImageIndex = 1;
                rdoMF.Enabled = true;
                rdoMF.Checked = true;
            }
            tn_molecular_function.Collapse();

            DrawImage();

        }

        private void SetTermStatus()
        {
            root_molecular_function.HaveChildrenGotData(molecular_function);
            root_biological_process.HaveChildrenGotData(biological_process);
            root_cellular_component.HaveChildrenGotData(cellular_component);
        }

        private void SetTreeviewImages()
        {
            Bitmap NoData = new Bitmap(10, 10, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(NoData);
            g.Clear(tv.BackColor);
            g.FillEllipse(Brushes.Pink, 0, 0, 10, 10);
            g = null;

            Bitmap NoDataButChildHas = new Bitmap(10, 10, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            g = Graphics.FromImage(NoDataButChildHas);
            g.DrawEllipse(new Pen(Color.Green, 1), 1, 2, 7, 7);
            g = null;

            Bitmap HasData = new Bitmap(10, 10, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            g = Graphics.FromImage(HasData);
            g.FillEllipse(Brushes.Green, 0, 0, 10, 10);
            g = null;

            Bitmap NoDataHiddenButChildHas = new Bitmap(10, 10, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            g = Graphics.FromImage(NoDataHiddenButChildHas);
            g.DrawEllipse(new Pen(Color.Green, 1), 1, 2, 7, 7);
            g.DrawLine(new Pen(Color.Red, 2), 0, 10, 10, 0);
            g = null;


            Bitmap HasHiddenData = new Bitmap(10, 10, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            g = Graphics.FromImage(HasHiddenData);
            g.FillEllipse(Brushes.Green, 0, 00, 10, 10);
            g.DrawLine(new Pen(Color.Red, 2), 0, 10, 10, 0);


            ImageList myImageList = new ImageList();

            myImageList.Images.Add(NoData);
            myImageList.Images.Add(NoDataButChildHas);
            myImageList.Images.Add(HasData);
            myImageList.Images.Add(NoDataHiddenButChildHas);
            myImageList.Images.Add(HasHiddenData);
            tv.ImageList = myImageList;
            tv.ImageIndex = 0;

        }

        private void Tv_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            bool toolTip = chkToolTips.Checked;

            if (e.Node.Nodes.Count > 0)
            { e.Node.Nodes.Clear(); }

            string key = (string)e.Node.Tag;
            term currentTerm = GetTermFromCollection(key);

            if (currentTerm.ID != "")
            {
                foreach (term t in currentTerm.Children)
                {
                    if (t.HasDataInTree == true || limitNodes == false)
                    {
                        TreeNode newNode = new TreeNode(t.Name);

                        if (t.HasDataInTree == true && t.getDataCount == 0)
                        {
                            if (t.Hidden == false)
                            { newNode.ImageIndex = 1; }
                            else
                            { newNode.ImageIndex = 3; }

                        }
                        else if (t.HasDataInTree == true && t.getDataCount > 0)
                        {
                            if (t.Hidden == false)
                            { newNode.ImageIndex = 2; }
                            else
                            { newNode.ImageIndex = 4; }
                        }
                        else
                        { newNode.ImageIndex = 0; ; }

                        newNode.Tag = t.ID;

                        if (toolTip == true)
                        { newNode.ToolTipText = t.DescriptionToolTip(); }
                        newNode.SelectedImageIndex = newNode.ImageIndex;
                        if (t.WasNodeSelected == true) { newNode.Checked = true; }
                        e.Node.Nodes.Add(newNode);
                        if (t.Children.Count > 0)
                        { newNode.Nodes.Add(new TreeNode("dummy")); }
                    }
                }
            }
            DrawImage();
        }

        private void ChkLimit_CheckedChanged(object sender, EventArgs e)
        {
            MakeRootNodes();
        }

        private void ChkToolTips_CheckedChanged(object sender, EventArgs e)
        {
            MakeRootNodes();
        }

        private void MakeRootNodes()
        {

            limitNodes = chkLimit.Checked;
            tn_biological_process.Collapse();
            tn_cellular_component.Collapse();
            tn_molecular_function.Collapse();
            if (limitNodes == false)
            {
                if (tn_biological_process.Nodes.Count == 0)
                { tn_biological_process.Nodes.Add(new TreeNode("dummy")); }
                if (tn_biological_process.Nodes.Count == 0)
                { tn_biological_process.Nodes.Add(new TreeNode("dummy")); }
                if (tn_molecular_function.Nodes.Count == 0)
                { tn_molecular_function.Nodes.Add(new TreeNode("dummy")); }
            }
        }

        private void Tv_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag == null) { return; }
            string key = (string)e.Node.Tag;
            if (string.IsNullOrEmpty(key) == true) { return; }

            if (e.Node.ImageIndex == 0)
            { return; }

            if (molecular_function.ContainsKey(key) == true)
            {
                molecular_function[key].WasNodeSelected = e.Node.Checked;
                ClickParentOrChildNodes(e.Node);
            }
            if (biological_process.ContainsKey(key) == true)
            {
                biological_process[key].WasNodeSelected = e.Node.Checked;
                ClickParentOrChildNodes(e.Node);
            }
            if (cellular_component.ContainsKey(key) == true)
            {
                cellular_component[key].WasNodeSelected = e.Node.Checked;
                ClickParentOrChildNodes(e.Node);
            }

            StartDrawTimer();
        }

        private void SetScrollbarValuse()
        {
            Font f = new Font(FontFamily.GenericSerif, 12);
            if (suppressVSBP1Changes == true) { return; }
            int value = getScreenHeigth(f, drawFilteredData);


            if (value > 32000)
            { value = 32000; }

            value = value + 50 - iv.P1.Height;
            if (value < 0)
            {
                value = 0;
                topOffP1Image = 0;
            }

            int currentValue = iv.VSBP1.Value;
            iv.VSBP1.Maximum = value;
            if (currentValue > value)
            { currentValue = value; }
            iv.VSBP1.Value = currentValue;
            if (iv.VSBP1.Maximum > iv.P1.Height) { iv.VSBP1.LargeChange = 25; }
            StartDrawTimer();
        }

        private bool suppressVSBP1Changes = false;
        private void ClickParentOrChildNodes(TreeNode node)
        {
            try
            {
                suppressVSBP1Changes = true;
                if (node.Checked == true && node.Parent != null)
                {
                    node.Parent.Checked = true;
                }

                if (node.Checked == false)
                {
                    foreach (TreeNode child in node.Nodes)
                    { child.Checked = false; }
                }

                if (node.Checked == true)
                {
                    foreach (TreeNode child in node.Nodes)
                    {
                        if (child.Checked == true)
                        {
                            string key = (string)child.Tag;
                            selectedData[key].WasNodeSelected = true;
                        }
                    }
                }

            }
            finally
            {
                suppressVSBP1Changes = false;
            }
        }

        private void ImportGOTerms_Click(object sender, EventArgs e)
        {
            string listOfGOTerms = FileAccessClass.FileString(FileAccessClass.FileJob.Open, "Select the list of GO terms", "GO term text file (*.txt)|*.txt");
            if (System.IO.File.Exists(listOfGOTerms) == false) { return; }

            System.IO.StreamReader fs = null;

            try
            {
                fs = new System.IO.StreamReader(listOfGOTerms);

                while (fs.Peek() > 0)
                {
                    string line = fs.ReadLine();

                    string path = line.Replace(" <- ", "\t");
                    string[] items = path.Split('\t');
                    Array.Reverse(items);
                    tn_selectedNode.Expand();
                    showTerm(items, 1, tn_selectedNode);

                }
                DrawImage();
            }
            catch { }
            finally
            { if (fs != null) { fs.Close(); } }
        }

        private void TxtSignificant_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cutOff = Convert.ToDouble(txtSignificant.Text.Trim());
                if (cutOff > 1 && cutOff < 0)
                { txtSignificant.Text = "0.05"; }
                StartDrawTimer();
            }
            catch
            { txtSignificant.Text = "0.05"; }
        }

        private Bitmap SortDrawingsArea(Size dimensions, int labelWidth, Dictionary<String, term> terms, Font font, int Yoffset, bool drawFiltered, bool endent, bool drawAll, bool addStar, bool showDegAxis, bool bothAxis)
        {
            lines = new List<Point[]>();

            numberOfSamples = samples.Count;
            regions = new Rectangle[numberOfSamples];
            int gaps = (numberOfSamples) * 10;
            int width = (dimensions.Width - labelWidth - gaps) / numberOfSamples;
            if (width < nupSaveWidth.Minimum)
            { nupSaveWidth.Value = nupSaveWidth.Minimum; }
            else if (width > nupSaveWidth.Maximum)
            { nupSaveWidth.Value = nupSaveWidth.Maximum; }
            else
            { nupSaveWidth.Value = width; }
            int heigth = dimensions.Height;
            int x = labelWidth;

            int extra = 0;
            if (bothAxis == true) { extra = 30; }

            for (int index = 0; index < regions.Length; index++)
            {
                Rectangle r = new Rectangle(x, 25, width, heigth - (40 + extra));
                x += width + 10;
                regions[index] = r;
            }

            btm = new Bitmap(dimensions.Width, dimensions.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            g = Graphics.FromImage(btm);
            g.Clear(Color.White);
            g.DrawRectangles(Pens.Black, regions);


            Pen dots = new Pen(Color.Gray, 1);
            dots.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

            float interval = width / 5;

            if (showDegAxis == true)
            { drawImageFrameFoldChange(g, font, dots, interval, bothAxis); }
            else { drawImageFrameOddsratio(g, font, dots, interval, bothAxis); }

            int drawThese;
            if (rdoFoldDiff.Checked == true)
            { drawThese = 1; }
            else if (rdoOdds.Checked == true)
            { drawThese = 2; }
            else
            { drawThese = 3; }

            DrawDataScreen(g, cutOff, terms, font, Yoffset, drawFiltered, endent, drawAll, lines, addStar, drawThese);

            g.FillRectangle(Brushes.White, 0, 0, labelWidth, regions[0].Top);
            g.DrawString("Gene Ontology terms", font, Brushes.Black, 5, 3);

            return btm;
        }

        private void drawImageFrameOddsratio(Graphics g, Font font, Pen dots, float interval, bool bothAxis)
        {
            for (int index = 0; index < regions.Length; index++)
            {
                Rectangle r = regions[index];
                g.DrawString(editedNames[samples[index]], font, Brushes.Black, r.X, 3);
                g.FillRectangle(Brushes.White, r.Right, 0, iv.P1.Width - r.Right, r.Top);

                if (index == 0)
                {
                    g.DrawString("Odds ratio value:", font, Brushes.Black, r.X - 120, r.Bottom);
                }

                string[] labels = { "0", "5", "10", "15", "20", ">25" };

                if ((int)g.MeasureString(">25", font).Width < interval)
                {
                    for (int line = 1; line < 6; line++)
                    {
                        g.DrawLine(dots, r.X + 1 + (interval * line), r.Top, r.X + 1 + (interval * line), r.Bottom);
                    }
                    g.DrawString(labels[0], font, Brushes.Black, r.X - 0, r.Bottom);
                    g.DrawString(labels[1], font, Brushes.Black, r.X - 5 + (interval * (1)), r.Bottom);
                    g.DrawString(labels[2], font, Brushes.Black, r.X - 12 + (interval * (2)), r.Bottom);
                    g.DrawString(labels[3], font, Brushes.Black, r.X - 12 + (interval * (3)), r.Bottom);
                    g.DrawString(labels[4], font, Brushes.Black, r.X - 12 + (interval * (4)), r.Bottom);
                    g.DrawString(labels[5], font, Brushes.Black, r.X - 22 + (interval * (5)), r.Bottom);
                }
                else if ((int)g.MeasureString("12.5", font).Width < interval)
                {
                    g.DrawString(labels[0], font, Brushes.Black, r.X - 0, r.Bottom);
                    g.DrawString("12.5", font, Brushes.Black, r.X - 12 + (interval * 2.5f), r.Bottom);
                    g.DrawString(">25", font, Brushes.Black, r.X - 22 + (interval * 5), r.Bottom);
                }
                else
                {
                    g.DrawString(labels[0], font, Brushes.Black, r.X - 0, r.Bottom);
                    g.DrawString(">25", font, Brushes.Black, r.X - 22 + (interval * 5), r.Bottom);
                }
            }

            if (bothAxis == true) { drawImageFrameFoldChange2nd(g, font, interval); }
        }

        private void drawImageFrameOddsratio2nd(Graphics g, Font font, float interval)
        {
            for (int index = 0; index < regions.Length; index++)
            {
                Rectangle r = regions[index];
                int bottom = r.Bottom + 20;

                if (index == 0)
                {
                    g.DrawString("Odds ratio value:", font, Brushes.Black, r.X - 140, bottom);
                }

                string[] labels = { "0", "5", "10", "15", "20", ">25" };

                if ((int)g.MeasureString(">25", font).Width < interval)
                {
                    g.DrawString(labels[0], font, Brushes.Black, r.X - 0, bottom);
                    g.DrawString(labels[1], font, Brushes.Black, r.X - 5 + (interval * (1)), bottom);
                    g.DrawString(labels[2], font, Brushes.Black, r.X - 12 + (interval * (2)), bottom);
                    g.DrawString(labels[3], font, Brushes.Black, r.X - 12 + (interval * (3)), bottom);
                    g.DrawString(labels[4], font, Brushes.Black, r.X - 12 + (interval * (4)), bottom);
                    g.DrawString(labels[5], font, Brushes.Black, r.X - 22 + (interval * (5)), bottom);
                }
                else if ((int)g.MeasureString("12.5", font).Width < interval)
                {
                    g.DrawString(labels[0], font, Brushes.Black, r.X - 0, bottom);
                    g.DrawString("12.5", font, Brushes.Black, r.X - 12 + (interval * 2.5f), bottom);
                    g.DrawString(">25", font, Brushes.Black, r.X - 22 + (interval * 5), bottom);
                }
                else
                {
                    g.DrawString(labels[0], font, Brushes.Black, r.X - 0, bottom);
                    g.DrawString(">25", font, Brushes.Black, r.X - 22 + (interval * 5), bottom);
                }
            }
        }

        private void drawImageFrameFoldChange(Graphics g, Font font, Pen dots, float interval, bool bothAxis)
        {
            for (int index = 0; index < regions.Length; index++)
            {
                Rectangle r = regions[index];
                g.DrawString(editedNames[samples[index]], font, Brushes.Black, r.X, 3);
                g.FillRectangle(Brushes.White, r.Right, 0, iv.P1.Width - r.Right, r.Top);
                if (index == 0)
                {
                    g.DrawString("Fold change between expect and actual count:", font, Brushes.Black, r.X - 325, r.Bottom - 3);
                }

                float gap = r.Width / 2.0f;
                if (gap > g.MeasureString("1/10th", font).Width)
                {
                    g.DrawString("1/10th", font, Brushes.Black, r.X - 5, r.Bottom);
                    g.DrawString("10x", font, Brushes.Black, r.X + r.Width - 25, r.Bottom);
                    g.DrawString("1", font, Brushes.Black, r.X + (r.Width / 2.0f) - 5, r.Bottom);
                }
                else
                {
                    float sizeFont = font.Size / 1.5f;
                    Font f = new Font(font.FontFamily, sizeFont);
                    if (gap > g.MeasureString("1/10th", f).Width)
                    {
                        g.DrawString("1/10th", f, Brushes.Black, r.X - 5, r.Bottom);
                        g.DrawString("10x", f, Brushes.Black, r.X + r.Width - 18, r.Bottom);
                        g.DrawString("1", f, Brushes.Black, r.X + (r.Width / 2.0f) - 5, r.Bottom);
                    }
                    else
                    {
                        g.DrawString("1/10th", f, Brushes.Black, r.X - 5, r.Bottom);
                        g.DrawString("10x", f, Brushes.Black, r.X + r.Width - 18, r.Bottom);
                    }
                }

                float scale = r.Width / 18.0f;
                g.DrawLine(dots, r.X + 1 + (5 * scale), r.Top, r.X + 1 + (5 * scale), r.Bottom);
                g.DrawLine(dots, r.X + 1 + (9 * scale), r.Top, r.X + 1 + (9 * scale), r.Bottom);
                g.DrawLine(dots, r.X + 1 + (13 * scale), r.Top, r.X + 1 + (13 * scale), r.Bottom);
            }

            if (bothAxis == true) { drawImageFrameOddsratio2nd(g, font, interval); }
        }

        private void drawImageFrameFoldChange2nd(Graphics g, Font font, float interval)
        {
            for (int index = 0; index < regions.Length; index++)
            {
                Rectangle r = regions[index];
                int bottom = r.Bottom + 15;

                if (index == 0)
                {
                    g.DrawString("Fold change between expect and actual count:", font, Brushes.Black, r.X - 305, bottom);
                }

                float gap = r.Width / 2.0f;
                if (gap > g.MeasureString("1/10th", font).Width)
                {
                    g.DrawString("1/10th", font, Brushes.Black, r.X - 5, bottom);
                    g.DrawString("10x", font, Brushes.Black, r.X + r.Width - 25, bottom);
                    g.DrawString("1", font, Brushes.Black, r.X + (r.Width / 2.0f) - 5, bottom);
                }
                else
                {
                    float sizeFont = font.Size / 1.5f;
                    Font f = new Font(font.FontFamily, sizeFont);
                    if (gap > g.MeasureString("1/10th", f).Width)
                    {
                        g.DrawString("1/10th", f, Brushes.Black, r.X - 5, r.Bottom);
                        g.DrawString("10x", f, Brushes.Black, r.X + r.Width - 18, r.Bottom);
                        g.DrawString("1", f, Brushes.Black, r.X + (r.Width / 2.0f) - 5, r.Bottom);
                    }
                    else
                    {
                        g.DrawString("1/10th", f, Brushes.Black, r.X - 5, r.Bottom);
                        g.DrawString("10x", f, Brushes.Black, r.X + r.Width - 18, r.Bottom);
                    }
                }
            }
        }

        private void DrawDataScreen(Graphics g, double cutOff, Dictionary<string, term> terms, Font font, int Yoffset, bool drawFiltered, bool endent, bool drawAll, List<Point[]> lines, bool addStar, int drawThese)
        {
            int y = 31;
            List<string> used = new List<string>();
            y = drawTermNode(g, tn_selectedNode, y, cutOff, 0, y, 0, terms, font, Yoffset, drawFiltered, endent, drawAll, lines, new Point(0, 0), chkNames.Checked, used, addStar, drawThese);

            if (chkEndent.Checked == true)
            {
                Pen dots = new Pen(Color.Black, 1);
                dots.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

                foreach (Point[] ps in lines)
                {
                    if (ps[1].X != 0 && ps[1].Y != 0)
                    {
                        Point[] p = new Point[3];
                        p[0] = new Point(ps[0].X + 10, ps[0].Y);
                        p[1] = new Point(ps[1].X + 10, ps[0].Y);
                        p[2] = new Point(ps[1].X + 10, ps[1].Y);
                        g.DrawLines(dots, p);
                    }
                    else if (ps[0].Y > 0 && ps[0].X > 2)
                    {
                        g.DrawLine(dots, ps[0].X + 10, ps[0].Y, 10, ps[0].Y);
                    }
                }
            }
        }

        private int drawTermNode(Graphics g, TreeNode thisNode, int y, double cutOff, int level, int parentY, int parentX, Dictionary<string, term> terms, Font font, int Yoffset, bool drawFiltered, bool endent, bool dontDrawAll, List<Point[]> lines, Point lastPoint, bool checkNames, List<string> names, bool addStar, int drawThese)
        {
            if (thisNode == null) { return -1; }
            if (endent == false) { level = 0; }
            string termKey = (string)thisNode.Tag;

            term thisTerm = null;
            if (selectedData.ContainsKey(termKey) == true)
            { thisTerm = selectedData[termKey]; }
            else { return 0; }

            if (thisNode.Checked == true && y + 24 - Yoffset < regions[0].Bottom)
            {
                int biggap = 0;
                int yDraw = y - topOffP1Image;
                Point[] these = new Point[2];

                if (y > Yoffset && yDraw > 20)
                {
                    bool wrote = true;
                    string star = "";
                    Brush nameColour = Brushes.Black;
                    if (checkNames == true && names.Contains(thisTerm.ID) == true)
                    { nameColour = Brushes.Red; }

                    if (dontDrawAll == false && addStar == true) { star = " *"; }

                    if (thisTerm.getDataCount > 0 && thisNode.Checked == true && thisTerm.Hidden == false)
                    {
                        SizeF length = g.MeasureString(thisTerm.Name + star, font);
                        if ((int)length.Width + (level * 10) + 3 > labelWidth)
                        {
                            string[] texts = cutLabel(g, font, thisTerm.Name + star, labelWidth, (level * 10) + 3);
                            g.DrawString(texts[0], font, nameColour, (level * 10) + 3, yDraw - 2 - 6);
                            g.DrawString(texts[1], font, nameColour, (level * 10) + 3, yDraw - 2 + 8);
                            biggap = 8;
                        }
                        else
                        {
                            g.DrawString(thisTerm.Name + star, font, nameColour, (level * 10) + 3, yDraw - 2);
                        }
                        names.Add(thisTerm.ID);

                        if (drawFiltered == true && thisTerm.HasFilteredData == true)
                        { thisTerm.Draw(g, yDraw, regions, samples, cutOff, drawThese); }
                        else if (drawFiltered == false)
                        { thisTerm.Draw(g, yDraw, regions, samples, cutOff, drawThese); }
                    }
                    else if (dontDrawAll == false && thisTerm.Hidden == false)
                    {
                        SizeF length = g.MeasureString(thisTerm.Name, font);
                        if ((int)length.Width + (level * 10) + 3 > labelWidth)
                        {
                            string[] texts = cutLabel(g, font, thisTerm.Name, labelWidth, (level * 10) + 3);
                            g.DrawString(texts[0], font, nameColour, (level * 10) + 3, yDraw - 2 - 6);
                            g.DrawString(texts[1], font, nameColour, (level * 10) + 3, yDraw - 2 + 8);
                            biggap = 8;
                        }
                        else { g.DrawString(thisTerm.Name, font, nameColour, (level * 10) + 3, yDraw - 2); }
                        names.Add(thisTerm.ID);
                    }
                    else
                    {
                        y -= 24;
                        wrote = false;
                    }

                    if (wrote == true)
                    {
                        these[0] = new Point(((level - 1) * 10) + 2, yDraw + 8);
                        these[1] = lastPoint;
                        lines.Add(these);
                    }
                    else
                    { these[0] = lastPoint; }
                }
                else
                {
                    if ((thisTerm.getDataCount > 0 && thisTerm.WasNodeSelected == true) || (dontDrawAll == false))
                    {
                        these[0] = new Point(((level - 1) * 10) + 2, yDraw + 8);
                        these[1] = lastPoint;
                        lines.Add(these);
                    }
                    else
                    {
                        y -= 24;
                        these[0] = lastPoint;
                    }
                }

                int myX = level * 10;
                int myY = yDraw;
                y += 24 + biggap;

                level++;

                int currentY = y;

                if (drawFiltered == false)
                {
                    foreach (TreeNode n in thisNode.Nodes)
                    {
                        if (n.Checked == true)
                        {
                            string key = (string)n.Tag;
                            if (selectedData.ContainsKey(key) == true)
                            {
                                term t = selectedData[key];
                                if (t.HasDataInTree == true)
                                { y = drawTermNode(g, n, y, cutOff, level, myY, myX, terms, font, Yoffset, drawFiltered, endent, dontDrawAll, lines, these[0], checkNames, names, chkHighlightData.Checked, drawThese); }
                            }
                        }
                    }
                }
                else
                {
                    foreach (TreeNode n in thisNode.Nodes)
                    {
                        if (n.Checked == true)
                        {
                            string key = (string)n.Tag;
                            if (selectedData.ContainsKey(key) == true)
                            {
                                term t = selectedData[key];
                                if (t.HasFilteredDataInTree == true)
                                { y = drawTermNode(g, n, y, cutOff, level, myY, myX, terms, font, Yoffset, drawFiltered, endent, dontDrawAll, lines, these[0], checkNames, names, chkHighlightData.Checked, drawThese); }
                            }
                        }
                    }
                }
            }


            return y;
        }

        private string[] cutLabel(Graphics g, Font f, string text, int labelWidth, int offset)
        {
            string[] items = text.Split(' ');
            string[] answer = { "", "" };
            if (items.Length > 2)
            {
                int index = 0;
                while ((int)g.MeasureString(answer[0] + items[index], f).Width + offset < labelWidth)
                {
                    answer[0] += items[index] + " ";
                    index++;
                }

                while (index < items.Length)
                {
                    answer[1] += items[index] + " ";
                    index++;
                }
            }
            return answer;
        }

        private Size getImageSize(int sampleCount, int labelWidth, Font font)
        {
            int graphWidth = (int)nupSaveWidth.Value;
            int width = labelWidth + (sampleCount * (graphWidth + 10));
            int heigth = getScreenHeigth(font, drawFilteredData) + 40;
            if (heigth > 32000) { heigth = 32000; }
            return new Size(width, heigth);
        }
        private int getScreenHeigth(Font font, bool drawFilteredData)
        {
            int level = 1;
            int y = 31;
            foreach (TreeNode n in tn_selectedNode.Nodes)
            {
                if (n.Checked == true)
                { y += getHeigth(n, y, level, font, drawFilteredData, chkEndent.Checked, chkJustLabelsWithData.Checked); }
            }
            return y;
        }

        private int getHeigth(TreeNode thisNode, int y, int level, Font font, bool drawFilteredData, bool endent, bool dontDrawAll)
        {
            if (endent == false) { level = 0; }

            if (thisNode.Checked == true)
            {
                string star = "";
                if (dontDrawAll == false) { star = " *"; }

                //y += 24;
                level++;

                string key = (string)thisNode.Tag;
                if (string.IsNullOrEmpty(key) == false && selectedData.ContainsKey(key) == false)
                { return y; }
                term thisTerm = selectedData[key];

                if (thisTerm.getDataCount > 0 && thisTerm.Hidden == false)
                {
                    y += 24;
                    SizeF length = g.MeasureString(thisTerm.Name + star, font);
                    if ((int)length.Width + (level * 10) + 3 > labelWidth)
                    { y += 8; }
                }
                else if (dontDrawAll == false && thisTerm.Hidden == false)
                {
                    y += 24;
                    SizeF length = g.MeasureString(thisTerm.Name, font);
                    if ((int)length.Width + (level * 10) + 3 > labelWidth)
                    { y += 8; }
                }
                //else
                //{ y -= 24; }

                foreach (TreeNode n in thisNode.Nodes)
                {
                    if (n.Text != "dummy")
                    {
                        key = (string)n.Tag;
                        if (selectedData.ContainsKey(key) == false)
                        { return y; }
                        term t = selectedData[key];

                        if (t.HasDataInTree == true && n.Checked == true)
                        {
                            if (drawFilteredData == true && thisTerm.HasFilteredDataInTree)
                            { y = getHeigth(n, y, level, font, drawFilteredData, endent, dontDrawAll); }
                            else if (drawFilteredData == false)
                            { y = getHeigth(n, y, level, font, drawFilteredData, endent, dontDrawAll); }
                        }
                    }
                }
            }
            return y;
        }

        public void DrawImage()
        {
            try
            {
                if (iv.WindowState == FormWindowState.Minimized)
                { iv.WindowState = FormWindowState.Normal; }
                else if (iv != null)
                {
                    try
                    { iv.Show(); }
                    catch
                    {
                        iv = new ImageViewer(this);
                        iv.Show();
                    }
                }
                DrawImage(drawFilteredData);
                SetScrollbarValuse();

            }
            catch
            { }
        }

        public void DrawImage(bool drawFiltered)
        {
            if (iv.WindowState != FormWindowState.Minimized)
            {
                Font f = new Font(FontFamily.GenericSerif, 12);

                int newHeigth = getHeigth(tn_selectedNode, 0, 0, f, drawFilteredData, chkEndent.Checked, chkJustLabelsWithData.Checked);
                if (topOffP1Image > newHeigth)
                {
                    SetScrollbarValuse();
                    topOffP1Image = newHeigth - iv.P1.Height;
                    if (topOffP1Image < 0) { topOffP1Image = 0; }
                }

                iv.P1.Image = SortDrawingsArea(iv.P1.Size, labelWidth, selectedData, f, topOffP1Image, drawFiltered, chkEndent.Checked, chkJustLabelsWithData.Checked, chkHighlightData.Checked, chkDEG.Checked, false);
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            string saveToo = FileAccessClass.FileString(FileAccessClass.FileJob.SaveAs, "Save image as", "Image file (*.png)|*.png");
            if (saveToo.Equals("Cancel") == true) { return; }
            int realTop = topOffP1Image;
            try
            {
                topOffP1Image = 0;
                Font f = new Font(FontFamily.GenericSerif, 12);
                Size area = getImageSize(numberOfSamples, labelWidth, f);
                area.Height += 30;
                SortDrawingsArea(area, labelWidth, selectedData, f, 0, drawFilteredData, chkEndent.Checked, chkJustLabelsWithData.Checked, chkHighlightData.Checked, chkDEG.Checked, true).Save(saveToo);
            }
            finally
            { topOffP1Image = realTop; }
        }

        private void nupLabelWidth_ValueChanged(object sender, EventArgs e)
        {
            labelWidth = (int)nupLabelWidth.Value;
            StartDrawTimer();
        }

        private void StartDrawTimer()
        {
            tvCheckedTimer = true;
            tTVclick.Enabled = true;
        }

        private void tTVclick_Tick(object sender, EventArgs e)
        {
            if (tvCheckedTimer == true)
            { tvCheckedTimer = false; }
            else
            {
                DrawImage(drawFilteredData);
                SetScrollbarValuse();
                tTVclick.Enabled = false;
            }
        }

        public void vsbP1_Scroll(object sender, ScrollEventArgs e)
        {
            tScrollReDraw.Interval = 25;
            scrolling = true;
            tScrollReDraw.Enabled = true;
        }

        private void tScrollReDraw_Tick(object sender, EventArgs e)
        {
            if (scrolling == true)
            { scrolling = false; }
            else
            {
                tScrollReDraw.Enabled = false;
                topOffP1Image = iv.VSBP1.Value;
                DrawImage(drawFilteredData);
            }
        }

        private void chkpValueBinaryColours_CheckedChanged(object sender, EventArgs e)
        {
            StartDrawTimer();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            orderFiles of = new orderFiles(samplesOriginal, editedNames);

            if (of.ShowDialog() == DialogResult.OK)
            {
                List<string> tSamples = of.FileList;
                editedNames = of.getEditedNames;

                if (tSamples.Count == 0) { return; }
                samples = tSamples;
                StartDrawTimer();
            }
        }

        private void btnExportSelectedGOTerms_Click(object sender, EventArgs e)
        {
            string saveToo = FileAccessClass.FileString(FileAccessClass.FileJob.SaveAs, "Enter the name of the file to save the data too", "Text file (*.txt)|*.txt");
            if (saveToo.Equals("Cancel") == true) { return; }

            System.IO.StreamWriter fw = null;
            try
            {

                List<string> theList = new List<string>();
                foreach (TreeNode n in tv.Nodes)
                {
                    if (n.Checked == true)
                    { theList = exportSelectedPath(n, theList, n.Text); }
                }

                if (theList.Count > 0)
                {
                    fw = new System.IO.StreamWriter(saveToo);
                    if (theList.Count > 0)
                    {
                        foreach (string id in theList)
                        { fw.WriteLine(id); }
                    }
                    else
                    { MessageBox.Show("No nodes have been selected", "No data", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                }
            }
            catch
            { }
            finally
            { if (fw != null) { fw.Close(); } }
        }

        private List<string> exportSelectedPath(TreeNode n, List<string> answers, string thisAnswer)
        {
            if (n.Checked == true)
            {
                if (n.Nodes.Count > 0)
                {
                    bool added = false;
                    foreach (TreeNode c in n.Nodes)
                    {
                        if (c.Checked == true)
                        {
                            if (c.SelectedImageIndex > 2)
                            { answers = exportSelectedPath(c, answers, "#" + c.Text + " <- " + thisAnswer); }
                            else
                            { answers = exportSelectedPath(c, answers, c.Text + " <- " + thisAnswer); }
                            added = true;
                        }
                    }
                    if (added == false)
                    {
                        answers.Add(thisAnswer);
                    }
                }
                else if (answers.Contains(thisAnswer) == false)
                { answers.Add(thisAnswer); }
            }

            return answers;
        }

        //private List<string> exportSelectIDs(TreeNode n, List<string> theList)
        //{
        //    if (n.Checked == true)
        //    {
        //        string id = (string)n.Tag;
        //        if (theList.Contains(id) == false)
        //        {
        //            theList.Add(id);
        //            foreach (TreeNode nC in n.Nodes)
        //            { exportSelectIDs(nC, theList); }
        //        }
        //    }
        //    return theList;
        //}

        private void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                resetFilterTermsSimple();

                bool reset = true;

                FilterSamplesSimple fs = new FilterSamplesSimple(samples);
                if (fs.ShowDialog() == DialogResult.OK)
                {
                    List<string> significant = fs.SignificantSampleList;

                    if (significant != null)
                    {

                        filterTermsSimple(biological_process, significant);
                        filterTermsSimple(cellular_component, significant);
                        filterTermsSimple(molecular_function, significant);

                        root_molecular_function.HaveChildrenGotFilteredData(molecular_function);
                        root_biological_process.HaveChildrenGotFilteredData(biological_process);
                        root_cellular_component.HaveChildrenGotFilteredData(cellular_component);

                        DrawImage();

                        rdoFilteredData.Enabled = true;
                        rdoFilteredData.Checked = true;
                        reset = false;
                    }
                }

                if (reset == true)
                {
                    rdoFilteredData.Enabled = false;
                    rdoFilteredData.Checked = false;
                }
            }
            finally
            {

            }
        }

        private void resetFilterTermsSimple()
        {
            resetFilterTermsSimple(biological_process);
            resetFilterTermsSimple(cellular_component);
            resetFilterTermsSimple(molecular_function);
        }

        private void filterTermsSimple(Dictionary<string, term> terms, List<string> significant)
        {
            foreach (term t in terms.Values)
            {
                t.Filter(significant, cutOff);
            }
        }

        private void resetFilterTermsSimple(Dictionary<string, term> terms)
        {
            foreach (term t in terms.Values)
            {
                t.removeFilter();
            }
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (iv.WindowState == FormWindowState.Minimized)
                { iv.WindowState = FormWindowState.Normal; }
                else if (iv != null)
                {
                    try
                    { iv.Show(); }
                    catch
                    {
                        iv = new ImageViewer(this);
                        iv.Show();
                    }
                }
                drawFilteredData = true;
                DrawImage(drawFilteredData);
            }
            catch { }
        }

        private void rdoBP_CheckedChanged(object sender, EventArgs e)
        {
            selectedData = biological_process;
            //root_selectedData = root_biological_process;
            tn_selectedNode = tn_biological_process;
        }

        private void rdoMF_CheckedChanged(object sender, EventArgs e)
        {
            selectedData = molecular_function;
            //root_selectedData = root_molecular_function;
            tn_selectedNode = tn_molecular_function;
        }

        private void rdoCC_CheckedChanged(object sender, EventArgs e)
        {
            selectedData = cellular_component;
            //root_selectedData = root_cellular_component;
            tn_selectedNode = tn_cellular_component;
        }

        private void chkEndent_CheckedChanged(object sender, EventArgs e)
        {
            DrawImage();
        }

        private void chkJustLabelsWithData_CheckedChanged(object sender, EventArgs e)
        {
            chkHighlightData.Enabled = !chkJustLabelsWithData.Checked; //== false;
            DrawImage();
        }

        private void chkNames_CheckedChanged(object sender, EventArgs e)
        {
            DrawImage();
        }

        private void rdoFilteredData_CheckedChanged(object sender, EventArgs e)
        {
            drawFilteredData = rdoFilteredData.Checked;
            DrawImage();
        }

        private void rdoAllData_CheckedChanged(object sender, EventArgs e)
        {
            drawFilteredData = rdoFilteredData.Checked;
            DrawImage();
        }

        private void chkHighlightData_CheckedChanged(object sender, EventArgs e)
        {
            DrawImage();
        }

        private void chkDEG_CheckedChanged(object sender, EventArgs e)
        {
            chkOdds.Checked = !chkDEG.Checked;
            iv.Redraw();
        }

        private void chkOdds_CheckedChanged(object sender, EventArgs e)
        {
            chkDEG.Checked = !chkOdds.Checked;
            iv.Redraw();
        }

        private void tTitle_Tick(object sender, EventArgs e)
        {
            Text = titleText;
            tTitle.Enabled = false;
        }

        private void test()
        {
            if (rdoBoth.Checked == true)
            {
                chkDEG.Enabled = true;
                chkOdds.Enabled = true;
            }
            else if (rdoFoldDiff.Checked == true)
            {
                chkDEG.Checked = false;
                chkDEG.Enabled = false;
                chkOdds.Checked = true;
                chkOdds.Enabled = true;
            }
            else if (rdoOdds.Checked == true)
            {
                chkDEG.Checked = true;
                chkDEG.Enabled = true;
                chkOdds.Checked = false;
                chkOdds.Enabled = false;
            }
            DrawImage();

        }

        private void rdoFoldDiff_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoFoldDiff.Checked == true)
            { test(); }
        }

        private void rdoOdds_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoOdds.Checked == true) { test(); }
        }

        private void rdoBoth_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoBoth.Checked == true) { test(); }
        }

        private void findGOTermToolStripMenuItem_Click(object sender, EventArgs e)
        {
            term tag = selectedData[(string)tn_selectedNode.Tag];

            FindGOTerm FGOT = new FindGOTerm(selectedData, tag);
            if (FGOT.ShowDialog() == DialogResult.OK)
            {
                List<string> answers = FGOT.GetSelectedAnswers;
                foreach (string s in answers)
                {
                    string path = s.Replace(" <- ", "\t");
                    string[] items = path.Split('\t');
                    Array.Reverse(items);
                    tn_selectedNode.Expand();
                    showTerm(items, 1, tn_selectedNode);
                }
            }
        }

        private void showTerm(string[] items, int index, TreeNode node)
        {
            if (node.Nodes.Count > 0)
            {
                foreach (TreeNode n in node.Nodes)
                {
                    bool hide = false;
                    if (items[index].StartsWith("#") == true)
                    {
                        hide = true;
                        items[index] = items[index].Substring(1);
                    }
                    if (n.Text.Equals(items[index]) == true)
                    {
                        n.Expand();
                        if (n.Text.Equals(items[items.Length - 1]) == true)
                        {
                            if (hide == true)
                            {
                                if (n.ImageIndex == 1) { n.ImageIndex = 3; }
                                else if (n.ImageIndex == 2) { n.ImageIndex = 4; }
                            }
                            else
                            {
                                if (n.ImageIndex == 3) { n.ImageIndex = 1; }
                                else if (n.ImageIndex == 4) { n.ImageIndex = 2; }
                            }
                            n.Checked = true;
                            n.SelectedImageIndex = n.ImageIndex;
                        }
                        else
                        {
                            if (hide == true)
                            {
                                if (n.ImageIndex == 1) { n.ImageIndex = 3; }
                                else if (n.ImageIndex == 2) { n.ImageIndex = 4; }
                            }
                            else
                            {
                                if (n.ImageIndex == 3) { n.ImageIndex = 1; }
                                else if (n.ImageIndex == 4) { n.ImageIndex = 2; }
                            }
                            showTerm(items, index + 1, n);
                        }
                    }
                }
            }
            else
            {
                if (node.Text.Equals(items[items.Length - 1]) == true)
                { node.Checked = true; }
            }

        }

        private void tv_MouseUp(object sender, MouseEventArgs e)
        {
            return;
            if (e.Button == MouseButtons.Right)
            {
                bool showMenus = tv.SelectedNode != null;

                moveTermDownToolStripMenuItem.Enabled = showMenus;
                moveTermUpToolStripMenuItem.Enabled = showMenus;
                hideunhideTermsDataToolStripMenuItem.Enabled = showMenus;

                cmFind.Show();

            }
        }

        private void findCommonPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            term tag = selectedData[(string)tn_selectedNode.Tag];

            BestCommonPath BCP = new BestCommonPath(selectedData, tag);
            if (BCP.ShowDialog() == DialogResult.OK)
            {
                List<string> answers = BCP.GetSelectedAnswers;
                foreach (string s in answers)
                {
                    string path = s.Replace(" <- ", "\t");
                    string[] items = path.Split('\t');
                    Array.Reverse(items);
                    tn_selectedNode.Expand();
                    showTerm(items, 1, tn_selectedNode);
                }
            }
        }

        private void moveTermUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tv.SelectedNode == null) { return; }

            TreeNode n = tv.SelectedNode;
            TreeNode p = n.Parent;

            if (p == null) { return; }

            List<string> paths = new List<string>();
            paths = getPathsFromNode(n, paths);

            int place = 0;
            for (int index = 0; index < p.Nodes.Count; index++)
            {
                if (n.Text == p.Nodes[index].Text)
                {
                    place = index;
                    index = p.Nodes.Count;
                }
            }
            if (place == 0) { return; }

            tv.BeginUpdate();
            n.Remove();
            p.Nodes.Insert(place - 1, n);
            tv.SelectedNode = n;
            activateSelectedNodesInMovedNode(n, paths);
            n.EnsureVisible();
            tv.EndUpdate();
            StartDrawTimer();
        }

        private void moveTermDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tv.SelectedNode == null) { return; }

            TreeNode n = tv.SelectedNode;
            TreeNode p = n.Parent;

            if (p == null) { return; }

            List<string> paths = new List<string>();
            paths = getPathsFromNode(n, paths);

            int place = 0;
            for (int index = 0; index < p.Nodes.Count; index++)
            {
                if (n.Text == p.Nodes[index].Text)
                {
                    place = index;
                    index = p.Nodes.Count;
                }
            }
            if (place == p.Nodes.Count - 1) { return; }

            tv.BeginUpdate();
            n.Remove();
            p.Nodes.Insert(place + 1, n);
            tv.SelectedNode = n;
            activateSelectedNodesInMovedNode(n, paths);
            n.EnsureVisible();
            tv.EndUpdate();
            StartDrawTimer();
        }

        private List<string> getPathsFromNode(TreeNode node, List<string> list)
        {
            list = exportSelectedPath(node, list, node.Text);

            return list;
        }

        private void activateSelectedNodesInMovedNode(TreeNode n, List<string> paths)
        {
            foreach (string s in paths)
            {
                string path = s.Replace(" <- ", "\t");
                string[] items = path.Split('\t');
                Array.Reverse(items);
                showTerm(items, 1, n);
            }
        }

        private void hideUnhideTermsDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tv.SelectedNode == null) { return; }
            TreeNode n = tv.SelectedNode;
            term t = selectedData[(string)n.Tag];

            t.Hide_Unhide();

            if (t.Hidden == true)
            {
                if (n.ImageIndex == 2)
                { n.ImageIndex = 4; }
                else if (n.ImageIndex == 1)
                { n.ImageIndex = 3; }
            }
            else
            {
                if (n.ImageIndex == 4)
                { n.ImageIndex = 2; }
                else if (n.ImageIndex == 3)
                { n.ImageIndex = 1; }
            }
            n.SelectedImageIndex = n.ImageIndex;
            tTVclick.Enabled = true;
        }

        private void tv_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            bool showMenus = tv.SelectedNode != null;

            moveTermDownToolStripMenuItem.Enabled = showMenus;
            moveTermUpToolStripMenuItem.Enabled = showMenus;
            hideunhideTermsDataToolStripMenuItem.Enabled = showMenus;

            cmFind.Show();
        }
    }
}