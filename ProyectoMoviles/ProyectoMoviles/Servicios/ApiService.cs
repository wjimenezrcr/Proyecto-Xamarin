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
    class ApiService
    {
        private const string WEB_SERVICE_URL = "http://cloud-services.azurewebsites.net/api/products";

        public async Task<Ciudades[]> GetStringAsync()
        {
            // Dispose HttpClient
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(WEB_SERVICE_URL);

                // using System.Net.Http.Headers;
                // text/xml

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetStringAsync("");

                var data = JsonConvert.DeserializeObject<Ciudades[]>(response);

                Debug.WriteLine(
                    data
                );

                return data;
            };
        }

        public async Task<Ciudades[]> GetAsync()
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri(WEB_SERVICE_URL);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.GetAsync("");

            if (!response.IsSuccessStatusCode)
            {
                return new Ciudades[0];
            }

            var content = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<Ciudades[]>(content);

            Debug.WriteLine(
                data
            );

            return data;
        }
    }
}
