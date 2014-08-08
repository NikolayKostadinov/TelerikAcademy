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

namespace _03.ItemsSelection
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

        private void OnCheckBoxChecked(object sender, RoutedEventArgs e)
        {
            this.TextBlockResult.Text += (sender as CheckBox).Content.ToString() + "\n";
        }

        private void OnCheckBoxUnChecked(object sender, RoutedEventArgs e)
        {
            this.TextBlockResult.Text = this.TextBlockResult.Text.Replace((sender as CheckBox).Content.ToString() + "\n", string.Empty);
        }
    }
}
