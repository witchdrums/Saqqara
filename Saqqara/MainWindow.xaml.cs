using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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


namespace BibliotecaUniversidadDeSaqqara
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            UserControl initialUserControl = new UserControlArticulosPublicados();
            MainGrid.Children.Add(initialUserControl);
        }




        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserControl selectedUserControl = null;
            this.MainGrid.Children.Clear();
            string selectedItemName = ((ListViewItem)((ListView)sender).SelectedItem).Name;

            switch (selectedItemName)
            {
                case "ListViewItem_ArticulosPublicados":
                    selectedUserControl = new UserControlArticulosPublicados();
                    MainGrid.Children.Add(selectedUserControl);
                    break;
                case "ListViewItem_EvaluacionDeArticulos":
                    selectedUserControl = new UserControlEvaluacionDeArticulos();
                    MainGrid.Children.Add(selectedUserControl);
                    break;
            }

        }
    }
}
