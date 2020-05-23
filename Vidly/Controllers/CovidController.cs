using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CovidController : Controller
    {
        // GET: Covid
        public async Task<ActionResult> Index()
        {

            var token = "7efcfd2232msh2d997e88b427037p193f9ejsn7d1c850e4160";
            var baseUrl = $"https://covid-19-data.p.rapidapi.com/report/country/name?date-format=YYYY-MM-DD&format=json&date=2020-04-01&name=Italy";
            var tokenType = "x-rapidapi-key"; //Other APIs use Bearer or other auth types.
            


            HttpClient httpClient = new HttpClient();

            HttpRequestMessage request = new HttpRequestMessage();
            request.RequestUri = new Uri(baseUrl);
            
            
            request.Headers.Add(tokenType, token);
            HttpResponseMessage response = await httpClient.SendAsync(request);
            var responseString = await response.Content.ReadAsStringAsync();
            var statusCode = response.StatusCode;

            var deserealize = JsonConvert.DeserializeObject<Application>(responseString);

            /*string data = await httpClient.GetStringAsync(baseUrl);
           */
            ShowCovidInfo showCovidInfo = new ShowCovidInfo
            {
                Name = deserealize.provinces[0].province,
                ConfirmedCases = deserealize.provinces[0].confirmed,
                Recovered = deserealize.provinces[0].recovered,
                Dead = deserealize.provinces[0].deaths,
                ActiveCases = deserealize.provinces[0].active

            };

            return View(showCovidInfo);
        }
    }
}