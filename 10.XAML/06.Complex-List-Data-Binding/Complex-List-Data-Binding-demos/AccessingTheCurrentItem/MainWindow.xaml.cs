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
using PhonesStore.ViewModels;
using PhonesStore.ViewModels;

namespace AccessingTheCurrentItem
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

        private void OnPrevButtonClick(object sender, RoutedEventArgs e)
        {
            var dataContext = this.GetDataContext();
            dataContext.Prev();
        }

        private void OnNextButtonClick(object sender, RoutedEventArgs e)
        {
            var dataContext = this.GetDataContext();
            dataContext.Next();
        }

        private PhonesStoreViewModel GetDataContext()
        {
            var dataContext = this.DataContext;
            return dataContext as PhonesStoreViewModel;
        }
    }
}