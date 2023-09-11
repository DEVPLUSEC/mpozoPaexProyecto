using mpozoPaexProyecto.interfaces;
using mpozoPaexProyecto.modelos;
using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using mpozoPaexProyecto.interfaces;
using mpozoPaexProyecto.modelos;
using System.IO;
using System.Collections.ObjectModel;
using static SQLite.SQLite3;

namespace mpozoPaexProyecto.paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class clientes : ContentPage
    {
        private const string Url = "http://10.2.1.15/paex/post.php";
        private readonly HttpClient cli = new HttpClient();
        private ObservableCollection<Cliente> list_cli;
        private SQLiteAsyncConnection con;
        public string id_usuario;

        public clientes()
        {
            InitializeComponent();
            
            con = DependencyService.Get<DataBaseServer>().GetConnection();


        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var valor = Preferences.Get("correo", "default_value");

            var result = await con.Table<Usuario>().FirstAsync(u => u.Correo == valor);

 
            id_usuario = result.Id.ToString();
            mostrar(id_usuario);


        }


        public async void mostrar(string usuario)
        {
            id_usuario = usuario.ToString();
            Console.WriteLine(usuario);
            var content = await cli.GetStringAsync(Url + "?usuario=" + usuario);
            List<Cliente> get_clientes = JsonConvert.DeserializeObject<List<Cliente>>(content);

            list_cli = new ObservableCollection<Cliente>(get_clientes);

            lista_clientes.ItemsSource = list_cli;

        }

        private void lista_clientes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var objeto = (Cliente)e.SelectedItem;

            Navigation.PushAsync(new eventos.actualizar_eliminar_cliente(objeto));
        }

        private void btnRegistro_Clicked(object sender, EventArgs e)
        {
            Console.WriteLine(id_usuario);
            Navigation.PushAsync(new paginas.registro_cliente(id_usuario));

        }
    }
}