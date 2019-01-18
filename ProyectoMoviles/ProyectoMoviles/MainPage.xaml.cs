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
        public Command NavegarCommand1 { get; set; }
        public Command NavegarCommand2 { get; set; }
        public Command NavegarCommand3 { get; set; }
        public Command NavegarCommand4 { get; set; }
        public Command NavegarCommand5 { get; set; }

        public MainPage()
        {
            InitializeComponent();

            NavegarCommand1 = new Command(() => {

                //Navigation.PushAsync(new PaginaTabs());
                DisplayAlert("Mensaje por comando", "Africa!", "Terminar");
            });

            botonNavegar1.Command = NavegarCommand1;

            NavegarCommand2 = new Command(() => {

                //Navigation.PushAsync(new PaginaTabs());
                DisplayAlert("Mensaje por comando", "Europa!", "Terminar");
            });

            botonNavegar2.Command = NavegarCommand2;

            NavegarCommand3 = new Command(() => {

                //Navigation.PushAsync(new PaginaTabs());
                DisplayAlert("Mensaje por comando", "Asia!", "Terminar");
            });


    
            botonNavegar3.Command = NavegarCommand3;

            NavegarCommand4 = new Command(() => {

                //Navigation.PushAsync(new PaginaTabs());
                DisplayAlert("Mensaje por comando", "America!", "Terminar");
            });

            botonNavegar4.Command = NavegarCommand4;

            NavegarCommand5 = new Command(() => {

                //Navigation.PushAsync(new PaginaTabs());
                DisplayAlert("Mensaje por comando", "Oceania!", "Terminar");
            });

            botonNavegar5.Command = NavegarCommand5;

            
        }

        
    }
}
