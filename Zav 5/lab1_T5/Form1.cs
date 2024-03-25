using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1_T5
{
    public delegate void SuperButton(object sender, EventArgs e);
    public partial class Form1 : Form
    {

        private SuperButton superButton;
        private double previousOpacity;
        private Color previousBackgroundColor;

        public Form1()
        {
            InitializeComponent();
            previousOpacity = this.Opacity;
            previousBackgroundColor = this.BackColor;
        }
        private void Transparency_Click(object sender, EventArgs e)
        {
            if (this.Opacity == 1.0)
            {
                this.Opacity = 0.5;
            }
            else
            {
                this.Opacity = 1.0;
            }
        }

        private void BackgroundColor_Click(object sender, EventArgs e)
        {
            if (this.BackColor == Color.Red)
            {
                this.BackColor = previousBackgroundColor;
            }
            else
            {
                previousBackgroundColor = this.BackColor;
                this.BackColor = Color.Red;
            }
        }

        private void HelloWorld_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello World!");
        }

        private void SuperMegaButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Я супермегакнопка,\nі цього мене не позбавиш!");
            superButton?.Invoke(sender, e);
        }

        private void CheckboxTransparency_CheckedChanged(object sender, EventArgs e)
        {
            superButton -= Transparency_Click;
            if (CheckboxTransparency.Checked)
            {
                superButton += Transparency_Click;
            }
        }

        private void CheckboxBackgroundColor_CheckedChanged(object sender, EventArgs e)
        {
            superButton -= BackgroundColor_Click; 
            if (CheckboxBackgroundColor.Checked)
            {
                superButton += BackgroundColor_Click; 
            }
        }

        private void CheckboxHelloWorld_CheckedChanged(object sender, EventArgs e)
        {
            superButton -= HelloWorld_Click; 
            if (CheckboxHelloWorld.Checked)
            {
                superButton += HelloWorld_Click; 
            }
        }

    }
}
