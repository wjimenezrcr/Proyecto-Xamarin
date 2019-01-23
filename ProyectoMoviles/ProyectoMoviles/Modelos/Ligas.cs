using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ProyectoMoviles.Modelos
{
    public class Ligas
    {
        [JsonProperty(PropertyName = "country")]
        public string Ciudad { get; set; }

        [JsonProperty(PropertyName = "league_id")]
        public string Codigo { get; set; }
       
        [JsonProperty(PropertyName = "logo")]
        public string Logo { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Nombre { get; set; }
    }
}
