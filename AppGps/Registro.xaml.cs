using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
        private const string Url = "http://127.0.0.1/moviles/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<AppGps.Ws.Usuarios> _post;
        public Registro()
        {
            InitializeComponent();
            
        }

        private async void btnGet_Clicked(object sender, EventArgs e)
        {
            var content = await client.GetStringAsync(Url);
            List<AppGps.Ws.Usuarios> posts = JsonConvert.DeserializeObject<List<AppGps.Ws.Usuarios>>(content);
            _post = new ObservableCollection<AppGps.Ws.Usuarios>(posts);

            MyListView.ItemsSource = _post;

        }
    }
}