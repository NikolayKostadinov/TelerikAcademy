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
using CountryInfoSystem.ViewModel;

namespace CountryInfoSystem
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

        private void PrevCity_Click(object sender, RoutedEventArgs e)
        {
            var dataContext = this.GetDataContext();
            dataContext.PrevCity();
        }

        private void NextCity_Click(object sender, RoutedEventArgs e)
        {
            var dataContext = this.GetDataContext();
            dataContext.NextCity();
        }

        private WorlViewModel GetDataContext()
        {
            var dataContext = this.DataContext;
            return dataContext as WorlViewModel;
        }

        private void PrevCountry_Click(object sender, RoutedEventArgs e)
        {
            var dataContext = this.GetDataContext();
            dataContext.PrevCountry();
        }



        private void NextCountry_Click(object sender, RoutedEventArgs e)
        {
            var dataContext = this.GetDataContext();
            dataContext.NextCountry();
        }
    }
}
