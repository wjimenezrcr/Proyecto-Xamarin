using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ProyectoMoviles.Modelos
{
    public class Ciudades
    {
        [JsonProperty(PropertyName = "id")]
        public string Codigo { get; set; }

        [JsonProperty(PropertyName = "nombre")]
        public string Nombre { get; set; }


    }
}
