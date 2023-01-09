using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net;
using MeteoApp.Services;
using MeteoApp.Dtos;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MeteoApp.Controllers
{
    [Route("api/observadores")]
    [ApiController]
    public class MeteogaliciaController : Controller
    {
        private MeteogaliciaService service;

        public MeteogaliciaController()
        {
            // Instanciamos la clase MeteogaliciaService
            service = new MeteogaliciaService();
        }
        // Método que manejará la solicitud GET a la API
        [HttpGet("{municipioId}")]
        public async Task<PredTresDias> GetWeather(string municipioId)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            PredTresDias meteoResponse = service.GetWeather(municipioId).Result;
            response.Content = new StringContent(meteoResponse.ToString()); // weatherInfo es la información obtenida de la API
            response.StatusCode = HttpStatusCode.OK;
            return meteoResponse;
        }
    }
}
