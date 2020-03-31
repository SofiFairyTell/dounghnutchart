using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace VP_LW_5
{
    public partial class Form_1 : Form
    {
        public Bitmap Draws(Color bgCol,decimal[] vals)
            {
            //pictureBox1.Width = width;
            //pictureBox1.Height = height;
           Bitmap mybit = new Bitmap(pictureBox1.Width, pictureBox1.Height, PixelFormat.Format32bppArgb);
                Graphics graphics = Graphics.FromImage(mybit);
                SolidBrush brush = new SolidBrush(bgCol);
                graphics.FillRectangle(brush, 0, 0, pictureBox1.Width, pictureBox1.Height);
                brush.Dispose();
                SolidBrush[] brush2 = new SolidBrush[2];
                brush2[0] = new SolidBrush(Color.Green);
                brush2[1] = new SolidBrush(Color.Gray);
                decimal all = 0.0m;
                foreach (decimal val in vals) all += val;
                float startZ = 0.0f;
                float endZ = 0.0f;
                decimal current = 0.0m;
                for (int i=0; i<vals.Length;i++)
                {
                    current += vals[i];
                    startZ = endZ;
                    endZ = (float)(current / all) * 360.0f;
                    graphics.FillPie(brush2[i % 10], 0.0f, 0.0f, pictureBox1.Width, pictureBox1.Height, startZ, endZ - startZ);
                }

                foreach (SolidBrush cleanBrush in brush2) cleanBrush.Dispose();
                return mybit;            
            }
        public Form_1()
        {
            InitializeComponent();
            Draw();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics graph = Graphics.FromImage(bmp);
            Pen pen = new Pen(Color.Green);
            graph.DrawLine(pen, 10, 50, 150, 200);
            pictureBox1.Image = bmp;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Color myColor = Color.FromArgb(255, 255, 255);
            decimal[] vals = { 75, 25 };
            Bitmap myBitmap = Draws(myColor,vals);
            //Graphics g = e.Graphics;
            Graphics g = Graphics.FromHwnd(this.Handle);
            g.DrawImage(myBitmap,5,5);
        }
    }
}
