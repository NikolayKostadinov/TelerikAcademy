using PhonesStore.ViewModels;
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

namespace ICollectionView.Filtering
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

        public void OnSortButtonClick(object sender, RoutedEventArgs e)
        {
            (this.DataContext as PhonesStoreViewModel).Sort();
        }

        public void OnFilterButtonClick(object sender, RoutedEventArgs e)
        {
            var filterText = this.TextBoxFilter.Text;
            if (filterText != null)
            {
                (this.DataContext as PhonesStoreViewModel).Filter(filterText);
            }
        }

        private void OnTextBoxFilterKeyUp(object sender, KeyEventArgs e)
        {
            var filterText = this.TextBoxFilter.Text;
            if (filterText != null)
            {
                (this.DataContext as PhonesStoreViewModel).Filter(filterText);
            }
        }
    }
}