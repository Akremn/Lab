using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;

namespace WpfApp4
{
    /// <summary>
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        private readonly CalculatorInvoker _calculatorInvoker;
        
        public string _previousText;
        public Page2(string text1,string _previousText)
        {
            InitializeComponent();
            _calculatorInvoker = new CalculatorInvoker();
            InitializeButtons();
            text.Text = text1;
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
                    command = new ClearEntryCommand(text, _previousText);
                    break;
                case "⟵":
                    command = new BackspaceCommand(text);
                    if (text.Text.Length > 0)
                        _previousText = _previousText.Remove(_previousText.Length - 1);
                    break;
                case "=":
                    command = new ComputeCommand(text);
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
        private void text_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox.Text.Length > 19)
            {
                textBox.FontSize = 20; 
            }
            else
            {
                textBox.FontSize = 48;
            }

            //FormattedText formattedText = new FormattedText(text.Text, CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface(text.FontFamily, text.FontStyle, text.FontWeight, text.FontStretch), text.FontSize, Brushes.Black, new NumberSubstitution(), TextFormattingMode.Display);

            //double textWidth = formattedText.WidthIncludingTrailingWhitespace;
            //// Якщо текст виходить за межі поля, зменшуємо розмір шрифту
            //if (textWidth > text.ActualWidth)
            //{
            //    text.FontSize -= 3; 
            //}
        }
        
        private void But2_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page1(text.Text, _previousText));
        }
    }
}
