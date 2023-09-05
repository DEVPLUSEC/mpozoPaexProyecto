using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// librerias
using SQLite;
using mpozoPaexProyecto.interfaces;
using System.IO;
using mpozoPaexProyecto.Droid.DataBase;

// Ejecutar y leer proyecto
[assembly: Xamarin.Forms.Dependency(typeof(DataBaseClient))]

namespace mpozoPaexProyecto.Droid.DataBase
{
    public class DataBaseClient : DataBaseServer
    {
        public SQLiteAsyncConnection GetConnection()
        {
            // Ruta de guardado de base de datos
            var ruta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);

            // Crear base de datos
            var baseDatos = Path.Combine(ruta, "mpozo.db");

            // retorno de la conexion
            return new SQLiteAsyncConnection(baseDatos);


        }
    }
}