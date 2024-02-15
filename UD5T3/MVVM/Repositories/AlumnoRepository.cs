using SQLite;
using UD5T3.MVVM.Models;

namespace UD5T3.MVVM.Repositories
{
    public class AlumnoRepository
    {
        SQLiteConnection connection;

        public string StatusMessage { get; set; }

        public AlumnoRepository()
        {
            connection = new SQLiteConnection(Constantes.DatabasePath, Constantes.Flags);

            connection.CreateTable<Alumno>();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="alumno"></param>
        public void AddOrUpdate(Alumno alumno)
        {
            int result = 0;
            try
            {

                if (alumno.ID == 0)
                {

                    result = connection.Update(alumno);
                    StatusMessage = $"{result} row update";
                }
                else
                {

                    result = connection.Insert(alumno);
                    StatusMessage = $"{result} row add";
                }
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Alumno> GetAll()
        {
            List<Alumno> list = null;

            try
            {
                list = connection.Table<Alumno>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Alumno Get(int id)
        {
            Alumno alumno = null;
            try
            {
                alumno = connection.Table<Alumno>().FirstOrDefault(item => item.ID == id);
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
            return alumno;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            int result = 0;

            try
            {
                result = connection.Delete(Get(id));
                StatusMessage = $"{result} row deleted";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }
    }
}
