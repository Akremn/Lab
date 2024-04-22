using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp11
{
    public partial class Form1 : Form
    {
        private List<Vertex> vertices = new List<Vertex>();
        private bool singleThreaded = true;


        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            // Ініціалізація PictureBox
            pictureBox1.Dock = DockStyle.Fill;
            this.Controls.Add(pictureBox1);

            // Призначте події Paint та MouseClick для PictureBox
            pictureBox1.Paint += PictureBox1_Paint;
            pictureBox1.MouseClick += PictureBox1_MouseClick;
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Побудова діаграми Вороного для кожного пікселя
            for (int x = 0; x < pictureBox1.Width; x++)
            {
                for (int y = 0; y < pictureBox1.Height; y++)
                {
                    Point pixel = new Point(x, y);
                    Vertex closestVertex = GetClosestVertex(pixel);

                    if (closestVertex != null)
                    {
                        Color color = GetVertexColor(closestVertex);
                        g.FillRectangle(new SolidBrush(color), x, y, 1, 1);
                    }
                }
            }

            // Малювання вершин
            foreach (Vertex vertex in vertices)
            {
                Color vertexColor = GetVertexColor(vertex);
                g.FillEllipse(Brushes.Red, vertex.Position.X - 3, vertex.Position.Y - 3, 6, 6);
            }
        }

        private Vertex GetClosestVertex(Point pixel)
        {
            Vertex closest = null;
            double minDistance = double.MaxValue;

            foreach (Vertex vertex in vertices)
            {
                double distance = CalculateDistance(pixel, vertex.Position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closest = vertex;
                }
            }

            return closest;
        }

        private double CalculateDistance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }

        private Color GetVertexColor(Vertex vertex)
        {
            // Генеруємо унікальний колір для кожної вершини на основі хешу позиції
            int hash = vertex.Position.X.GetHashCode() ^ vertex.Position.Y.GetHashCode() ^ vertex.GetHashCode();
            var random = new Random(hash);
            return Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
        }

        private void PictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                vertices.Add(new Vertex(e.Location));
                pictureBox1.Invalidate(); // Перемальовуємо PictureBox при додаванні вершини
            }
            else if (e.Button == MouseButtons.Right)
            {
                Vertex closestVertex = GetClosestVertex(e.Location);
                if (closestVertex != null)
                {
                    vertices.Remove(closestVertex);
                    pictureBox1.Invalidate(); // Перемальовуємо PictureBox при видаленні вершини
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            singleThreaded = !singleThreaded;

            if (!singleThreaded)
            {
                // Запускаємо обчислення у окремому потоці
                Task.Run(() =>
                {
                    Parallel.ForEach(Partitioner.Create(0, pictureBox1.Width),
                        (range) =>
                        {
                            for (int x = range.Item1; x < range.Item2; x++)
                            {
                                for (int y = 0; y < pictureBox1.Height; y++)
                                {
                                    Point pixel = new Point(x, y);
                                    Vertex closestVertex = GetClosestVertex(pixel);
                                    if (closestVertex != null)
                                    {
                                        Color color = GetVertexColor(closestVertex);
                                        pictureBox1.Invoke(new MethodInvoker(() =>
                                        {
                                            pictureBox1.CreateGraphics().FillRectangle(new SolidBrush(color), x, y, 1, 1);
                                        }));
                                    }
                                }
                            }
                        });
                });
            }
            else
            {
                pictureBox1.Invalidate(); // Перемальовуємо PictureBox в однопотоковому режимі
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
