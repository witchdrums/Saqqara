using BusinessLayer;
using BusinessLayer.BusinessServices;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace BibliotecaUniversidadDeSaqqara
{
    /// <summary>
    /// Interaction logic for UserControlArticulosPublicados.xaml
    /// </summary>
    public partial class UserControlArticulosPublicados : UserControl
    {
        public UserControlArticulosPublicados()
        {
            InitializeComponent();

            LibrosService librosService = new LibrosService();

            ObservableCollection<Libros> _libros = new ObservableCollection<Libros>(librosService.GetAllLibrosByIdEstado((int)EstadosDeLibro.Liberado));
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
