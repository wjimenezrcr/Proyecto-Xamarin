using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProyectoMoviles
{
    public partial class MainPage : ContentPage
    {
        public Command AbrirListado { get; set; }

        public MainPage()
        {
            BindingContext = this;

            AbrirListado = new Command(() => MostrarListadoPaises());

            InitializeComponent();
            
        }

        private void MostrarListadoPaises()
        {
            var Listado = new ListadoPage();

            Navigation.PushAsync(Listado);
        }


    }
}
