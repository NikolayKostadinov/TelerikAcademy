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

namespace TabControl_Demo
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
        private void ShowGridButton_Click(object sender, RoutedEventArgs e)
        {
            this.GridPanelControl.Visibility = Visibility.Visible;
            this.UniformGridPanelControl.Visibility = Visibility.Collapsed;
        }

        private void ShowUniformGridButton_Click(object sender, RoutedEventArgs e)
        {
            this.UniformGridPanelControl.Visibility = Visibility.Visible;
            this.GridPanelControl.Visibility = Visibility.Collapsed;
        }
    }
}
