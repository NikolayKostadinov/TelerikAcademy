using System.Windows;
using System.Windows.Controls;
using Names_Manager_Demo.ViewModels;

namespace Names_Manager_Demo
{
    /// <summary>
    /// Interaction logic for ListNamesUserControl.xaml
    /// </summary>
    public partial class ListNamesUserControl : UserControl
    {
        private ViewModel viewModel;

        public ListNamesUserControl()
        {
            InitializeComponent(); 
            this.viewModel = new ViewModel();
            this.DataContext = viewModel;
        }

        private void ButtonAddNew_Click(object sender, RoutedEventArgs e)
        {
            string newName = TextBoxNewName.Text;
            if (string.IsNullOrEmpty(newName))
            {
                MessageBox.Show("Invalid Name");
                return;
            }
            viewModel.AddNewName(newName);
            this.TextBoxNewName.Text = string.Empty;
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (this.ListViewNames.SelectedIndex >= 0)
            {
                var itemToDelete = ListViewNames.SelectedItem;
                var nameToDelete = itemToDelete.ToString();
                this.viewModel.DeleteName(nameToDelete);
            }
            else
            {
                MessageBox.Show("Please select a name to delete");
                return;
            }
        }
    }
}