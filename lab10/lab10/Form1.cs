using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accord.Imaging;
using Accord.Imaging.Filters;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;

namespace lab10
{
    public partial class Form1 : Form
    {
        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bmp = (Bitmap)pictureBox1.Image;

            /*
            double sigma = 5;
            int kernel = 15;
            */
            int[,] kernel =
            {
                {0, -1, 0},
                {-1, 5, -1},
                {0, -1, 0}
            };

            IFilter filter = new Convolution(kernel);
            pictureBox1.Image = filter.Apply(bmp);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap bmp = (Bitmap)pictureBox1.Image;

            IFilter brightness = new BrightnessCorrection(Convert.ToInt32(textBox1.Text));
            
            pictureBox1.Image = brightness.Apply(bmp);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Bitmap bmp = (Bitmap)pictureBox1.Image;

            IFilter contrast = new ContrastCorrection(Convert.ToInt32(textBox2.Text));

            pictureBox1.Image = contrast.Apply(bmp);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Bitmap bmp = (Bitmap)pictureBox1.Image;
            int w = Convert.ToInt32(textBox3.Text);
            int h = Convert.ToInt32(textBox4.Text);
            if (w>0 && h>0) pictureBox1.Image = resizeImage(pictureBox1.Image, new Size(w, h));
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Bitmap bmp = (Bitmap)pictureBox1.Image;

            int[,] kernel = 
                {
                    { -1,  -1,  -1 },
                    { -1,   9,  -1 },
                    { -1,  -1,  -1 } 
                };

            IFilter filter = new Convolution(kernel);

            pictureBox1.Image = filter.Apply(bmp);

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Bitmap bmp = (Bitmap)pictureBox1.Image;
            Grayscale filter = new Grayscale(0.2125, 0.7154, 0.0721);
            Bitmap grayImage = filter.Apply(bmp);
            Threshold filter2 = new Threshold(50);


            pictureBox1.Image = filter2.Apply(grayImage);

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
