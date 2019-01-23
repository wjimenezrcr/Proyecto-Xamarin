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
	public partial class LigasPage 
	{
        public ApiServiceLigas DataService { get; } = new ApiServiceLigas();
        public ObservableCollection<object> Items { get; set; } = new ObservableCollection<object>();
        public string Countries { get; set; }
        public Command RefrescarCommand { get; set; }

        private string _data = @"[
		{
           	""country"": ""World"",
			""league_id"": ""Argentina"",
            ""logo"": ""https://www.api-football.com/public/leagues/1.png"",
            ""name"": ""2018 Russia World Cup""
		}]";

        public string Data { get => _data; }

        public LigasPage (Ciudades ciudades)
		{
            BindingContext = this;

            Countries = ciudades.Nombre;

            IsBusy = true;
            RefrescarCommand = new Command(() => Refrescar(Countries));

            InitializeComponent ();

            ListViewDatos.ItemSelected += ListViewDatos_ItemSelected;
            
        }

        void ListViewDatos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedItem = e.SelectedItem;

            var Ligas = selectedItem as Ligas;

            Navigation.PushAsync(
                new EquiposPage(Ligas)
                );
        }


        private async void Refrescar(String Countries)
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
                    if (item.Ciudad == Countries)
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

            Refrescar(Countries);
        }
    }
}