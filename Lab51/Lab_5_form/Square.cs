using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab_5_form
{
    public class Square : Figure
    {
        public int SideLength { get; set; }

        public Square(int x, int y, int sideLength) : base(x, y)
        {
            SideLength = sideLength;
        }
        public override void DrawBlack()
        {
            Form activeForm = Graphics.ActiveForm;
            if (activeForm != null)
            {
                System.Drawing.Graphics graphics = activeForm.CreateGraphics();
                graphics.DrawRectangle(Pens.Black, X - SideLength / 2, Y - SideLength / 2, SideLength, SideLength);
            }
        }

        public override void HideDrawingBackGround()
        {
            Form activeForm = Graphics.ActiveForm;
            if (activeForm != null)
            {
                System.Drawing.Graphics graphics = activeForm.CreateGraphics();
                graphics.DrawRectangle(new Pen(activeForm.BackColor), X - SideLength / 2, Y - SideLength / 2, SideLength, SideLength);
            }
        }

    }
}
