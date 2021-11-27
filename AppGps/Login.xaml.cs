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
        //private const string url = "http://192.168.100.33/api/usuario/post.php";
        private readonly HttpClient client = new HttpClient();
        //private ObservableCollection<AppGps.Ws.Usuarios> _usuario;
        public static AppGps.Ws.Usuarios Json { get; set; }
        //private List<Login> MyList = new List<Login>;
        public Login()
        {
            InitializeComponent();
            limpiarLogin();
        }

        private async void btnIngresar_Clicked(object sender, EventArgs e)
        {


            
            Uri requestUri = new Uri("http://192.168.100.33/api/usuario/post.php?correo="+txtUsuario.Text+"&contrasena="+txtPassword.Text+"");

            Usuarios login = new Usuarios 
            {
                usuario = txtUsuario.Text,
                contrasena = txtPassword.Text
            };


            //var resultado = await client.GetAsync(String.Concat(requestUri, login.usuario, login.contrasena));
            var resultado = await client.GetAsync(requestUri);

            if (resultado.IsSuccessStatusCode)
            {
                string PlacesJson = resultado.Content.ReadAsStringAsync().Result;
                if (PlacesJson.Length > 10) 
                {

                    Json = JsonConvert.DeserializeObject<AppGps.Ws.Usuarios>(PlacesJson);
                    await Navigation.PushAsync(new MainPage());
                }
                else
                {
                    await DisplayAlert("Error", "Usuario no encontrado", "OK");

                }
                
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

        private async void btnRecuperar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Recuperar());
        }
    }
}