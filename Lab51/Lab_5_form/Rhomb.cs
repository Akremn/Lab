using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab_5_form
{
    internal class Rhomb : Figure
    {
        public int HorizontalDiagonal { get; set; }
        public int VerticalDiagonal { get; set; }

        public Rhomb(int x, int y, int horDiagonal, int verDiagonal) : base(x, y)
        {
            HorizontalDiagonal = horDiagonal;
            VerticalDiagonal = verDiagonal;
        }
        public override void DrawBlack()
        {
            Form activeForm = Graphics.ActiveForm;
            if (activeForm != null)
            {
                System.Drawing.Graphics graphics = activeForm.CreateGraphics();
                Point[] point = new Point[] {
                new Point(X, Y - VerticalDiagonal / 2),
                new Point(X + HorizontalDiagonal / 2, Y),
                new Point(X, Y + VerticalDiagonal / 2),
                new Point(X - HorizontalDiagonal / 2, Y)};
                graphics.DrawPolygon(Pens.Black, point);
            }
        }

        public override void HideDrawingBackGround()
        {
            Form activeForm = Graphics.ActiveForm;
            if (activeForm != null)
            {
                System.Drawing.Graphics graphics = activeForm.CreateGraphics();
                Point[] point = new Point[] {
                new Point(X, Y - VerticalDiagonal / 2),
                new Point(X + HorizontalDiagonal / 2, Y),
                new Point(X, Y + VerticalDiagonal / 2),
                new Point(X - HorizontalDiagonal / 2, Y) };


                graphics.DrawPolygon(new Pen(activeForm.BackColor), point);
            }
        }



    }
}
