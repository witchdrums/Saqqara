using BusinessLayer;
using BusinessLayer.BusinessServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Interaction logic for UserControlEvaluacionDeArticulos.xaml
    /// </summary>
    public partial class UserControlEvaluacionDeArticulos : UserControl
    {
        public UserControlEvaluacionDeArticulos()
        {
            InitializeComponent();

            LibrosService librosService = new LibrosService();
            this.librosDataGrid.DataContext = librosService.GetLibrosParaEvaluacion();

        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double calificacionTotalActual = Int32.Parse(this.Label_CalificacionTotal.Content.ToString());
            calificacionTotalActual += e.NewValue - e.OldValue;
            this.Label_CalificacionTotal.Content = calificacionTotalActual;

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

        private void librosDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Libros selectedLibro = ((Libros)((DataGrid)sender).SelectedValue);
            this.TextBlock_Titulo.Text = selectedLibro.Titulo;
            this.TextBlock_Datos.Text =
                selectedLibro.NombresAutores + " || " +
                selectedLibro.NombreEstado + " " +
                selectedLibro.FechaDeRecepcion;

            this.Slider_EstructuraGeneral.Value = selectedLibro.Calificacion_EstructuraGeneral;
            this.Slider_Introduccion.Value = selectedLibro.Calificacion_Introduccion;
            this.Slider_CongruenciaMetodologica.Value = selectedLibro.Calificacion_CongruenciaMetodologica;
            this.Slider_Resultados.Value = selectedLibro.Calificacion_Resultados;
            this.Slider_LiteraturaCitada.Value = selectedLibro.Calificacion_LiteraturaCitada;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Libros selectedLibro = ((Libros)((DataGrid)this.librosDataGrid).SelectedValue);
            selectedLibro.Calificacion_EstructuraGeneral = (int)this.Slider_EstructuraGeneral.Value;
            selectedLibro.Calificacion_Introduccion = (int)this.Slider_Introduccion.Value;
            selectedLibro.Calificacion_CongruenciaMetodologica = (int)this.Slider_CongruenciaMetodologica.Value;
            selectedLibro.Calificacion_Resultados = (int)this.Slider_Resultados.Value;
            selectedLibro.Calificacion_LiteraturaCitada = (int)this.Slider_LiteraturaCitada.Value;
            selectedLibro.Aprobar();
            selectedLibro.SetEstadoDeEvaluacion(this.RadioButton_Si.IsChecked == true);
            this.librosDataGrid.Items.Refresh();

            LibrosService librosService = new LibrosService();
            librosService.EvaluarLibro(selectedLibro);
        }

    }
}
