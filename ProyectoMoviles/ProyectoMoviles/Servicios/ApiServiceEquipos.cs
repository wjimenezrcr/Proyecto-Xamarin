using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using ProyectoMoviles.Modelos;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ProyectoMoviles.Servicios
{
    public class ApiServiceEquipos
    {
        private const string WEB_SERVICE_URL = "https://apifootball.firebaseio.com/team.json";

        public async Task<Equipos[]> GetStringAsync()
        {
            // Dispose HttpClient
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(WEB_SERVICE_URL);

                // using System.Net.Http.Headers;
                // text/xml

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetStringAsync("");

                var data = JsonConvert.DeserializeObject<Equipos[]>(response);

                Debug.WriteLine(
                    data
                );

                return data;
            };
        }

        public async Task<Equipos[]> GetAsync()
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri(WEB_SERVICE_URL);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.GetAsync("");

            if (!response.IsSuccessStatusCode)
            {
                return new Equipos[0];
            }

            var content = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<Equipos[]>(content);

            Debug.WriteLine(
                data
            );

            return data;
        }
    }
}
