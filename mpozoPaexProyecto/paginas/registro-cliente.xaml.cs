using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mpozoPaexProyecto.paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class registro_cliente : ContentPage
    {
        public string id_usuario;
        public registro_cliente(string usuario)
        {   
            Console.WriteLine("usuario:" + usuario);
            InitializeComponent();
            id_usuario = usuario;
        }

        private void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            try
            {

                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();

                
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("industria", txtIndustria.Text);
                parametros.Add("usuario", id_usuario);

                cliente.UploadValues("http://10.2.1.15/paex/post.php", "POST", parametros);
                DisplayAlert("Alerta", "Ingreso correcto", "Cancelar");

                Navigation.PushAsync(new paginas.principal());



            }
            catch
            {

            }
        }
    }
}