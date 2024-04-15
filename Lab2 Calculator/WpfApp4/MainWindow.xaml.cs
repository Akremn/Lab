using System;
using System.Windows;

namespace WpfApp4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string text1;
        private string _previousText;

        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new Page2(text1, _previousText);
        }
    }
}
