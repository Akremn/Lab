using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace WpfApp4
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
            foreach (UIElement el in GroupButton.Children)
            {
                if (el is Button)
                {
                    ((Button)el).Click += ButtonClick;
                }
            }
        }
        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            string textButton = ((Button)e.OriginalSource).Content.ToString();
            if (textButton == "C"){text.Clear();}
            else if (textButton == "CE")
            {
                if (text.Text.Length > 0)
                {
                    text.Text = text.Text.Remove(text.Text.Length - 1);
                }
            }
            else if (textButton == "⟵")
            {
                if (text.Text.Length > 0)
                {
                    text.Text = text.Text.Remove(text.Text.Length - 1);
                }
            }
            else if (textButton == "="){text.Text = new DataTable().Compute(text.Text, null).ToString();}
            else if (textButton == "Pi"){text.Text += "3.14";}
            else if (textButton == "√")
            {
                double num;
                if (Double.TryParse(text.Text, out num))
                {
                    if (num >= 0)
                    {
                        text.Text = Math.Sqrt(num).ToString();
                    }
                    else
                    {
                        return;
                    }
                }
            }
            else if (textButton == "^2")
            {
                double num;
                if (Double.TryParse(text.Text, out num))
                {
                    text.Text = Math.Pow(num, 2).ToString();
                }
            }
            else if (textButton == "log")
            {
                double num;
                if (Double.TryParse(text.Text, out num))
                {
                    text.Text = Math.Log(num, 2).ToString();
                }
            }
            else if (textButton == ">>>>"){}
            else {text.Text += textButton;}
        }
        private void But1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page2());
        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}
