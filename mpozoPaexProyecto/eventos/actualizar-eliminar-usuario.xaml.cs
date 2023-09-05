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

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {

        }
    }
}