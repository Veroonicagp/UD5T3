using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UD5T3.MVVM
{
    public static class Constantes
    {
        // Nombre del archivo que vamos a almacenar en el dispositivo
        private const string DBFilename = "SQLite.db3";

        // Comportamiento sobre el archivo:
        // - Permite abrir el archivo de la base de datos en modo de lectura-escritura
        // - Crea la base de datos en caso de que no exista.
        // - Permite el acceso a la base de datos multihilo
        public const SQLiteOpenFlags Flags =
            SQLiteOpenFlags.ReadWrite |
            SQLiteOpenFlags.Create |
            SQLiteOpenFlags.SharedCache;

        //Configuracion de la ruta hacia el archivo de base de datos
        // teniendo en cuenta la plataforma
        public static string DatabasePath
        {
            get
            {
                return Path.Combine(FileSystem.AppDataDirectory, DBFilename);
            }
        }
    }
}
