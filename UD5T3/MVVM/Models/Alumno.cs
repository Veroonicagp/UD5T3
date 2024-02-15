using SQLite;

namespace UD5T3.MVVM.Models;
    [Table("Alumno")]
    public class Alumno
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [Column("Name"), NotNull]
        public string Name { get; set; }
        [Column("NIF"), MaxLength(9), Unique]
        public string NIF { get; set; }
        [Column("Empresa"), MaxLength(100)]
        public string Empresa { get; set; }


    }

