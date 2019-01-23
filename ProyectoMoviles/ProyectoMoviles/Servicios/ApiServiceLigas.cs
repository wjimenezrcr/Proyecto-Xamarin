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
    public class ApiServiceLigas
    {
        private const string WEB_SERVICE_URL = "https://apifootball.firebaseio.com/leagues.json";

        public async Task<Ligas[]> GetStringAsync()
        {
            // Dispose HttpClient
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(WEB_SERVICE_URL);

                // using System.Net.Http.Headers;
                // text/xml

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetStringAsync("");

                var data = JsonConvert.DeserializeObject<Ligas[]>(response);

                Debug.WriteLine(
                    data
                );

                return data;
            };
        }

        public async Task<Ligas[]> GetAsync()
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri(WEB_SERVICE_URL);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.GetAsync("");

            if (!response.IsSuccessStatusCode)
            {
                return new Ligas[0];
            }

            var content = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<Ligas[]>(content);

            Debug.WriteLine(
                data
            );

            return data;
        }
    }
}
