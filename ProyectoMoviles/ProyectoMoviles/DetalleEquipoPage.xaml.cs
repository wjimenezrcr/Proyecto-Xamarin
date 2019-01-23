using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ProyectoMoviles.Modelos;
using ProyectoMoviles.Servicios;


namespace ProyectoMoviles
{
	public partial class DetalleEquipoPage : ContentPage
	{
		public DetalleEquipoPage (Equipos Equipos)
		{
            // 1) BindingContext alimenta la pantalla
            
            BindingContext = Equipos;

            InitializeComponent();
		}
	}
}