using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.BusinessServices
{
    public class LibrosService
    {
        public List<Libros> GetAllLibrosByIdEstado(int idEstado)
        {
            var libros = new List<Libros>();
            using (var context = new SaqqaraContext())
            {
                libros =
                (
                    from libro in context.Libros
                    where libro.IdEstado == idEstado
                    select libro
                )
                .Include
                (
                    libro => libro.Estados
                )
                .Include
                (
                    libro => libro.Autores
                )
                .ToList();
            }
            return libros;
        }

        public ObservableCollection<Libros> GetLibrosParaEvaluacion()
        {
            ObservableCollection<Libros> libros;
            int idEstadoRecibido = (int)EstadosDeLibro.Recibido;
            int idEstadoEvaluado = (int)EstadosDeLibro.Evaluado;
            using (var context = new SaqqaraContext())
            {
                List<Libros> librosList =
                (
                    from libro in context.Libros
                    where libro.IdEstado == idEstadoEvaluado || libro.IdEstado == idEstadoRecibido
                    select libro
                )
                .Include
                (
                    libro => libro.Estados
                )
                .Include
                (
                    libro => libro.Autores
                )
                .ToList();
                libros = new ObservableCollection<Libros>(librosList);
            }
            return libros;
        }

        public bool EvaluarLibro(Libros libroEvaluado)
        {
            bool confirmacion = false;
            using (var context = new SaqqaraContext())
            {
                var query =
                    from libro in context.Libros
                    where libro.IdLibro == libroEvaluado.IdLibro
                    select libro;

                foreach (Libros libro in query)
                {
                    libro.Calificacion_EstructuraGeneral = libroEvaluado.Calificacion_EstructuraGeneral;
                    libro.Calificacion_Introduccion = libroEvaluado.Calificacion_Introduccion;
                    libro.Calificacion_CongruenciaMetodologica = libroEvaluado.Calificacion_CongruenciaMetodologica;
                    libro.Calificacion_Resultados = libroEvaluado.Calificacion_Resultados;
                    libro.Calificacion_LiteraturaCitada = libroEvaluado.Calificacion_LiteraturaCitada;
                    libro.IdEstado = libroEvaluado.Estados.IdEstado;
                    libro.Aprobado = libroEvaluado.Aprobado;
                }
                confirmacion = context.SaveChanges() > 0;
                return confirmacion;
            }
        }
    }
}
