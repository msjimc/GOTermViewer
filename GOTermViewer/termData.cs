using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOTermViewer
{
    public class termData
    {
        private readonly double pValue = 1;
        private readonly double oddsRatio = 1;
        private readonly double expCount = -1;
        private readonly int count = -1;
        private readonly int size = -1;
        private readonly string file = "";
        private readonly bool isGood = false;

        private Point[] up = { new Point(8, 0), new Point(0, 16), new Point(16, 16) };
        private Point[] down = { new Point(8, 16), new Point(0, 0), new Point(16, 0) };

        public termData(string data, string fileName)
        {

            string[] items = data.Split('\t');
            if (items.Length > 7)
            {
                try
                {
                    pValue = Convert.ToDouble(items[2]);
                    if (items[3].ToLower().Equals("inf") == true)
                    { oddsRatio = double.MaxValue; }
                    else if (items[3].ToLower().Equals("na") == true)
                    { oddsRatio = 1; }
                    else { oddsRatio = Convert.ToDouble(items[3]); }
                    expCount = Convert.ToDouble(items[4]);
                    count = Convert.ToInt32(items[5]);
                    size = Convert.ToInt32(items[6]);

                    file = fileName;
                    isGood = true;
                }
                catch
                { isGood = false; }
            }
        }

        public void DrawData(Graphics g, Rectangle region, int Y, double cutOff, int drawThese, bool justValues)
        {
            if (expCount < count)
            { DrawDataOver(g, region, Y, cutOff, drawThese, justValues); }
            else
            { DrawDataUnder(g, region, Y, cutOff, drawThese, justValues); }
        }

        public void DrawDataOver(Graphics g, Rectangle region, int Y, double cutOff, int drawThese, bool justValues)
        {           
            float place;
            float oddsScale = (float)(region.Width - 16) / 25;
            if (oddsRatio > 25)
            { place = region.Right - 17; }
            else
            { place = (float)(oddsScale * oddsRatio) + region.X + 1; }

            float exp = ((region.Width - 2) / 2.0f);
            float foldeChangeScale = exp / 9;
            exp += 1;
            float foldChange = ((float)count / (float)expCount) - 1;
            if (foldChange > 9) { foldChange = 9; }
            float obs = exp + (foldeChangeScale * foldChange);
            if (float.IsNaN(obs) == true) { obs = 1; }

            if (justValues == false)
            {
                if (cutOff > pValue)
                {
                    if (drawThese != 1)
                    {
                        Point[] triangle = { new Point(up[0].X + (int)place, up[0].Y + Y + 2), new Point(up[1].X + (int)place, up[1].Y + Y + 2), new Point(up[2].X + (int)place, up[2].Y + Y + 2) };
                        g.FillPolygon(Brushes.Green, triangle);
                    }

                    if (drawThese != 2)
                    {
                        Pen pBlack = new Pen(Color.Black, 2);
                        Pen pRed = new Pen(Color.Red, 2);

                        g.DrawLine(pBlack, region.X + exp, Y, region.X + exp, Y + 16 + 4);
                        g.DrawLine(pRed, region.X + obs, Y, region.X + obs, Y + 16 + 4);
                        g.DrawLine(Pens.Black, region.X + obs, Y + 8 + 2, region.X + exp, Y + 8 + 2);
                    }
                }
                else
                {
                    if (drawThese != 1)
                    {
                        Point[] triangle = { new Point(up[0].X + (int)place, up[0].Y + Y + 2), new Point(up[1].X + (int)place, up[1].Y + Y + 2), new Point(up[2].X + (int)place, up[2].Y + Y + 2) };
                        g.FillPolygon(Brushes.Pink, triangle);
                    }

                    if (drawThese != 2)
                    {
                        Pen pGray = new Pen(Color.Gray, 2);
                        Pen pPink = new Pen(Color.Pink, 2);

                        g.DrawLine(pGray, region.X + exp, Y, region.X + exp, Y + 16 + 4);
                        g.DrawLine(pPink, region.X + obs, Y, region.X + obs, Y + 16 + 4);
                        g.DrawLine(Pens.Gray, region.X + obs, Y + 8 + 2, region.X + exp, Y + 8 + 2);
                    }
                }
            }
            else
            {
                if (oddsRatio > 99)
                { g.DrawString("OR >99, p " + pValue.ToString("0.##") + ", O " + count.ToString() + ", E " + expCount.ToString("0.#"), new Font(FontFamily.GenericSerif, 10), Brushes.Black, region.X + 1, Y); }
                else
                { g.DrawString("OR " + oddsRatio.ToString("0.##") + ", p " + pValue.ToString("0.##") + ", O " + count.ToString() + ", E " + expCount.ToString("0.#"), new Font(FontFamily.GenericSerif, 10), Brushes.Black, region.X + 1, Y ); }
            }
        }

        public void DrawDataUnder(Graphics g, Rectangle region, int Y, double cutOff, int drawThese, bool justValues)
        {
            Brush b;

            if (pValue > cutOff) { b = Brushes.Red; }
            else { b = Brushes.Green; }

            double localOddsRatio;
            if (expCount < count)
            { localOddsRatio = oddsRatio; }
            else
            {
                if (oddsRatio != 0)
                { localOddsRatio = 1 / oddsRatio; }
                else
                { localOddsRatio = 0; }
            }

            float place;
            float oddsScale = (float)(region.Width - 16) / 25;
            if (oddsRatio > 25)
            { place = region.Right - 17; }
            else
            { place = (float)(oddsScale * localOddsRatio) + region.X + 1; }


            float exp = ((region.Width - 2) / 2.0f) + 1;
            float foldeChangeScale = exp / 9;
            exp += 1;
            float foldChange = ((float)expCount / (float)count) - 1;

            if (foldChange > 9) { foldChange = 9; }

            float obs = exp - (foldeChangeScale * foldChange);
            if (float.IsNaN(obs) == true) { obs = 1; }
            //if (expCount < 1) { obs = exp -1; }

            if (justValues == false)
            {
                if (cutOff > pValue)
                {
                    if (drawThese != 1)
                    {
                        Point[] triangle = { new Point(down[0].X + (int)place, down[0].Y + Y + 2), new Point(down[1].X + (int)place, down[1].Y + Y + 2), new Point(down[2].X + (int)place, down[2].Y + Y + 2) };
                        g.FillPolygon(Brushes.Green, triangle);
                    }

                    if (drawThese != 2)
                    {
                        Pen pBlack = new Pen(Color.Black, 2);
                        Pen pRed = new Pen(Color.Red, 2);

                        g.DrawLine(pBlack, region.X + exp, Y, region.X + exp, Y + 16 + 4);
                        g.DrawLine(pRed, region.X + obs, Y, region.X + obs, Y + 16 + 4);
                        g.DrawLine(Pens.Black, region.X + obs, Y + 8 + 2, region.X + exp, Y + 8 + 2);
                    }
                }
                else
                {
                    if (drawThese != 1)
                    {
                        Point[] triangle = { new Point(down[0].X + (int)place, down[0].Y + Y + 2), new Point(down[1].X + (int)place, down[1].Y + Y + 2), new Point(down[2].X + (int)place, down[2].Y + Y + 2) };
                        g.FillPolygon(Brushes.Pink, triangle);
                    }
                }

                if (drawThese != 2)
                {
                    Pen pGray = new Pen(Color.Gray, 2);
                    Pen pPink = new Pen(Color.Pink, 2);
                    Pen pPalePink = new Pen(Color.LightPink, 2);

                    g.DrawLine(pGray, region.X + exp, Y, region.X + exp, Y + 16 + 4);
                    g.DrawLine(pPink, region.X + obs, Y, region.X + obs, Y + 16 + 4);
                    g.DrawLine(Pens.Gray, region.X + obs, Y + 8 + 2, region.X + exp, Y + 8 + 2);

                }
            }
            else
            {
                if (oddsRatio > 99)
                { g.DrawString("OR >99, p " + pValue.ToString("0.##") + ", O " + count.ToString() + ", E " + expCount.ToString("0.#"), new Font(FontFamily.GenericSerif, 10), Brushes.Black, region.X + 1, Y); }
                else
                { g.DrawString("OR " + oddsRatio.ToString("0.##") + ", p " + pValue.ToString("0.##") + ", O " + count.ToString() + ", E " + expCount.ToString("0.#"), new Font(FontFamily.GenericSerif, 10), Brushes.Black, region.X + 1, Y); }
            }
        }  

        public bool IsGood { get { return isGood; } }
        public double GetPValue { get { return pValue; } }
        public double GetOddsRatio { get { return oddsRatio; } }
        public double GetExpCount { get { return expCount; } }
        public int GetCount { get { return count; } }
        public int GetSize { get { return size; } }
        public string GetFilename { get { return file; } }
    }
}