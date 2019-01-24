using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ProyectoMoviles.Modelos;
using ProyectoMoviles.Servicios;
using System.Collections.ObjectModel;
using Plugin.Connectivity;


namespace ProyectoMoviles
{
	public partial class EquiposPage
	{
        public ApiServiceEquipos DataService { get; } = new ApiServiceEquipos();
        public ObservableCollection<object> Items { get; set; } = new ObservableCollection<object>();
        public string Ligas { get; set; }
        public string Nombre_Ligas { get; set; }
        public Command RefrescarCommand { get; set; }

        private string _data = @"[
		{
           	""league_id"": ""6"",
			""team_id"": ""117"",
            ""teamName"": ""Atletico Mineiro"",
            ""play"": ""12"",
            ""win"": ""7"",
            ""draw"": ""2"",
            ""lose"": ""3"",
            ""goalsFor"": ""24"",
            ""goalsAgainst"": ""17"",
            ""goalsDiff"": ""7"",
            ""points"": ""23"",
            ""logo"": ""https://upload.wikimedia.org/wikipedia/commons/a/a9/Clube_Atletico_Itapemirim_branco_-_Copia_%282%29.jpg""
		}]";

        public string Data { get => _data; }

        public EquiposPage (Ligas CodigoLiga)
		{
            BindingContext = this;

            Ligas = CodigoLiga.Codigo;

            Nombre_Ligas = CodigoLiga.Nombre;

            IsBusy = true;
            RefrescarCommand = new Command(() => Refrescar(Ligas));

            InitializeComponent ();

            ListViewDatos.ItemSelected += ListViewDatos_ItemSelected;
        }

        void ListViewDatos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedItem = e.SelectedItem;

            var Equipos = selectedItem as Equipos;

            Navigation.PushAsync(
                new DetalleEquipoPage(Equipos)
                );
        }

     
        private async void Refrescar(String Codigo)
        {
            IsBusy = false;


            if (!CrossConnectivity.Current.IsConnected)
            {
                await DisplayAlert("Imposible continuar", "No hay conexion a internet", "Continuar");
                return;
            }
            try
            {
                Items.Clear();
                
                var data = await DataService.GetStringAsync();

                foreach (var item in data)
                {
                    if (item.LigaID == Codigo)
                    {
                        Items.Add(item);
                    }

                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ha ocurrido un error", ex.Message, "Continuar");
            }
            finally
            {
                IsBusy = false;
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Refrescar(Ligas);
        }
    }
}