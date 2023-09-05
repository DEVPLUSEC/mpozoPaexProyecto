using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace mpozoPaexProyecto.paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class principal : Xamarin.Forms.TabbedPage
    {
        public principal(string correo)
        {
            InitializeComponent();
            On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
            On<Android>().SetIsSmoothScrollEnabled(true);

            var inputText = correo; //get value from Entry
            Preferences.Set("correo", inputText);

        }
    }
}