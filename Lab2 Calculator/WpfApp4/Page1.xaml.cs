using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;

namespace WpfApp4
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        private readonly CalculatorInvoker _calculatorInvoker;
        private string _previousText;
        public Page1(string texxt,string _previousText)
        {
            InitializeComponent();
            _calculatorInvoker = new CalculatorInvoker();
            InitializeButtons();
            text.Text = texxt;
            this._previousText = _previousText;

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
                    _previousText = null;
                    break;
                case "CE":
                    command = new ClearEntryCommand(text,_previousText);
                    break;
                case "⟵":
                    command = new BackspaceCommand(text);
                    if(text.Text.Length > 0)
                        _previousText = _previousText.Remove(_previousText.Length - 1);
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
                _previousText += commandName;
            }
        }

        private void But1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page2(text.Text, _previousText));
        }
        
        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void text_TextChanged(object sender, TextChangedEventArgs e)
        {
            FormattedText formattedText = new FormattedText(text.Text, CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface(text.FontFamily, text.FontStyle, text.FontWeight, text.FontStretch), text.FontSize, Brushes.Black, new NumberSubstitution(), TextFormattingMode.Display);

            double textWidth = formattedText.WidthIncludingTrailingWhitespace;

            // Якщо текст виходить за межі поля, зменшуємо розмір шрифту
            if (textWidth > text.ActualWidth)
            {
                text.FontSize -= 3; // Можна налаштувати інший крок зменшення
            }
        }
    }
    
}
