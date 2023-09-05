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
    public partial class inicio_sesion : ContentPage
    {
        // variables de uso global
        private SQLiteAsyncConnection con;
        public inicio_sesion()
        {
            InitializeComponent();
            // iniciar conexion a base de datos
            con = DependencyService.Get<DataBaseServer>().GetConnection();
        }

        // funcion sql para verificar usuarios
        public static IEnumerable<Usuario> select_where(SQLiteConnection db, string correo, string contrasena)
        {
            return db.Query<Usuario>("SELECT * FROM Usuario WHERE Correo=? and Contrasena=?", correo, contrasena);

        }

        private void btnIniciar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "mpozo.db");
                var db = new SQLiteConnection(ruta);

                db.CreateTable<Usuario>();

                IEnumerable<Usuario> resultado = select_where(db, txtEmail.Text, txtContrasena.Text);

                if (resultado.Count() > 0)
                {
                    Navigation.PushAsync(new paginas.principal(txtEmail.Text));

                }
                else
                {
                    DisplayAlert("Usuario o contraseña incorrectas", "", "Cerrar");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error");

            }
        }

        private void btnRegistro_Clicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new paginas.registro());
        }

    
    }
}