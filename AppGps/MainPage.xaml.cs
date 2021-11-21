using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Collections.ObjectModel;
using System.Net.Http;
using Newtonsoft.Json;

namespace AppGps
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {

        private const string Url = "http://192.168.100.33/api/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<AppGps.Ws.Parqueadero> _post;

        public MainPage()
        {
            InitializeComponent();
            get();
        }

        public async void get()
        {
            try
            {
                var content = await client.GetStringAsync(Url);
                List<AppGps.Ws.Parqueadero> posts = JsonConvert.DeserializeObject<List<AppGps.Ws.Parqueadero>>(content);
                _post = new ObservableCollection<AppGps.Ws.Parqueadero>(posts);

                MyListView.ItemsSource = _post;

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "ERROR" + ex.Message, "OK");
            }

        }

        

      

        private async void MyListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var detalles = e.Item as Ws.Parqueadero;
            //await Navigation.PushAsync(new VistaActualizar(detalles.codigo, detalles.nombre, detalles.apellido, detalles.edad));


            string lugar = detalles.establecimiento;
            string lati = Convert.ToString(detalles.latitud);
            string longi = Convert.ToString(detalles.longitud);

            if (!double.TryParse(lati, out double lat))
                return;
            if (!double.TryParse(longi, out double lng))
                return;
            await Map.OpenAsync(lat, lng, new MapLaunchOptions
            {
                Name = lugar,
                NavigationMode = NavigationMode.None

            });
        }

        private async void btnSalir_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Login());
        }
    }
}
