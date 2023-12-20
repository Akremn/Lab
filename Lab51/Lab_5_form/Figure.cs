using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5_form
{
    public abstract class Figure
    {
        public int X { get; set; }
        public int Y { get; set; }

        public abstract void DrawBlack();
        public abstract void HideDrawingBackGround();
        public void MoveRight()
        {
            for (int i = 0; i < 50; i++)
            {
                DrawBlack();
                System.Threading.Thread.Sleep(100);
                HideDrawingBackGround();
                X++;
            }
        }

        public Figure(int x, int y)
        {
            X = x;
            Y = y;
        }

    }
}
