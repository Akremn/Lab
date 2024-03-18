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
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
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
            if (textButton == "C")
            {
                text.Clear();
            }
            else if (textButton == "CE")
            {
                if(text.Text.Length > 0)
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
            else if (textButton == "=")
            {
                text.Text = new DataTable().Compute(text.Text, null).ToString();
            }
            else if (textButton == ">>>>"){}
            else
            {
                text.Text += textButton;
            }
        }
        private void text_TextChanged(object sender, TextChangedEventArgs e)
        {
                
        }

        private void But2_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page1());
        }
    }
}
