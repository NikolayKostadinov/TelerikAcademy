using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StackingPanelsWPF
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

        private void ShowWrapButton_Click(object sender, RoutedEventArgs e)
        {
            this.WrapPanelControl.Visibility = Visibility.Visible;
            this.DockPanelControl.Visibility = Visibility.Collapsed;
        }

        private void ShowDockButton_Click(object sender, RoutedEventArgs e)
        {
            this.WrapPanelControl.Visibility = Visibility.Collapsed;
            this.DockPanelControl.Visibility = Visibility.Visible;

        }
    }
}
