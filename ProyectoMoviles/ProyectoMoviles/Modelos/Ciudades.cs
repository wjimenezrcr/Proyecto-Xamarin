using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ProyectoMoviles.Modelos
{
    class Ciudades
    {
        [JsonProperty(PropertyName = "Name")]
        public string Nombre { get; set; }

        [JsonProperty(PropertyName = "Price")]
        public double Precio { get; set; }

        [JsonProperty(PropertyName = "Quantity")]
        public decimal Cantidad { get; set; }

        public string RutaImagen { get; set; } = "https://cdn0.iconfinder.com/data/icons/business-mix/512/cargo-512.png";
    }
}
