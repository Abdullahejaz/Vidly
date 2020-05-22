using Microsoft.Ajax.Utilities;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using Newtonsoft.Json.Linq;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class WeatherController : Controller
    {
        
        // GET: Weather
        public async Task<ActionResult> Index()
        {
            var appid = "d71a2d1f949793c83d9b8a3697d9d025";

            var baseUrl = $"http://api.openweathermap.org/data/2.5/weather?q=London,uk&APPID={appid}";

          
                HttpClient httpClient = new HttpClient();
            /* HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(baseUrl);
             httpResponseMessage.EnsureSuccessStatusCode();
             var data = await httpResponseMessage.Content.ReadAsStringAsync();*/

            string data = await httpClient.GetStringAsync(baseUrl);

            var deserialize = JsonConvert.DeserializeObject<Example>(data);

            WeatherInfo weatherInfo = new WeatherInfo
            {
                Weather = deserialize.weather[0].description,
                Temperature = deserialize.main.temp,
                TemperatureMin = deserialize.main.temp_min,
                TemperatureMax = deserialize.main.temp_max
            };


            return View(weatherInfo);
        }
    }
}