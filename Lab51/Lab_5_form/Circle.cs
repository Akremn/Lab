using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab_5_form
{
    public class Circle : Figure
    {
        public int Radius 
        { 
            get; 
            set; 
        }

        public Circle(int x, int y, int radius) : base(x, y)
        {
            Radius = radius;
        }

        public override void DrawBlack()
        {
            Form activeForm = Graphics.ActiveForm;
            if (activeForm != null)
            {
                System.Drawing.Graphics graphics = activeForm.CreateGraphics();
                graphics.DrawEllipse(Pens.Black, X - Radius, Y - Radius, 2 * Radius, 2 * Radius);
            }
        }

        public override void HideDrawingBackGround()
        {
            Form activeForm = Graphics.ActiveForm;
            if (activeForm != null)
            {
                System.Drawing.Graphics graphics = activeForm.CreateGraphics();
                graphics.DrawEllipse(new Pen(activeForm.BackColor), X - Radius, Y - Radius, 2 * Radius, 2 * Radius);
            }
        }

    }
}
