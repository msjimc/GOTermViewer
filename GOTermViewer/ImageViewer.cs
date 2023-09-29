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
    public partial class ImageViewer : Form
    {
        private bool resizing = false;
        private Form1 source = null;
        private bool starting = true;
        public ImageViewer(Form1 Source)
        {
            InitializeComponent();

            vsbP1.Maximum = 1;
            source = Source;
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        public PictureBox P1
        {
            get { return p1; }
            set { p1 = value; }
        }

        public VScrollBar VSBP1
        {
            get { return vsbP1; }
            set { vsbP1 = value; }
        }

        private void vsbP1_Scroll(object sender, ScrollEventArgs e)
        {
            if (starting == false)
            { source.vsbP1_Scroll(sender, e); }
        }

        private void ImageViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            WindowState = FormWindowState.Minimized;
        }

        private void ImageViewer_Resize(object sender, EventArgs e)
        {
            resizing = true;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (starting == true && WindowState == FormWindowState.Normal)
            {
                timer1.Enabled = false;
                starting = false;
            }
            else if (resizing == true)
            { resizing = false; }
            else
            {
                starting = false;
                timer1.Stop();
                if (WindowState != FormWindowState.Minimized || source == null)
                { source.DrawImage(); }
            }
        }

        public void Redraw()
        {
            resizing = true;
            timer1.Start();
        }

        private void p1_Click(object sender, EventArgs e)
        {
            source.ShowFoldChangeValues();
        }
    }
}