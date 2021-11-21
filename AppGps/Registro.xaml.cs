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
    public partial class Registro : ContentPage
    {
        /*private const string Url = "http://127.0.0.1/moviles/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<AppGps.Ws.Usuarios> _post;*/
        public Registro()
        {
            InitializeComponent();
            
        }

        

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                
                parametros.Add("nombres", txtNombres.Text);
                parametros.Add("apellidos", txtApellidos.Text);
                parametros.Add("correo", txtCorreo.Text);
                parametros.Add("usuario", txtUsuario.Text);
                parametros.Add("contrasena", txtContrasena.Text);
                parametros.Add("placa", txtPlaca.Text);
                parametros.Add("modelo", txtModelo.Text);


                cliente.UploadValues("http://192.168.100.33/api/usuario/post.php", "POST", parametros);
                await DisplayAlert("Mesaje", "El registro exitoso", "OK");

                await Navigation.PushAsync(new Login());


            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");

            }

        }
    }
}