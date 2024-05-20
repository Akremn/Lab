using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp11
{
    public partial class Form1 : Form
    {
        private List<Vertex> vertices = new List<Vertex>();
        private Random random = new Random();
        private Stopwatch renderStopwatch = new Stopwatch();
        private Stopwatch renderStopwatch1 = new Stopwatch();
        private ConcurrentDictionary<Point, Color> _cellColors = new ConcurrentDictionary<Point, Color>();
        private bool isMultiThreaded = false;

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
            comboBox1.SelectedIndex = 0;
        }
        private void PictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var vertex = new Vertex(e.Location);
                vertices.Add(vertex);
                _cellColors[vertex.Position] = GetVertexColor(vertex);
                pictureBox1.Invalidate(); // Перемальовуємо PictureBox при додаванні вершини
            }
            else if (e.Button == MouseButtons.Right)
            {
                Vertex closestVertex = GetClosestVertex(e.Location);
                if (closestVertex != null)
                {
                    vertices.Remove(closestVertex);
                    _cellColors.TryRemove(closestVertex.Position, out _);
                    pictureBox1.Invalidate(); // Перемальовуємо PictureBox при видаленні вершини
                }
            }
        }
        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            renderStopwatch.Restart();
            if (!isMultiThreaded)
            {
                DrawVoronoiDiagramSingleThread(e.Graphics);
            }
            else
            {
                DrawVoronoiDiagramMultiThread();
            }
            renderStopwatch.Stop();
            UpdateSpeed();
        }
        private void DrawVoronoiDiagramSingleThread(Graphics g)
        {
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

        private void DrawVoronoiDiagramMultiThread()
        {
            var bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            int numThreads = Environment.ProcessorCount;

            int regionWidth = bmp.Width / numThreads;
            List<Rectangle> regions = new List<Rectangle>();
            for (int i = 0; i < numThreads; i++)
            {
                regions.Add(new Rectangle(i * regionWidth, 0, regionWidth, bmp.Height));
            }

            var tasks = new List<Task>();
            foreach (var region in regions)
            {
                tasks.Add(Task.Run(() =>
                {
                    for (var x = region.X; x < region.X + region.Width; x++)
                    {
                        for (var y = region.Y; y < region.Y + region.Height; y++)
                        {
                            var closestPoint = FindClosestPoint(new Point(x, y));

                            if (closestPoint != null && _cellColors.TryGetValue(closestPoint.Value, out Color color))
                            {
                                lock (bmp)
                                {
                                    bmp.SetPixel(x, y, color);
                                }
                            }
                        }
                    }
                }));
            }

            Task.WaitAll(tasks.ToArray());

            // Позначення вершин на зображенні
            using (Graphics g = Graphics.FromImage(bmp))
            {
                foreach (var vertex in vertices)
                {
                    g.FillEllipse(Brushes.Red, vertex.Position.X - 3, vertex.Position.Y - 3, 6, 6);
                }
            }

            pictureBox1.Image = bmp;
        }
        private Point? FindClosestPoint(Point pixel)
        {
            Vertex closestVertex = GetClosestVertex(pixel);
            if (closestVertex != null)
            {
                return closestVertex.Position;
            }
            return null;
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

        private void GenerateRandomPoints(int count)
        {
            // Очистка списку, щоб уникнути дублювання точок
            vertices.Clear();
            _cellColors.Clear();
            for (int i = 0; i < count; i++)
            {
                int x = random.Next(pictureBox1.Width);
                int y = random.Next(pictureBox1.Height);
                var vertex = new Vertex(new Point(x, y));
                vertices.Add(vertex);
                _cellColors[vertex.Position] = GetVertexColor(vertex);
            }
        }   

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        private void UpdateSpeed()
        {
            double renderTime = renderStopwatch.Elapsed.TotalMilliseconds;
            if (renderTime > 0)
            {
                txtSpeed.Text = $"Render Time:{renderTime:F2} ms";
            }
            else
            {
                txtSpeed.Text = "Render Time: N/A";
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            isMultiThreaded = comboBox1.SelectedIndex == 1;
            pictureBox1.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GenerateRandomPoints(30);
            pictureBox1.Invalidate(); // Тригеримо відрисовку
        }

        private void button3_Click(object sender, EventArgs e)
        {
            vertices.Clear();
            _cellColors.Clear();
            pictureBox1.Invalidate();
            txtSpeed.Text = "Render Time: N/A";
        }
    }
}
