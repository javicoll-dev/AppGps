using AppGps.Ws;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGps
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private const string url = "http://192.168.100.33/api/usuario/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<AppGps.Ws.Usuarios> _usuario;
        //private List<Login> MyList = new List<Login>;
        public Login()
        {
            InitializeComponent();
            limpiarLogin();
        }

        private async void btnIngresar_Clicked(object sender, EventArgs e)
        {


            /*var content = await client.GetStringAsync(url);
            List<AppGps.Ws.Usuarios> lista = JsonConvert.DeserializeObject<List<AppGps.Ws.Usuarios>>(content);
            _usuario = new ObservableCollection<AppGps.Ws.Usuarios>(lista);

            MyList = _usuario;*/
            Uri requestUri = new Uri("http://192.168.100.33/api/usuario/post.php");

            Usuarios login = new Usuarios 
            {
                usuario = txtUsuario.Text,
                contrasena = txtPassword.Text
            };

            var json = JsonConvert.SerializeObject(login);
            var contentJson = new StringContent(json,Encoding.UTF8, "aplication/json");
            var response = await client.PostAsync(requestUri, contentJson);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                await Navigation.PushAsync(new MainPage());
            }
            else
            {
                await DisplayAlert("Error", "Sus credenciales son invalidas", "OK");
            }
        }

        private async void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Registro());
        }

        private void limpiarLogin()
        {
            txtUsuario.Text = "";
            txtPassword.Text = "";
        }
    }
}