using mpozoPaexProyecto.modelos;
using mpozoPaexProyecto.paginas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mpozoPaexProyecto.eventos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class actualizar_eliminar_cliente : ContentPage
    {
        public int id_seleccion;
        public actualizar_eliminar_cliente(Cliente datos)
        {
            InitializeComponent();
            txtNombre.Text = datos.nombre.ToString();
            txtIndustria.Text = datos.industria.ToString();
            id_seleccion = datos.id;
        }

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {

                WebClient cliente = new WebClient();

                var parametros = new System.Collections.Specialized.NameValueCollection();

                parametros.Add("id", id_seleccion.ToString());
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("industria", txtIndustria.Text);
                

                cliente.UploadValues("http://10.2.2.1/paex/post.php?id=" + id_seleccion.ToString() + "&nombre=" + txtNombre.Text + "&industria=" + txtIndustria.Text, "PUT", parametros);

                Navigation.PushAsync(new paginas.principal());

                DisplayAlert("Cliente Actualizado", "", "Cerrar");


            }
            catch
            {

            }

        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {

                WebClient cliente = new WebClient();

                var parametros = new System.Collections.Specialized.NameValueCollection();

                parametros.Add("id", id_seleccion.ToString());

                cliente.UploadValues("http://10.2.2.1/paex/post.php?id=" + id_seleccion.ToString(), "DELETE", parametros);

                Navigation.PushAsync(new paginas.principal());

                DisplayAlert("Cliente eliminado", "", "Cerrar");



            }
            catch
            {

            }

        }
    }
}