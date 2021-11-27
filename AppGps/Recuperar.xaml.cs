using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
    public partial class Recuperar : ContentPage
    {
        private readonly HttpClient client = new HttpClient();
        public static AppGps.Ws.Usuarios Json { get; set; }
        public Recuperar()
        {
            InitializeComponent();
        }

        private async void btnRecuperar_Clicked(object sender, EventArgs e)
        {
            Uri requestUri = new Uri("http://192.168.100.33/api/usuario/post.php?correo=" + txtEmail.Text);

            var resultado = await client.GetAsync(requestUri);

            if (resultado.IsSuccessStatusCode)
            {
                string PlacesJson = resultado.Content.ReadAsStringAsync().Result;
                if (PlacesJson.Length > 10)
                {

                    Json = JsonConvert.DeserializeObject<AppGps.Ws.Usuarios>(PlacesJson);
                    WebClient clienteWeb = new WebClient();
                    var parametros = new System.Collections.Specialized.NameValueCollection();
                    int idUser = Json.id;
                    
                    parametros.Set("contrasena", txtPassword.Text);
                    clienteWeb.UploadValues("http://192.168.100.33/api/usuario/post.php?id+" + idUser, "PUT", parametros);
                    await DisplayAlert("Mensaje", "El registro ha sido actualizado con exito", "OK");
                    await Navigation.PushAsync(new MainPage());
                }
                else
                {
                    await DisplayAlert("Error", "Usuario no encocntrado", "OK");

                }
            }
        }
    }
}