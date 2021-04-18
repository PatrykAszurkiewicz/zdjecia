using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zdjecie
{
    public partial class Form1 : Form
    {
        int width;
        int height;

        Bitmap bitmap;
        Bitmap bitmap1;
        Bitmap bitmap3;
        Bitmap bitmap4;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == openFileDialog1.ShowDialog())
            {
                bitmap = (Bitmap)Bitmap.FromFile(openFileDialog1.FileName);
                pictureBox1.Image = bitmap;

                width = pictureBox1.Image.Width;
                height = pictureBox1.Image.Height;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Images|*.png;*.bmp;*.jpg";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(sfd.FileName);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color p = bitmap.GetPixel(x, y);

                    int r = p.R;
                    int g = p.G;
                    int b = p.B;

                    r = 255 - r;
                    g = 255 - g;
                    b = 255 - b;

                    bitmap.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }

            pictureBox1.Image = bitmap;
        }
        private void button20_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void JasnoMi()
        {

            Bitmap bitmap2;
            try
            {
                bitmap2 = (Bitmap)bitmap.Clone();
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {

                        Color p = bitmap2.GetPixel(x, y);

                        // int a = p.A;
                        double r = (double)p.R;
                        double g = (double)p.G;
                        double b = (double)p.B;

                        if ((((double)trackBar2.Value / 10) * r) + trackBar1.Value > 255)
                        {
                            r = 255;
                        }
                        else if ((((double)trackBar2.Value / 10) * r) + trackBar1.Value < 0)
                        {
                            r = 0;
                        }
                        else
                        {
                            r = (((double)trackBar2.Value / 10) * r) + trackBar1.Value;
                        }
                        if ((((double)trackBar2.Value / 10) * g) + trackBar1.Value > 255)
                        {
                            g = 255;
                        }
                        else if ((((double)trackBar2.Value / 10) * g) + trackBar1.Value < 0)
                        {
                            g = 0;
                        }
                        else
                        {
                            g = (((double)trackBar2.Value / 10) * g) + trackBar1.Value;
                        }
                        if ((((double)trackBar2.Value / 10) * b) + trackBar1.Value > 255)
                        {
                            b = 255;
                        }
                        else if ((((double)trackBar2.Value / 10) * b) + trackBar1.Value < 0)
                        {
                            b = 0;
                        }
                        else
                        {
                            b = (((double)trackBar2.Value / 10) * b) + trackBar1.Value;
                        }
                        bitmap2.SetPixel(x, y, Color.FromArgb((int)r, (int)g, (int)b));
                    }
                }

                pictureBox1.Image = bitmap2;
            }
            catch (Exception e)
            {
                MessageBox.Show("Obrazek nie został załadowany");
            }
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            JasnoMi();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            JasnoMi();
        }
        private void TransformacjaPotegowa()
        {
            Bitmap bitmap3;
            try
            {
                bitmap3 = (Bitmap)bitmap.Clone();
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {

                        Color p = bitmap3.GetPixel(x, y);


                        double r = (double)p.R / 255;
                        double g = (double)p.G / 255;
                        double b = (double)p.B / 255;

                        r = ((double)(trackBar4.Value) / 10) * (Math.Pow(r, ((double)(trackBar3.Value) / 10)));
                        g = ((double)(trackBar4.Value) / 10) * (Math.Pow(g, ((double)(trackBar3.Value) / 10)));
                        b = ((double)(trackBar4.Value) / 10) * (Math.Pow(b, ((double)(trackBar3.Value) / 10)));

                        r = r * 255;
                        g = g * 255;
                        b = b * 255;

                        if (r > 255)
                        {
                            r = 255;
                        }
                        if (r < 0)
                        {
                            r = 0;
                        }

                        if (g > 255)
                        {
                            g = 255;
                        }
                        if (g < 0)
                        {
                            g = 0;
                        }

                        if (b > 255)
                        {
                            b = 255;
                        }
                        if (b < 0)
                        {
                            b = 0;
                        }

                        bitmap3.SetPixel(x, y, Color.FromArgb((int)r, (int)g, (int)b));
                    }
                }

                pictureBox1.Image = bitmap3;
            }
            catch (Exception e)
            {
                MessageBox.Show("Obrazek nie został załadowany");
            }
        }
        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            TransformacjaPotegowa();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            TransformacjaPotegowa();
        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            try
            {
                int w = 0, h = 0;
                if (bitmap1.Width > bitmap3.Width)
                {
                    w = bitmap3.Width;
                }
                else
                {
                    w = bitmap1.Width;
                }

                if (bitmap1.Height > bitmap3.Height)
                {
                    h = bitmap3.Height;
                }
                else
                {
                    h = bitmap1.Height;
                }
                for (int y = 0; y < h; y++)
                {
                    for (int x = 0; x < w; x++)
                    {
                        Color p1 = bitmap1.GetPixel(x, y);
                        Color p2 = bitmap3.GetPixel(x, y);

                        double r1 = (double)p1.R / 255;
                        double g1 = (double)p1.G / 255;
                        double b1 = (double)p1.B / 255;


                        double r2 = (double)p2.R / 255;
                        double g2 = (double)p2.G / 255;
                        double b2 = (double)p2.B / 255;

                        double r3 = 0.0;
                        r3 = ((1 - (double)(trackBar5.Value) / 10) * r2) + (((double)(trackBar5.Value) / 10) * r1);
                        r3 = r3 * 255;
                        if (r3 > 255)
                        {
                            r3 = 255;
                        }


                        double g3 = 0.0;
                        g3 = ((1 - (double)(trackBar5.Value) / 10) * g2) + (((double)(trackBar5.Value) / 10) * g1);
                        g3 = g3 * 255;
                        if (g3 > 255)
                        {
                            g3 = 255;
                        }

                        double b3 = 0.0;
                        b3 = ((1 - (double)(trackBar5.Value) / 10) * b2) + (((double)(trackBar5.Value) / 10) * b1);
                        b3 = b3 * 255;
                        if (b3 > 255)
                        {
                            b3 = 255;
                        }

                        bitmap4.SetPixel(x, y, Color.FromArgb((int)r3, (int)g3, (int)b3));
                    }
                }
                pictureBox4.Image = bitmap4;
            }
            catch (Exception e1)
            {
                MessageBox.Show("Obrazek nie został załadowany");
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == openFileDialog1.ShowDialog())
            {
                bitmap1 = (Bitmap)Bitmap.FromFile(openFileDialog1.FileName);
                pictureBox2.Image = bitmap1;
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {

            if (DialogResult.OK == openFileDialog1.ShowDialog())
            {
                bitmap3 = (Bitmap)Bitmap.FromFile(openFileDialog1.FileName);
                pictureBox3.Image = bitmap3;
                bitmap4 = (Bitmap)bitmap3.Clone();
                pictureBox4.Image = bitmap4;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int w = 0, h = 0;
                if (bitmap1.Width > bitmap3.Width)
                {
                    w = bitmap3.Width;
                }
                else
                {
                    w = bitmap1.Width;
                }

                if (bitmap1.Height > bitmap3.Height)
                {
                    h = bitmap3.Height;
                }
                else
                {
                    h = bitmap1.Height;
                }
                for (int y = 0; y < h; y++)
                {
                    for (int x = 0; x < w; x++)
                    {
                        Color p1 = bitmap1.GetPixel(x, y);
                        Color p2 = bitmap3.GetPixel(x, y);

                        int r1 = p1.R;
                        int g1 = p1.G;
                        int b1 = p1.B;

                        int r2 = p2.R;
                        int g2 = p2.G;
                        int b2 = p2.B;

                        int r3 = p1.R + p2.R;
                        if (r3 > 255)
                        {
                            r3 = 255;
                        }
                        int g3 = p1.G + p2.G;
                        if (g3 > 255)
                        {
                            g3 = 255;
                        }
                        int b3 = p1.B + p2.B;
                        if (b3 > 255)
                        {
                            b3 = 255;
                        }

                        bitmap4.SetPixel(x, y, Color.FromArgb(r3, g3, b3));
                    }
                }

                pictureBox4.Image = bitmap4;
            }
            catch (NullReferenceException e1)
            {
                MessageBox.Show("Obrazek nie został załadowany");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int w = 0, h = 0;
                if (bitmap1.Width > bitmap3.Width)
                {
                    w = bitmap3.Width;
                }
                else
                {
                    w = bitmap1.Width;
                }

                if (bitmap1.Height > bitmap3.Height)
                {
                    h = bitmap3.Height;
                }
                else
                {
                    h = bitmap1.Height;
                }
                for (int y = 0; y < h; y++)
                {
                    for (int x = 0; x < w; x++)
                    {
                        Color p1 = bitmap1.GetPixel(x, y);
                        Color p2 = bitmap3.GetPixel(x, y);

                        int r1 = p1.R;
                        int g1 = p1.G;
                        int b1 = p1.B;

                        int r2 = p2.R;
                        int g2 = p2.G;
                        int b2 = p2.B;

                        int r3 = p1.R - p2.R;
                        if (r3 < 0)
                        {
                            r3 = 0;
                        }
                        int g3 = p1.G - p2.G;
                        if (g3 < 0)
                        {
                            g3 = 0;
                        }
                        int b3 = p1.B - p2.B;
                        if (b3 < 0)
                        {
                            b3 = 0;
                        }

                        bitmap4.SetPixel(x, y, Color.FromArgb(r3, g3, b3));
                    }
                }

                pictureBox4.Image = bitmap4;
            }
            catch (Exception e1)
            {
                MessageBox.Show("Obrazek nie został załadowany");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                int w = 0, h = 0;
                if (bitmap1.Width > bitmap3.Width)
                {
                    w = bitmap3.Width;
                }
                else
                {
                    w = bitmap1.Width;
                }

                if (bitmap1.Height > bitmap3.Height)
                {
                    h = bitmap3.Height;
                }
                else
                {
                    h = bitmap1.Height;
                }
                for (int y = 0; y < h; y++)
                {
                    for (int x = 0; x < w; x++)
                    {
                        Color p1 = bitmap1.GetPixel(x, y);
                        Color p2 = bitmap3.GetPixel(x, y);

                        int r1 = p1.R;
                        int g1 = p1.G;
                        int b1 = p1.B;

                        int r2 = p2.R;
                        int g2 = p2.G;
                        int b2 = p2.B;

                        int r3 = Math.Abs(p1.R - p2.R);
                        int g3 = Math.Abs(p1.G - p2.G);
                        int b3 = Math.Abs(p1.B - p2.B);

                        bitmap4.SetPixel(x, y, Color.FromArgb(r3, g3, b3));
                    }
                }

                pictureBox4.Image = bitmap4;
            }
            catch (Exception e1)
            {
                MessageBox.Show("Obrazek nie został załadowany");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                int w = 0, h = 0;
                if (bitmap1.Width > bitmap3.Width)
                {
                    w = bitmap3.Width;
                }
                else
                {
                    w = bitmap1.Width;
                }

                if (bitmap1.Height > bitmap3.Height)
                {
                    h = bitmap3.Height;
                }
                else
                {
                    h = bitmap1.Height;
                }
                for (int y = 0; y < h; y++)
                {
                    for (int x = 0; x < w; x++)
                    {
                        Color p1 = bitmap1.GetPixel(x, y);
                        Color p2 = bitmap3.GetPixel(x, y);

                        double r1 = (double)p1.R / 255;
                        double g1 = (double)p1.G / 255;
                        double b1 = (double)p1.B / 255;

                        double r2 = (double)p2.R / 255;
                        double g2 = (double)p2.G / 255;
                        double b2 = (double)p2.B / 255;


                        int r3 = (int)(r1 * r2 * 255);
                        int g3 = (int)(g1 * g2 * 255);
                        int b3 = (int)(b1 * b2 * 255);


                        bitmap4.SetPixel(x, y, Color.FromArgb(r3, g3, b3));
                    }
                }

                pictureBox4.Image = bitmap4;
            }
            catch (Exception e1)
            {
                MessageBox.Show("Obrazek nie został załadowany");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                int w = 0, h = 0;
                if (bitmap1.Width > bitmap3.Width)
                {
                    w = bitmap3.Width;
                }
                else
                {
                    w = bitmap1.Width;
                }

                if (bitmap1.Height > bitmap3.Height)
                {
                    h = bitmap3.Height;
                }
                else
                {
                    h = bitmap1.Height;
                }
                for (int y = 0; y < h; y++)
                {
                    for (int x = 0; x < w; x++)
                    {
                        Color p1 = bitmap1.GetPixel(x, y);
                        Color p2 = bitmap3.GetPixel(x, y);

                        double r1 = (double)p1.R / 255;
                        r1 = 1 - r1;
                        double g1 = (double)p1.G / 255;
                        g1 = 1 - g1;
                        double b1 = (double)p1.B / 255;
                        b1 = 1 - b1;

                        double r2 = (double)p2.R / 255;
                        r2 = 1 - r2;
                        double g2 = (double)p2.G / 255;
                        g2 = 1 - g2;
                        double b2 = (double)p2.B / 255;
                        b2 = 1 - b2;

                        double r3 = 1 - r1 * r2;
                        r3 = r3 * 255;

                        double g3 = 1 - g1 * g2;
                        g3 = g3 * 255;

                        double b3 = 1 - b1 * b2;
                        b3 = b3 * 255;

                        bitmap4.SetPixel(x, y, Color.FromArgb((int)r3, (int)g3, (int)b3));
                    }
                }
                pictureBox4.Image = bitmap4;
            }
            catch (Exception e1)
            {
                MessageBox.Show("Obrazek nie został załadowany");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                int w = 0, h = 0;
                if (bitmap1.Width > bitmap3.Width)
                {
                    w = bitmap3.Width;
                }
                else
                {
                    w = bitmap1.Width;
                }

                if (bitmap1.Height > bitmap3.Height)
                {
                    h = bitmap3.Height;
                }
                else
                {
                    h = bitmap1.Height;
                }
                for (int y = 0; y < h; y++)
                {
                    for (int x = 0; x < w; x++)
                    {
                        Color p1 = bitmap1.GetPixel(x, y);
                        Color p2 = bitmap3.GetPixel(x, y);

                        double r1 = (double)p1.R / 255;
                        double g1 = (double)p1.G / 255;
                        double b1 = (double)p1.B / 255;


                        double r2 = (double)p2.R / 255;
                        double g2 = (double)p2.G / 255;
                        double b2 = (double)p2.B / 255;


                        double r3 = 1 - Math.Abs(1 - r1 - r2);
                        r3 = r3 * 255;

                        double g3 = 1 - Math.Abs(1 - g1 - g2);
                        g3 = g3 * 255;

                        double b3 = 1 - Math.Abs(1 - b1 - b2);
                        b3 = b3 * 255;



                        bitmap4.SetPixel(x, y, Color.FromArgb((int)r3, (int)g3, (int)b3));
                    }
                }
                pictureBox4.Image = bitmap4;
            }
            catch (Exception e1)
            {
                MessageBox.Show("Obrazek nie został załadowany");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                int w = 0, h = 0;
                if (bitmap1.Width > bitmap3.Width)
                {
                    w = bitmap3.Width;
                }
                else
                {
                    w = bitmap1.Width;
                }

                if (bitmap1.Height > bitmap3.Height)
                {
                    h = bitmap3.Height;
                }
                else
                {
                    h = bitmap1.Height;
                }
                for (int y = 0; y < h; y++)
                {
                    for (int x = 0; x < w; x++)
                    {
                        Color p1 = bitmap1.GetPixel(x, y);
                        Color p2 = bitmap3.GetPixel(x, y);

                        int r1 = p1.R;
                        int g1 = p1.G;
                        int b1 = p1.B;

                        int r2 = p2.R;
                        int g2 = p2.G;
                        int b2 = p2.B;

                        int r3, g3, b3;
                        if (r1 < r2)
                        {
                            r3 = r1;
                        }
                        else
                        {
                            r3 = r2;
                        }
                        if (g1 < g2)
                        {
                            g3 = g1;
                        }
                        else
                        {
                            g3 = g2;
                        }
                        if (b1 < b2)
                        {
                            b3 = b1;
                        }
                        else
                        {
                            b3 = b2;
                        }
                        bitmap4.SetPixel(x, y, Color.FromArgb(r3, g3, b3));
                    }
                }
                pictureBox4.Image = bitmap4;
            }
            catch (Exception e1)
            {
                MessageBox.Show("Obrazek nie został załadowany");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                int w = 0, h = 0;
                if (bitmap1.Width > bitmap3.Width)
                {
                    w = bitmap3.Width;
                }
                else
                {
                    w = bitmap1.Width;
                }

                if (bitmap1.Height > bitmap3.Height)
                {
                    h = bitmap3.Height;
                }
                else
                {
                    h = bitmap1.Height;
                }
                for (int y = 0; y < h; y++)
                {
                    for (int x = 0; x < w; x++)
                    {
                        Color p1 = bitmap1.GetPixel(x, y);
                        Color p2 = bitmap3.GetPixel(x, y);

                        int r1 = p1.R;
                        int g1 = p1.G;
                        int b1 = p1.B;

                        int r2 = p2.R;
                        int g2 = p2.G;
                        int b2 = p2.B;

                        int r3, g3, b3;
                        if (r1 > r2)
                        {
                            r3 = r1;
                        }
                        else
                        {
                            r3 = r2;
                        }
                        if (g1 > g2)
                        {
                            g3 = g1;
                        }
                        else
                        {
                            g3 = g2;
                        }
                        if (b1 > b2)
                        {
                            b3 = b1;
                        }
                        else
                        {
                            b3 = b2;
                        }



                        bitmap4.SetPixel(x, y, Color.FromArgb(r3, g3, b3));
                    }
                }
                pictureBox4.Image = bitmap4;
            }
            catch (Exception e1)
            {
                MessageBox.Show("Obrazek nie został załadowany");
            }
        }
        private void button22_Click(object sender, EventArgs e)
        {
            try
            {
                int w = 0, h = 0;
                if (bitmap1.Width > bitmap3.Width)
                {
                    w = bitmap3.Width;
                }
                else
                {
                    w = bitmap1.Width;
                }

                if (bitmap1.Height > bitmap3.Height)
                {
                    h = bitmap3.Height;
                }
                else
                {
                    h = bitmap1.Height;
                }
                for (int y = 0; y < h; y++)
                {
                    for (int x = 0; x < w; x++)
                    {
                        Color p1 = bitmap1.GetPixel(x, y);
                        Color p2 = bitmap3.GetPixel(x, y);

                        double r1 = (double)p1.R / 255;
                        double g1 = (double)p1.G / 255;
                        double b1 = (double)p1.B / 255;


                        double r2 = (double)p2.R / 255;
                        double g2 = (double)p2.G / 255;
                        double b2 = (double)p2.B / 255;


                        double r3 = r1 + r2 - (2 * r1 * r2);
                        r3 = r3 * 255;

                        double g3 = g1 + g2 - (2 * g1 * g2);
                        g3 = g3 * 255;

                        double b3 = b1 + b2 - (2 * b1 * b2);
                        b3 = b3 * 255;



                        bitmap4.SetPixel(x, y, Color.FromArgb((int)r3, (int)g3, (int)b3));
                    }
                }
                pictureBox4.Image = bitmap4;
            }
            catch (Exception e1)
            {
                MessageBox.Show("Obrazek nie został załadowany");
            }
        }
        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                int w = 0, h = 0;
                if (bitmap1.Width > bitmap3.Width)
                {
                    w = bitmap3.Width;
                }
                else
                {
                    w = bitmap1.Width;
                }

                if (bitmap1.Height > bitmap3.Height)
                {
                    h = bitmap3.Height;
                }
                else
                {
                    h = bitmap1.Height;
                }
                for (int y = 0; y < h; y++)
                {
                    for (int x = 0; x < w; x++)
                    {
                        Color p1 = bitmap1.GetPixel(x, y);
                        Color p2 = bitmap3.GetPixel(x, y);

                        double r1 = (double)p1.R / 255;
                        double g1 = (double)p1.G / 255;
                        double b1 = (double)p1.B / 255;


                        double r2 = (double)p2.R / 255;
                        double g2 = (double)p2.G / 255;
                        double b2 = (double)p2.B / 255;

                        double r3 = 0;
                        if (r1 < 0.5)
                        {
                            r3 = 2 * r1 * r2;
                        }
                        else
                        {
                            r3 = 1 - (2 * (1 - r1) * (1 - r2));
                        }
                        r3 = r3 * 255;


                        double g3 = 0;
                        if (g1 < 0.5)
                        {
                            g3 = 2 * g1 * g2;
                        }
                        else
                        {
                            g3 = 1 - (2 * (1 - g1) * (1 - g2));
                        }
                        g3 = g3 * 255;

                        double b3 = 0;
                        if (b1 < 0.5)
                        {
                            b3 = 2 * b1 * b2;
                        }
                        else
                        {
                            b3 = 1 - (2 * (1 - b1) * (1 - b2));
                        }
                        b3 = b3 * 255;



                        bitmap4.SetPixel(x, y, Color.FromArgb((int)r3, (int)g3, (int)b3));
                    }
                }
                pictureBox4.Image = bitmap4;
            }
            catch (Exception e1)
            {
                MessageBox.Show("Obrazek nie został załadowany");
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                int w = 0, h = 0;
                if (bitmap1.Width > bitmap3.Width)
                {
                    w = bitmap3.Width;
                }
                else
                {
                    w = bitmap1.Width;
                }

                if (bitmap1.Height > bitmap3.Height)
                {
                    h = bitmap3.Height;
                }
                else
                {
                    h = bitmap1.Height;
                }
                for (int y = 0; y < h; y++)
                {
                    for (int x = 0; x < w; x++)
                    {
                        Color p1 = bitmap1.GetPixel(x, y);
                        Color p2 = bitmap3.GetPixel(x, y);

                        double r1 = (double)p1.R / 255;
                        double g1 = (double)p1.G / 255;
                        double b1 = (double)p1.B / 255;


                        double r2 = (double)p2.R / 255;
                        double g2 = (double)p2.G / 255;
                        double b2 = (double)p2.B / 255;

                        double r3 = 0;
                        if (r2 < 0.5)
                        {
                            r3 = 2 * r1 * r2;
                        }
                        else
                        {
                            r3 = 1 - (2 * (1 - r1) * (1 - r2));
                        }
                        r3 = r3 * 255;


                        double g3 = 0;
                        if (g2 < 0.5)
                        {
                            g3 = 2 * g1 * g2;
                        }
                        else
                        {
                            g3 = 1 - (2 * (1 - g1) * (1 - g2));
                        }
                        g3 = g3 * 255;

                        double b3 = 0;
                        if (b2 < 0.5)
                        {
                            b3 = 2 * b1 * b2;
                        }
                        else
                        {
                            b3 = 1 - (2 * (1 - b1) * (1 - b2));
                        }
                        b3 = b3 * 255;



                        bitmap4.SetPixel(x, y, Color.FromArgb((int)r3, (int)g3, (int)b3));
                    }
                }
                pictureBox4.Image = bitmap4;
            }
            catch (Exception e1)
            {
                MessageBox.Show("Obrazek nie został załadowany");
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            try
            {
                int w = 0, h = 0;
                if (bitmap1.Width > bitmap3.Width)
                {
                    w = bitmap3.Width;
                }
                else
                {
                    w = bitmap1.Width;
                }

                if (bitmap1.Height > bitmap3.Height)
                {
                    h = bitmap3.Height;
                }
                else
                {
                    h = bitmap1.Height;
                }
                for (int y = 0; y < h; y++)
                {
                    for (int x = 0; x < w; x++)
                    {
                        Color p1 = bitmap1.GetPixel(x, y);
                        Color p2 = bitmap3.GetPixel(x, y);

                        double r1 = (double)p1.R / 255;
                        double g1 = (double)p1.G / 255;
                        double b1 = (double)p1.B / 255;


                        double r2 = (double)p2.R / 255;
                        double g2 = (double)p2.G / 255;
                        double b2 = (double)p2.B / 255;

                        double r3 = 0;
                        if (r2 < 0.5)
                        {
                            r3 = 2 * r1 * r2 + ((Math.Pow(r1, 2) * (1 - 2 * r2)));
                        }
                        else
                        {
                            r3 = (Math.Sqrt(r1) * (2 * r2 - 1)) + ((2 * r1) * (1 - r2));
                        }
                        r3 = r3 * 255;

                        double g3 = 0;
                        if (g2 < 0.5)
                        {
                            g3 = 2 * g1 * g2 + ((Math.Pow(g1, 2) * (1 - 2 * g2)));
                        }
                        else
                        {
                            g3 = (Math.Sqrt(g1) * (2 * g2 - 1)) + ((2 * g1) * (1 - g2));
                        }
                        g3 = g3 * 255;

                        double b3 = 0;
                        if (b2 < 0.5)
                        {
                            b3 = 2 * b1 * b2 + ((Math.Pow(b1, 2) * (1 - 2 * b2)));
                        }
                        else
                        {
                            b3 = (Math.Sqrt(b1) * (2 * b2 - 1)) + ((2 * b1) * (1 - b2));
                        }
                        b3 = b3 * 255;

                        bitmap4.SetPixel(x, y, Color.FromArgb((int)r3, (int)g3, (int)b3));
                    }
                }
                pictureBox4.Image = bitmap4;
            }
            catch (Exception e1)
            {
                MessageBox.Show("Obrazek nie został załadowany");
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                int w = 0, h = 0;
                if (bitmap1.Width > bitmap3.Width)
                {
                    w = bitmap3.Width;
                }
                else
                {
                    w = bitmap1.Width;
                }

                if (bitmap1.Height > bitmap3.Height)
                {
                    h = bitmap3.Height;
                }
                else
                {
                    h = bitmap1.Height;
                }
                for (int y = 0; y < h; y++)
                {
                    for (int x = 0; x < w; x++)
                    {
                        Color p1 = bitmap1.GetPixel(x, y);
                        Color p2 = bitmap3.GetPixel(x, y);

                        double r1 = (double)p1.R / 255;
                        double g1 = (double)p1.G / 255;
                        double b1 = (double)p1.B / 255;


                        double r2 = (double)p2.R / 255;
                        double g2 = (double)p2.G / 255;
                        double b2 = (double)p2.B / 255;

                        double r3 = 0.0;
                        r3 = r1 / (1 - r2);
                        r3 = r3 * 255;
                        if (r3 > 255)
                            r3 = 255;

                        double g3 = 0.0;
                        g3 = g1 / (1 - g2);
                        g3 = g3 * 255;
                        if (g3 > 255)
                            g3 = 255;

                        double b3 = 0.0;
                        b3 = b1 / (1 - b2);
                        b3 = b3 * 255;
                        if (b3 > 255)
                            b3 = 255;

                        bitmap4.SetPixel(x, y, Color.FromArgb((int)r3, (int)g3, (int)b3));
                    }
                }
                pictureBox4.Image = bitmap4;
            }
            catch (Exception e1)
            {
                MessageBox.Show("Obrazek nie został załadowany");
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            try
            {
                int w = 0, h = 0;
                if (bitmap1.Width > bitmap3.Width)
                {
                    w = bitmap3.Width;
                }
                else
                {
                    w = bitmap1.Width;
                }

                if (bitmap1.Height > bitmap3.Height)
                {
                    h = bitmap3.Height;
                }
                else
                {
                    h = bitmap1.Height;
                }
                for (int y = 0; y < h; y++)
                {
                    for (int x = 0; x < w; x++)
                    {
                        Color p1 = bitmap1.GetPixel(x, y);
                        Color p2 = bitmap3.GetPixel(x, y);

                        double r1 = (double)p1.R / 255;
                        double g1 = (double)p1.G / 255;
                        double b1 = (double)p1.B / 255;


                        double r2 = (double)p2.R / 255;
                        double g2 = (double)p2.G / 255;
                        double b2 = (double)p2.B / 255;

                        double r3 = 0.0;
                        r3 = 1 - ((1 - r1) / r2);
                        r3 = r3 * 255;
                        if (r3 < 0)
                            r3 = 0;

                        double g3 = 0.0;
                        g3 = 1 - ((1 - g1) / g2);
                        g3 = g3 * 255;
                        if (g3 < 0)
                            g3 = 0;

                        double b3 = 0.0;
                        b3 = 1 - ((1 - b1) / b2);
                        b3 = b3 * 255;
                        if (b3 < 0)
                            b3 = 0;

                        bitmap4.SetPixel(x, y, Color.FromArgb((int)r3, (int)g3, (int)b3));
                    }
                }
                pictureBox4.Image = bitmap4;
            }
            catch (Exception e1)
            {
                MessageBox.Show("Obrazek nie został załadowany");
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                int w = 0, h = 0;
                if (bitmap1.Width > bitmap3.Width)
                {
                    w = bitmap3.Width;
                }
                else
                {
                    w = bitmap1.Width;
                }

                if (bitmap1.Height > bitmap3.Height)
                {
                    h = bitmap3.Height;
                }
                else
                {
                    h = bitmap1.Height;
                }
                for (int y = 0; y < h; y++)
                {
                    for (int x = 0; x < w; x++)
                    {
                        Color p1 = bitmap1.GetPixel(x, y);
                        Color p2 = bitmap3.GetPixel(x, y);

                        double r1 = (double)p1.R / 255;
                        double g1 = (double)p1.G / 255;
                        double b1 = (double)p1.B / 255;


                        double r2 = (double)p2.R / 255;
                        double g2 = (double)p2.G / 255;
                        double b2 = (double)p2.B / 255;

                        double r3 = 0.0;
                        r3 = Math.Pow(r1, 2) / (1 - r2);
                        r3 = r3 * 255;
                        if (r3 > 255)
                            r3 = 255;

                        double g3 = 0.0;
                        g3 = Math.Pow(g1, 2) / (1 - g2);
                        g3 = g3 * 255;
                        if (g3 > 255)
                            g3 = 255;

                        double b3 = 0.0;
                        b3 = Math.Pow(b1, 2) / (1 - b2);
                        b3 = b3 * 255;
                        if (b3 > 255)
                            b3 = 255;

                        bitmap4.SetPixel(x, y, Color.FromArgb((int)r3, (int)g3, (int)b3));
                    }
                }
                pictureBox4.Image = bitmap4;
            }
            catch (Exception e1)
            {
                MessageBox.Show("Obrazek nie został załadowany");
            }
        }
    }
}
