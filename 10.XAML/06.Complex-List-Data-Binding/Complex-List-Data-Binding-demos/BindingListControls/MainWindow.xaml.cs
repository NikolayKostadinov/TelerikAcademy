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
using System.Linq;
using System.Collections.Generic;
using PhonesStore.ViewModels;

namespace BindingListControls
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

        private void OnPhonesComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var message = "";
            foreach (var item in e.AddedItems)
            {
                message +=
                    (item as PhoneViewModel).Model +
                    "\n";
            }
            MessageBox.Show(message);
        }

        private void OnPhonesListBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var message = "";
            foreach (var item in e.AddedItems)
            {
                message +=
                    (item as PhoneViewModel).Model +
                    "\n";
            }
            MessageBox.Show(message);
        }

        private void OnPhonesTabControlSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var message = "";
            foreach (var item in e.AddedItems)
            {
                message +=
                    (item as PhoneViewModel).Model +
                    "\n";
            }
            MessageBox.Show(message);
        }

        private void OnPhonesListViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var message = "";
            foreach (var item in e.AddedItems)
            {
                message +=
                    (item as PhoneViewModel).Model +
                    "\n";
            }
            MessageBox.Show(message);
        }
    }
}
