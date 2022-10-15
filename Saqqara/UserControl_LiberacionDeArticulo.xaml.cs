using BusinessLayer.BusinessServices;
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
using BusinessLayer;

namespace Saqqara
{
    /// <summary>
    /// Interaction logic for UserControl_LiberacionDeArticulo.xaml
    /// </summary>
    public partial class UserControl_LiberacionDeArticulo : UserControl
    {
        public UserControl_LiberacionDeArticulo()
        {
            InitializeComponent();

            int idEstadoEvaluado = (int)EstadosDeLibro.Evaluado;
            LibrosService librosService = new LibrosService();
            

            this.librosDataGrid.DataContext = librosService.GetAllLibrosByIdEstado(idEstadoEvaluado);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            // Do not load your data at design time.
            // if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            // {
            // 	//Load your data here and assign the result to the CollectionViewSource.
            // 	System.Windows.Data.CollectionViewSource myCollectionViewSource = (System.Windows.Data.CollectionViewSource)this.Resources["Resource Key for CollectionViewSource"];
            // 	myCollectionViewSource.Source = your data
            // }
        }

        private void Button_LiberarArticulo_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("La liberacion de un articulo permite la publicacion en linea. Esta seguro de la liberacion?",
                    "Liberar articulo",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                int idSelectedLibro = ((Libros)this.librosDataGrid.SelectedValue).IdLibro;
                int idEstadoLiberado = (int)EstadosDeLibro.Liberado;
                LibrosService librosService = new LibrosService();
                bool liberacionConfirmation = 
                    librosService.UpdateIdEstadoOfLibroByIdLibro(idSelectedLibro, idEstadoLiberado);
                if (liberacionConfirmation)
                {
                    MessageBox.Show("El articulo fue liberado exitosamente");
                }
            }
        }

        private void librosDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.Button_LiberarArticulo.IsEnabled = true;
        }
    }
}
