using mpozoPaexProyecto.modelos;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

// librerias
using SQLite;
using mpozoPaexProyecto.interfaces;
using mpozoPaexProyecto.modelos;
using System.IO;
using System.Collections.ObjectModel;

namespace mpozoPaexProyecto.paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class inicio : ContentPage
    {
        // VARIABLES GLOBALES
        private SQLiteAsyncConnection con;
        
        public inicio()
        {
            InitializeComponent();
            con = DependencyService.Get<DataBaseServer>().GetConnection();



        }

        // funcion sql
        public static IEnumerable<Usuario> select_where(SQLiteConnection db, string correo)
        {
            return db.Query<Usuario>("SELECT * FROM Usuario where Correo=? ", correo);

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var valor = Preferences.Get("correo", "default_value");
            txtCorreo.Text = "Bienvenido " + valor; // show value for Label in second page

            var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "mpozo.db");
            var db = new SQLiteConnection(ruta);

            db.CreateTable<Usuario>();

            IEnumerable<Usuario> resultado = select_where(db, valor);
            

            Console.WriteLine("Resultado", resultado);

        }
    }
}