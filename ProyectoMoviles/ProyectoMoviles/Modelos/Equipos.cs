using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ProyectoMoviles.Modelos
{
    public class Equipos
    {
        [JsonProperty(PropertyName = "league_id")]
        public string LigaID { get; set; }

        [JsonProperty(PropertyName = "team_id")]
        public string EquipoID { get; set; }

        [JsonProperty(PropertyName = "teamName")]
        public string Nombre { get; set; }

        [JsonProperty(PropertyName = "play")]
        public string Partidos { get; set; }

        [JsonProperty(PropertyName = "win")]
        public string Ganados { get; set; }

        [JsonProperty(PropertyName = "draw")]
        public string Empatados { get; set; }

        [JsonProperty(PropertyName = "lose")]
        public string Perdidos { get; set; }

        [JsonProperty(PropertyName = "goalsFor")]
        public string Golesfavor { get; set; }

        [JsonProperty(PropertyName = "goalsAgainst")]
        public string Golescontra { get; set; }

        [JsonProperty(PropertyName = "goalsDiff")]
        public string Golesdiferencia { get; set; }

        [JsonProperty(PropertyName = "points")]
        public string Puntos { get; set; }

        [JsonProperty(PropertyName = "logo")]
        public string Escudo { get; set; }
    }
}


