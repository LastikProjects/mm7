using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mm7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int cl;
        int n;
        int[,] mas;
        Random rand = new Random();

        //            00000000000
        //01001111010
        //00110101011
        //01111111001
        //00111100101
        //01000010100
        //00110001110
        //00011111001
        //01110101000
        //01010010111
        //01111110011

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics gr = pictureBox1.CreateGraphics();
            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            gr.Clear(Color.White);
            int w = pictureBox1.Width;
            int h = pictureBox1.Height;
            int widthLines = w / Convert.ToInt32(textBox2.Text);
            int heightLines = widthLines;
            for (int i = 0; i < w; i += widthLines)
            {
                gr.DrawLine(new Pen(Brushes.Black), new Point(i + widthLines, 0), new Point(i + widthLines, h));
                gr.DrawLine(new Pen(Brushes.Black), new Point(0, i + heightLines), new Point(w, i + heightLines));
            }
            for (int i = 1; i < n; i++)
                for (int j = 1; j < n; j++)
                    if (mas[i, j] == 0)
                        gr.FillRectangle(Brushes.Yellow, (j - 1) * w / Convert.ToInt32(textBox2.Text), (i - 1) * w / Convert.ToInt32(textBox2.Text), w / Convert.ToInt32(textBox2.Text), w / Convert.ToInt32(textBox2.Text));
                    else
                        gr.FillRectangle(Brushes.Black, (j - 1) * w / Convert.ToInt32(textBox2.Text), (i - 1) * w / Convert.ToInt32(textBox2.Text), w / Convert.ToInt32(textBox2.Text), w / Convert.ToInt32(textBox2.Text));

        }

        private void button2_Click(object sender, EventArgs e)
        {
            double p = Convert.ToDouble(textBox1.Text);
            n = Convert.ToInt32(textBox2.Text) + 1;
            mas = new int[n, n];

            textBox3.Text = "";
            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    if (Convert.ToDouble(rand.Next(100)) / 100 <= p)
                        mas[i, j] = 1;
                    else
                        mas[i, j] = 0;
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    textBox3.Text += mas[i, j];
                textBox3.Text += Environment.NewLine;
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {

            cl = 0;
            for (int i = 1; i < n; i++)
                for (int j = 1; j < n; j++)
                    if (mas[i, j] == 1)
                    {
                        if (mas[i - 1, j] == 0 & mas[i, j - 1] == 0)
                        {
                            cl++;
                            mas[i, j] = cl;
                        }
                        else
                            if (mas[i - 1, j] == 0 & mas[i, j - 1] != 0)
                            mas[i, j] = mas[i, j - 1];
                        else
                            if (mas[i - 1, j] != 0 & mas[i, j - 1] == 0)
                            mas[i, j] = mas[i - 1, j];
                        else
                        if (mas[i - 1, j] < mas[i, j - 1])
                        {
                            int help = mas[i, j - 1];
                            mas[i, j] = mas[i - 1, j];
                            int change = mas[i, j - 1];
                            for (int k = 1; k < n; k++)
                                for (int m = 1; m < n; m++)
                                    if (mas[k, m] == change)
                                        mas[k, m] = mas[i - 1, j];

                            for (int o = 1; o < n; o++)
                                for (int p = 1; p < n; p++)
                                    if (mas[o, p] > help)
                                    {
                                        bool choice = true;
                                        int more = mas[i, j - 1] + 2;
                                        while (choice)
                                        {
                                            choice = false;
                                            for (int k = 1; k < n; k++)
                                                for (int m = 1; m < n; m++)
                                                    if (mas[k, m] == more)
                                                    {
                                                        mas[k, m] = more - 1;
                                                        choice = true;
                                                    }
                                            if (choice)
                                            {
                                                cl--;
                                                more++;
                                            }
                                            else
                                                cl++;
                                        }
                                        break;
                                    }
                            cl--;
                        }
                        else
                            if (mas[i - 1, j] > mas[i, j - 1])
                        {
                            int help = mas[i - 1, j];
                            mas[i, j] = mas[i, j - 1];
                            int change = mas[i - 1, j];
                            for (int k = 1; k < n; k++)
                                for (int m = 1; m < n; m++)
                                    if (mas[k, m] == change)
                                        mas[k, m] = mas[i, j - 1];

                            for (int o = 1; o < n; o++)
                                for (int p = 1; p < n; p++)
                                    if (mas[o, p] > help)
                                    {
                                        bool choice = true;
                                        int more = mas[i - 1, j] + 2;
                                        while (choice)
                                        {
                                            choice = false;
                                            for (int k = 1; k < n; k++)
                                                for (int m = 1; m < n; m++)
                                                    if (mas[k, m] == more)
                                                    {
                                                        mas[k, m] = more - 1;
                                                        choice = true;
                                                    }
                                            if (choice)
                                            {
                                                cl--;
                                                more++;
                                            }
                                            else
                                                cl++;
                                        }
                                        break;
                                    }
                            cl--;
                        }
                        else
                            mas[i, j] = mas[i, j - 1];
                    }
            textBox3.Text += Environment.NewLine;
            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < n; j++)
                    textBox3.Text += mas[i, j].ToString();
                textBox3.Text += Environment.NewLine;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int number_of_ways = 0;
            Graphics gr = pictureBox1.CreateGraphics();
            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            gr.Clear(Color.White);
            int w = pictureBox1.Width;
            int h = pictureBox1.Height;
            int widthLines = w / Convert.ToInt32(textBox2.Text);
            int heightLines = widthLines;
            for (int i = 0; i < w; i += widthLines)
            {
                gr.DrawLine(new Pen(Brushes.Black), new Point(i + widthLines, 0), new Point(i + widthLines, h));
                gr.DrawLine(new Pen(Brushes.Black), new Point(0, i + heightLines), new Point(w, i + heightLines));
            }
            for (int i = 1; i < n; i++)
                for (int j = 1; j < n; j++)
                    if (mas[i, j] == 0)
                        gr.FillRectangle(Brushes.Yellow, (j - 1) * w / Convert.ToInt32(textBox2.Text), (i - 1) * w / Convert.ToInt32(textBox2.Text), w / Convert.ToInt32(textBox2.Text), w / Convert.ToInt32(textBox2.Text));
                    else
                        gr.FillRectangle(Brushes.Black, (j - 1) * w / Convert.ToInt32(textBox2.Text), (i - 1) * w / Convert.ToInt32(textBox2.Text), w / Convert.ToInt32(textBox2.Text), w / Convert.ToInt32(textBox2.Text));

            for (int j = 1; j < cl; j++)
                for (int i = 1; i < n; i++)
                    if (mas[1, i] == j)
                    {
                        for (int k = 1; k < n; k++)
                            if (mas[n - 1, k] == j)
                            {
                                for (int g = 1; g < n; g++)
                                    for (int f = 1; f < n; f++)
                                        if (mas[g, f] == j)
                                            gr.FillRectangle(Brushes.Blue, (f - 1) * w / Convert.ToInt32(textBox2.Text), (g - 1) * w / Convert.ToInt32(textBox2.Text), w / Convert.ToInt32(textBox2.Text), w / Convert.ToInt32(textBox2.Text));
                                number_of_ways++;
                                break;
                            }
                        break;
                    }
            textBox4.Text = "Найдено путей: " + number_of_ways.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Graphics gr = pictureBox1.CreateGraphics();
            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            gr.Clear(Color.White);
            int w = pictureBox1.Width;
            int h = pictureBox1.Height;
            int widthLines = w / Convert.ToInt32(textBox2.Text);
            int heightLines = widthLines;
            for (int i = 0; i < w; i += widthLines)
            {
                gr.DrawLine(new Pen(Brushes.Black), new Point(i + widthLines, 0), new Point(i + widthLines, h));
                gr.DrawLine(new Pen(Brushes.Black), new Point(0, i + heightLines), new Point(w, i + heightLines));
            }
            for (int m = 1; m < cl + 1; m++)
            {
                Color color = Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255));
                Brush br = new SolidBrush(color);
                for (int i = 1; i < n; i++)
                    for (int j = 1; j < n; j++)
                        if (mas[i, j] == m)
                            gr.FillRectangle(br, (j - 1) * w / Convert.ToInt32(textBox2.Text), (i - 1) * w / Convert.ToInt32(textBox2.Text), w / Convert.ToInt32(textBox2.Text), w / Convert.ToInt32(textBox2.Text));
            }
        }
    }
}
