using BusinessLayer.BusinessServices;
using BusinessLayer;
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
    /// Interaction logic for UserControlArticulosRechazados.xaml
    /// </summary>
    public partial class UserControlArticulosRechazados : UserControl
    {
        public UserControlArticulosRechazados()
        {
            InitializeComponent();
            LibrosService librosService = new LibrosService();

            int idEstadoRechazado = (int)EstadosDeLibro.Rechazado;
            ObservableCollection<Libros> _libros = new ObservableCollection<Libros>(librosService.GetAllLibrosByIdEstado(idEstadoRechazado));
            this.librosDataGrid.DataContext = _libros;
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
    }
}
