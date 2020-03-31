using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace PV_5
{
    public partial class Form1 : Form
    {
        private DataGridView dataGridView1;
        private Button button1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private PictureBox pictureBox1;

        public Form1()
        {
            InitializeComponent();
        }

        private void DataGridViewInitialize() // Making our DataGrid
        {
            dataGridView1.ColumnCount = 3; // Column Count
            DataGridViewCellStyle columnStyle = new DataGridViewCellStyle(); // Defining new cell style
            columnStyle.BackColor = Color.Azure;
            columnStyle.Font = new Font("Arial", 12, FontStyle.Italic);
            dataGridView1.Columns[0].Name = "Chart 1";
            dataGridView1.Columns[1].Name = "Chart 2";
            dataGridView1.Columns[2].Name = "Chart 3";
            // Defining rows
            string[] row1 = new string[] { "0" };
            string[] row2 = new string[] { "0" };
            string[] row3 = new string[] { "0" };
            object[] rows = new object[] { row1, row2, row3 }; // Storing all rows inside of an array
            //Adding rows
            foreach (string[] rowArray in rows)
            { dataGridView1.Rows.Add(rowArray); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DrawGraph();
        }
        private void DrawGraph()
        {
            Bitmap art = new Bitmap(pictureBox1.Width, pictureBox1.Height,System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics graph = Graphics.FromImage(art);

                
            Rectangle rec = new Rectangle(pictureBox1.Location.X-310, pictureBox1.Location.Y, pictureBox1.Size.Width-100, pictureBox1.Size.Height-100);
            Rectangle rec2 = new Rectangle(pictureBox1.Location.X-260, pictureBox1.Location.Y+55, pictureBox1.Size.Width-200, pictureBox1.Size.Height-200);
            Rectangle rec3 = new Rectangle(pictureBox1.Location.X - 210, pictureBox1.Location.Y + 110, pictureBox1.Size.Width - 300, pictureBox1.Size.Height - 300);


            Pen pen = new Pen(Color.Black, 2);
            Pen pen2 = new Pen(Color.Yellow, 6);
            Brush b1 = new SolidBrush(Color.Red);
            Brush b2 = new SolidBrush(Color.Green);
            Brush b3 = new SolidBrush(Color.Bisque);
            Brush b4 = new SolidBrush(Color.White);

            double dot1 = Convert.ToDouble(this.dataGridView1["Column1", 0].Value);
            double dot2 = Convert.ToDouble(this.dataGridView1["Column1", 1].Value);

            double dot12 = Convert.ToDouble(this.dataGridView1["Column2", 0].Value);
            double dot22 = Convert.ToDouble(this.dataGridView1["Column2", 1].Value);
            

            //degree for first donut 
            float total1 = (float)(dot1 + dot2);
            float deg1 = (float)(dot1 / total1) * 360;
            float deg2 = (float)(dot2 / total1) * 360;

            //degree for second donut 
            float total2 = (float)(dot12 + dot22);
            float deg3 = (float)(dot12 / total2) * 360;
            float deg4 = (float)(dot22 / total2) * 360;

            TextureBrush myart = new TextureBrush(art);

            //Drawing itself
            graph.DrawEllipse(pen, rec);
           
            graph.DrawPie(pen, rec, 0, deg1);
            graph.FillPie(b1, rec, 0, deg1);

            graph.DrawPie(pen, rec, deg1, deg2);
            graph.FillPie(b2, rec, deg1, deg2);

            graph.DrawPie(pen, rec2, 0, deg3);
            graph.FillPie(b2, rec2, 0, deg3);

            graph.DrawPie(pen, rec2, deg3, deg4);
            graph.FillPie(b3, rec2, deg3, deg4);

            //center white ellipse
            graph.DrawEllipse(pen2, rec3);
            graph.FillEllipse(b4, rec3);

            pictureBox1.Image = art;

        }

        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Location = new System.Drawing.Point(310, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(461, 461);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridView1.Location = new System.Drawing.Point(13, 13);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(243, 150);
            this.dataGridView1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(75, 212);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 52);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(771, 461);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DrawGraph();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }

}
