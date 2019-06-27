using autos.Model;
using autos.Views;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace auto.ViewModel
{
    class AutoViewModel
    {
        private SQLiteConnection conec;
        private static AutoViewModel instance;
        public static AutoViewModel Instance
        {
            get
            {
                if (instance == null) { throw new Exception("Falta inicializar"); }
                return instance;
            }
        }

        public static void Inicializador(String filename) //CAMBIAR NOMBRE DEL FILENAME PARA RECIBIR LA VISTA DE LA APP
        {
            if (filename == null) { throw new ArgumentException(); }
            if (instance != null) { instance.conec.Close(); }
            instance = new AutoViewModel(filename);
        }

        private AutoViewModel(String DbPath)
        {
            conec = new SQLiteConnection(DbPath);
            conec.CreateTable<Auto>();
        }
        public String EstadoMensaje;

        public int AddNew(string producto, int cantidad, DateTime fecha)
        {
            int result = 0;

            try
            {
                result = conec.Insert(new Auto()
                {
                    Producto = producto,
                    Cantidad = cantidad,
                });
                EstadoMensaje = string.Format("Se ingresó corretamente"); //MENSAJE DE QUE SE INGRESO POR LA VISTA DE LA APP
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }

            return result;
        }

        public IEnumerable<Auto> GetAll()
        {
            try
            {
                return conec.Table<Auto>();
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }
            return Enumerable.Empty<Auto>();
        }


    }
}

