using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace autos.Model
{
         [Table("Listado")]
    public class Ventas
    {
        [PrimaryKey, AutoIncrement]
        public string Producto { get; set; }
        [MaxLength(70)]
        public string Cantidad { get; set; }


    }
}
