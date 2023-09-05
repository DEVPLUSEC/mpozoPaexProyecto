using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SQLite;
using mpozoPaexProyecto.interfaces;
using mpozoPaexProyecto.modelos;
using System.Collections.ObjectModel;

namespace mpozoPaexProyecto.paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class usuarios : ContentPage
    {
        SQLiteAsyncConnection con;
        ObservableCollection<Usuario> tUsuario;
        public usuarios()
        {
            InitializeComponent();
            con = DependencyService.Get<DataBaseServer>().GetConnection();
            mostrar();
        }

        public async void mostrar()
        {
            var resultado = await con.Table<Usuario>().ToListAsync();
            tUsuario = new ObservableCollection<Usuario>(resultado);
            listaUsuarios.ItemsSource = tUsuario;


        }

        private void listaUsuarios_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}