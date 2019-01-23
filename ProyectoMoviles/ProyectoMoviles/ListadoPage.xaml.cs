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
	public partial class ListadoPage
	{
        public ApiService DataService { get;} = new ApiService();
        public ObservableCollection<object> Items { get; set; } = new ObservableCollection<object>();
        public Command RefrescarCommand { get; set; }
       
        private string _data = @"[
		{
			""id"": ""1"",
			""nombre"": ""Argentina""
		}]";

        public string Data { get => _data; }

        public ListadoPage ()
		{
            BindingContext = this;
            IsBusy = true;
            RefrescarCommand = new Command(() => Refrescar());

            InitializeComponent ();

            ListViewDatos.ItemSelected += ListViewDatos_ItemSelected;
        }

        void ListViewDatos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedItem = e.SelectedItem;

            var ciudades = selectedItem as Ciudades;

            Navigation.PushAsync(
                new LigasPage(ciudades)
                );

            //Navigation.PushAsync(new PaginaTabs());
        }

        private async void Refrescar()
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
                    Items.Add(item);
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

            Refrescar();
        }
    }
}