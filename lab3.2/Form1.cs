using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace lab3._2
{
    public partial class Form1 : Form
    {
        private Bitmap img;
        private int availableThreads;

        public Form1()
        {
            InitializeComponent();
            availableThreads = Environment.ProcessorCount;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;
                img = new Bitmap(file);
                pictureBox1.Image = img;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (img != null)
            {
                Bitmap negatywImg = new Bitmap(img);
                Bitmap greyImg = new Bitmap(img);
                Bitmap blackwhiteImg = new Bitmap(img);
                Bitmap blurImg = new Bitmap(img);

                // creat thread for all filtrs
                Thread negatywThread = new Thread(() => Negatyw.Apply(negatywImg));
                Thread greyThread = new Thread(() => Grey.Apply(greyImg));
                Thread blackwhiteThread = new Thread(() => BlackWhite.Apply(blackwhiteImg));
                Thread blurThread = new Thread(() => Blurr.Apply(blurImg));

                // start threads
                negatywThread.Start();
                greyThread.Start();
                blackwhiteThread.Start();
                blurThread.Start();

                // waiting for threads 
                negatywThread.Join();
                greyThread.Join();
                blackwhiteThread.Join();
                blurThread.Join();

                // show picture
                pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox2.Image = negatywImg;
                pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox3.Image = greyImg;
                pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox4.Image = blackwhiteImg;
                pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox5.Image = blurImg;
            }
        }

        
    }
}
