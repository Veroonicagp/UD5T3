using PropertyChanged;
using System.Windows.Input;
using UD5T3.MVVM.Models;

namespace UD5T3.MVVM.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class AlumnoViewModel
    {
        /// <summary>
        /// Lista de alumnos
        /// </summary>
        public List<Alumno> Alumnos { get; set; }


        /// <summary>
        /// muestra el alumno actual
        /// </summary>
        public Alumno AlumnoActual { get; set; }


        /// <summary>
        /// comando de añadir o editar
        /// </summary>
        public ICommand AddOrUpdate { get; set; }

        /// <summary>
        /// comando de eliminar
        /// </summary>
        public ICommand Delete { get; set; }


        /// <summary>
        /// comando detalles
        /// </summary>
        public ICommand Detalle { get; set; }

        /// <summary>
        /// creamos nuevo alumno
        /// </summary>
        public AlumnoViewModel()
        {
            Refresh();

            AlumnoActual = new Alumno();
            AddOrUpdate = new Command(() =>
            {
                App.AlumnoRepository.AddOrUpdate((AlumnoActual));
                Alert("Información", App.AlumnoRepository.StatusMessage);
                AlumnoActual = new Alumno();
                Refresh();
            });

            Delete = new Command((id) =>
            {

                Alumno alumno = App.AlumnoRepository.Get((int)id);
                App.AlumnoRepository.Delete(alumno.ID);
                Alert("Información", App.AlumnoRepository.StatusMessage);
                Refresh();
            });

            Detalle = new Command((id) =>
            {
                AlumnoActual = App.AlumnoRepository.Get(Int32.Parse(id.ToString()));
            });

        }

        /// <summary>
        /// alerta de confirmacion
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        private void Alert(string title, string message)
        {
            App.Current.MainPage.DisplayAlert(title, message, "OK");
        }


        /// <summary>
        /// refrescado
        /// </summary>
        private void Refresh()
        {
            Alumnos = App.AlumnoRepository.GetAll();
        }
    }
}
