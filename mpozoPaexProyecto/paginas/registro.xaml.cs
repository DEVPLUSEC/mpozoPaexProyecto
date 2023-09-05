using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

// librerias
using SQLite;
using mpozoPaexProyecto.interfaces;
using mpozoPaexProyecto.modelos;
using System.IO;

namespace mpozoPaexProyecto.paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class registro : ContentPage
    {
        // variables de uso global
        private SQLiteAsyncConnection con;
        public registro()
        {
            InitializeComponent();

            // iniciar conexion
            con = DependencyService.Get<DataBaseServer>().GetConnection();

        }

        private void btnRegistrar_Clicked(object sender, EventArgs e)
        {

            var datos = new Usuario
            {
                Nombres = txtNombres.Text,
                Apellidos = txtApellidos.Text,
                Edad = txtEdad.Text,
                Correo = txtCorreo.Text,
                Contrasena = txtContrasena.Text,
            };

            con.InsertAsync(datos);
            DisplayAlert("Usuario registrado", "", "Cerrar");
            Navigation.PushAsync(new paginas.inicio_sesion());

        }
    }
}