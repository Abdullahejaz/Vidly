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
        
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(CityWeather cityWeather)
        {
            
            var appid = "d71a2d1f949793c83d9b8a3697d9d025";

            var baseUrl = $"http://api.openweathermap.org/data/2.5/weather?q={cityWeather.CityName},{cityWeather.CountryAbbreviation}&APPID={appid}";

                HttpClient httpClient = new HttpClient();
            /* HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(baseUrl);
             httpResponseMessage.EnsureSuccessStatusCode();
             var data = await httpResponseMessage.Content.ReadAsStringAsync();*/

            string data = await httpClient.GetStringAsync(baseUrl);
           

            var deserialize = JsonConvert.DeserializeObject<Example>(data);

            WeatherInfo weatherInfo = new WeatherInfo
            {
                CityName = deserialize.name,
                Weather = deserialize.weather[0].description,
                Temperature = deserialize.main.temp,
                TemperatureMin = deserialize.main.temp_min,
                TemperatureMax = deserialize.main.temp_max
            };


            return View("ShowWeatherDetail", weatherInfo);
        }
    }
}