using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class Square
    {
        public Square(int centerX, int centerY, int size)
        {
            this.centerX = centerX;
            this.centerY = centerY;
            this.size = size;
        }

        protected int centerX;
        protected int centerY;
        protected int size;

        private Point[] GetCurrPoints()
        {
            return new Point[] {
                new Point(centerX - size,  centerY - size),
                new Point(centerX - size,  centerY + size),
                new Point(centerX + size,  centerY + size),
                new Point(centerX + size,  centerY - size),
            };
        }

        public void Draw()
        {
            Graphics graphics = Form1.ActiveForm.CreateGraphics();
            graphics.DrawPolygon(Pens.Black, GetCurrPoints());
        }

        public void Erase()
        {
            Graphics graphics = Form1.ActiveForm.CreateGraphics();
            graphics.DrawPolygon(new Pen(Form1.ActiveForm.BackColor), GetCurrPoints());
        }

        public void MoveRight()
        {
            for (int i = 0; i < 50; i++)
            {
                Draw();
                System.Threading.Thread.Sleep(100);
                Erase();
                centerX++;
            }
        }
    }
}
