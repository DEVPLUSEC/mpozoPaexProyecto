using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SQLite;
using mpozoPaexProyecto.interfaces;
using System.IO;
using System.Globalization;
using mpozoPaexProyecto.modelos;
using mpozoPaexProyecto.paginas;

namespace mpozoPaexProyecto.eventos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class actualizar_eliminar_usuario : ContentPage
    {
        SQLiteAsyncConnection con;
        public int id_seleccion;
        IEnumerable<Usuario> usu_eliminar;
        IEnumerable<Usuario> usu_actualizar;
        public actualizar_eliminar_usuario(Usuario datos)
        {
            InitializeComponent();
            con = DependencyService.Get<DataBaseServer>().GetConnection();

            id_seleccion = datos.Id;

            txtNombres.Text = datos.Nombres.ToString();
            txtApellidos.Text = datos.Apellidos.ToString();
            txtEdad.Text = datos.Edad.ToString();
            txtCorreo.Text = datos.Correo.ToString();
            txtContrasena.Text = datos.Contrasena.ToString();


        }

        public static IEnumerable<Usuario> Eliminar(SQLiteConnection db, int id)
        {
            return db.Query<Usuario>("DELETE FROM Usuario where Id=?", id);
        }

        public static IEnumerable<Usuario> Actualizar(SQLiteConnection db, int id, string nombres, string apellidos, string edad, string correo, string contrasena)
        {
            return db.Query<Usuario>("UPDATE Usuario SET Nombres=?, Apellidos=?, Edad=?, Correo=?, Contrasena=? WHERE Id=?", nombres, apellidos, edad, correo, contrasena, id);

        }




        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "mpozo.db");
                var db = new SQLiteConnection(ruta);


                usu_actualizar = Actualizar(db, id_seleccion, txtNombres.Text, txtApellidos.Text, txtEdad.Text, txtCorreo.Text, txtContrasena.Text);


                DisplayAlert("Usuario actualizado", "", "Cerrar");
                Navigation.PushAsync(new paginas.principal());


            }
            catch (Exception)
            {
                Console.WriteLine("Error");

            }


        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {

            try
            {
                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "mpozo.db");
                var db = new SQLiteConnection(ruta);


                usu_eliminar = Eliminar(db, id_seleccion);


                DisplayAlert("Usuario eliminado", "", "Cerrar");
                Navigation.PushAsync(new paginas.principal());



            }
            catch (Exception)
            {
                Console.WriteLine("Error");

            }

        }

       

        
    }
}