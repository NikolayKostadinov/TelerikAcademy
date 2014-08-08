using System;
using System.Collections.Generic;
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

namespace _01.ChangingFontSize
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            if (sender is Button)
            {
                switch ((sender as Button).Name)
                {
                    case ("ButtonToLowest"):
                        this.SliderSize.Value = 6;
                        break;
                    case ("ButtonToMiddle"):
                        this.SliderSize.Value = 12;
                        break;
                    case ("ButtonToLargest"):
                        this.SliderSize.Value = 30;
                        break;
                    default: throw new InvalidOperationException("Command Not supported");
                }
            }

        }
    }
}
