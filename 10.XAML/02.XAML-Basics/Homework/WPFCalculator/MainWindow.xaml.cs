using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WPFCalculator.Models;

namespace WPFCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Calculator calculator;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Click(object sender, RoutedEventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            var content = (sender as Button).Content;
            if (content is string)
            {
                int number;
                if (content.ToString() == ".")
                {
                    this.TextBlockResult.Text += content.ToString();
                }
                else if (int.TryParse(content.ToString(), out number))
                {
                    if (double.Parse(TextBlockResult.Text) == 0 && TextBlockResult.Text.Length == 1)
                    {
                        this.TextBlockResult.Text = number.ToString();
                    }
                    else
                    {
                        this.TextBlockResult.Text += number;
                    }
                }
                else
                {
                    calculator = new Calculator();
                }
            }
        }
    }
}
