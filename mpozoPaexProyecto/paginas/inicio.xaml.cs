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
        

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var valor = Preferences.Get("correo", "default_value");

            

            var result = await con.Table<Usuario>().FirstAsync(u => u.Correo == valor);

            if (result != null)
            {
                txtNombres.Text = "Bienvenido " + result.Nombres.ToString() + " " + result.Apellidos.ToString();
                txtCorreo.Text = "Tu correo es: " + result.Correo.ToString();
                txtId.Text = "Tu Id es: " + result.Id.ToString();
            }

            

        }
    }
}