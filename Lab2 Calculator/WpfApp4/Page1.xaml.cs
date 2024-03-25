using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
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
        private readonly CalculatorInvoker _calculatorInvoker;

        public Page1()
        {
            InitializeComponent();
            _calculatorInvoker = new CalculatorInvoker();
            InitializeButtons();
        }

        private void InitializeButtons()
        {
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
            Button button = (Button)sender;
            string commandName = button.Content.ToString();
            ICommand command = null;

            switch (commandName)
            {
                case "C":
                    command = new ClearCommand(text);
                    break;
                case "CE":
                    command = new ClearEntryCommand(text);
                    break;
                case "⟵":
                    command = new BackspaceCommand(text);
                    break;
                case "=":
                    command = new ComputeCommand(text);
                    break;
                case "Pi":
                    command = new PiCommand(text);
                    break;
                case "√":
                    command = new SquareRootCommand(text);
                    break;
                case "^2":
                    command = new SquareCommand(text);
                    break;
                case "log":
                    command = new LogCommand(text);
                    break;
            }

            if (command != null)
            {
                _calculatorInvoker.SetCommand(command);
                _calculatorInvoker.ExecuteCommand();
            }
            else
            {
                text.Text += commandName;
            }
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
