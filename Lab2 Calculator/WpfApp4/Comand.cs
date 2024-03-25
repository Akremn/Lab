using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp4
{
    public interface ICommand
    {
        void Execute();
    }
    public class CalculatorInvoker
    {
        private ICommand _command;

        public void SetCommand(ICommand command)
        {
            _command = command;
        }

        public void ExecuteCommand()
        {
            _command?.Execute();
        }
    }
    public class ClearCommand : ICommand
    {
        private TextBox _textBox;

        public ClearCommand(TextBox textBox)
        {
            _textBox = textBox;
        }

        public void Execute()
        {
            _textBox.Clear();
        }
    }
    public class ClearEntryCommand : ICommand
    {
        private TextBox _textBox;

        public ClearEntryCommand(TextBox textBox)
        {
            _textBox = textBox;
        }

        public void Execute()
        {
            if (_textBox.Text.Length > 0)
            {
                _textBox.Text = _textBox.Text.Remove(_textBox.Text.Length - 1);
            }
        }
    }

    public class BackspaceCommand : ICommand
    {
        private TextBox _textBox;

        public BackspaceCommand(TextBox textBox)
        {
            _textBox = textBox;
        }

        public void Execute()
        {
            if (_textBox.Text.Length > 0)
            {
                _textBox.Text = _textBox.Text.Remove(_textBox.Text.Length - 1);
            }
        }
    }
    public class ComputeCommand : ICommand
    {
        private TextBox _textBox;

        public ComputeCommand(TextBox textBox)
        {
            _textBox = textBox;
        }

        public void Execute()
        {
            string expression = _textBox.Text.Replace(',', '.');
            try
            {
                _textBox.Text = new DataTable().Compute(expression, null).ToString();
            }
            catch (SyntaxErrorException)
            {
                // Обробка помилки у разі неправильного введення виразу
                MessageBox.Show("Помилка: неправильний вираз!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                // Обробка інших можливих помилок
                MessageBox.Show($"Помилка: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
    }

    public class PiCommand : ICommand
    {
        private TextBox _textBox;

        public PiCommand(TextBox textBox)
        {
            _textBox = textBox;
        }

        public void Execute()
        {
            _textBox.Text += "3,14";
        }
    }

    public class SquareRootCommand : ICommand
    {
        private TextBox _textBox;

        public SquareRootCommand(TextBox textBox)
        {
            _textBox = textBox;
        }

        public void Execute()
        {
            // Розділяємо текст на числа та оператори
            string[] parts = _textBox.Text.Split(new char[] { '+', '-', '*', '/' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length > 0)
            {
                double lastNumber;
                if (Double.TryParse(parts.Last(), out lastNumber))
                {
                    if (lastNumber >= 0)
                    {
                        // Обчислюємо квадратний корінь з останнього числа
                        _textBox.Text = _textBox.Text.Remove(_textBox.Text.LastIndexOf(parts.Last())) + Math.Sqrt(lastNumber).ToString();
                    }
                }
            }
        }
    }

    public class SquareCommand : ICommand
    {
        private TextBox _textBox;

        public SquareCommand(TextBox textBox)
        {
            _textBox = textBox;
        }

        public void Execute()
        {
            // Розділяємо текст на числа та оператори
            string[] parts = _textBox.Text.Split(new char[] { '+', '-', '*', '/' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length > 0)
            {
                double lastNumber;
                if (Double.TryParse(parts.Last(), out lastNumber))
                {
                    // Підносимо останнє число до квадрату
                    _textBox.Text = _textBox.Text.Remove(_textBox.Text.LastIndexOf(parts.Last())) + Math.Pow(lastNumber, 2).ToString();
                }
            }
        }
    }

    public class LogCommand : ICommand
    {
        private TextBox _textBox;

        public LogCommand(TextBox textBox)
        {
            _textBox = textBox;
        }

        public void Execute()
        {
            // Розділяємо текст на числа та оператори
            string[] parts = _textBox.Text.Split(new char[] { '+', '-', '*', '/' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length > 0)
            {
                double lastNumber;
                if (Double.TryParse(parts.Last(), out lastNumber))
                {
                    // Обчислюємо логарифм з останнього числа
                    _textBox.Text = _textBox.Text.Remove(_textBox.Text.LastIndexOf(parts.Last())) + Math.Log(lastNumber, 2).ToString();
                }
            }
        }
    }
}
