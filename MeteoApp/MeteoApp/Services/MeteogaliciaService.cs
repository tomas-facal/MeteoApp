using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeteoApp.Dtos;
using System.Net.Http;
using System.Diagnostics;
using Newtonsoft.Json;

namespace MeteoApp.Services
{
    public class MeteogaliciaService
    {
        private readonly HttpClient _httpClient;
        private HttpClient client;
        // URL de la API de Meteogalicia
        private string METEOGALICIA_URL = "https://servizos.meteogalicia.gal/mgrss/predicion/jsonPredConcellos.action?idConc=";

        // Constructor sin parámetros
        public MeteogaliciaService()
        {
            // Crea una nueva instancia de HttpClient
            client = new HttpClient();
        }

        // Constructor con parámetros
        public MeteogaliciaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Método para obtener el pronóstico del tiempo para un municipio específico
        public async Task<PredTresDias> GetWeather(string municipioId)
        {
            // Crea una nueva instancia de PredDiaConcello y PredTresDias
            PredDiaConcello predConcello = new PredDiaConcello();
            PredTresDias predTresDias = new PredTresDias();

            // Establece la URL de la solicitud concatenando el ID del municipio
            string requestUrl = string.Concat(METEOGALICIA_URL, municipioId);

            // Realiza la solicitud GET y almacena la respuesta en una variable
            HttpResponseMessage response = await client.GetAsync(requestUrl);

            // Comprueba si la solicitud se ha realizado correctamente
            if (response.IsSuccessStatusCode)
            {
                // Si la solicitud se ha realizado correctamente, procesa la respuesta
                string responseContent = await response.Content.ReadAsStringAsync();

                predConcello = JsonConvert.DeserializeObject<Response>(responseContent).predConcello;
                if (predConcello != null)
                {
                    List<PredDia> listaPredDiaConcello = new List<PredDia>();
                    for (int i = 0; i < 3; i++)
                    {
                        PredDia predDia = new PredDia();
                        var dia = predConcello.ListaPredDiaConcello[i];
                        predDia.FechaPredicion = dia.DataPredicion.ToShortDateString();
                        predDia.TMax = dia.TMax;
                        predDia.TMin = dia.TMin;
                        predDia.Plluvia = dia.Pchoiva;
                        CEOResponse cielo = new CEOResponse();

                        cielo.Mañana = dia.CEO.DescripcionManha;
                        cielo.Tarde = dia.CEO.DescripcionTarde;
                        cielo.Noche = dia.CEO.DescripcionNoite;
                        predDia.Cielo = cielo;

                        listaPredDiaConcello.Add(predDia);
                    }
                    predTresDias.ListaPredDiaConcello = listaPredDiaConcello;
                }

            }
            else
            {
                throw new Exception("Error en la petición");
            }

            return predTresDias;
        }
    }
}
