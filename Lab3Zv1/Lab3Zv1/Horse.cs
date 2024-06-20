using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Lab3Zv1
{
    public class Horse
    {
        private static readonly object LockObject = new object();
        public string Name { get; private set; }
        public Brush Color { get; private set; }
        public double Accelaration { get; private set; }
        public double Position { get; private set; }
        public Stopwatch Timer;

        public Horse(string name, Brush color, Random random)
        {
            Name = name;
            Color = color;
            Position = -720;

            lock (LockObject)
            {
                Accelaration = random.Next(5, 11);
            }

            Timer = new Stopwatch();
            Timer.Start();
        }

        public void ChangeAccelaration(Random random)
        {
            double value;
            lock (LockObject)
            {
                value = random.Next(7, 11) / 2.0;
            }
            Position += Accelaration * value;
        }

        public async Task RunAsync(Random random)
        {
            while (true)
            {
                if (Position >= 720)
                {
                    Timer.Stop();
                    break;
                }

                ChangeAccelaration(random);
                await Task.Delay(100 + random.Next(0, 500));
            }
        }

        public static Horse[] ChangePlace(Horse[] horses)
        {
            return horses.OrderByDescending(x => x.Position).ToArray();
        }

        public static Horse[] ChangePositionRaiting(Horse[] horses)
        {
            return horses.OrderBy(x => x.Timer.ElapsedMilliseconds).ToArray();
        }
    }
}
