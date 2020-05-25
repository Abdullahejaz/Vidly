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


            var baseUrl = $"https://api.covid19api.com/summary";



            HttpClient httpClient = new HttpClient();

            /* HttpRequestMessage request = new HttpRequestMessage();
             request.RequestUri = new Uri(baseUrl);*/

            /* 
             request.Headers.Add(tokenType, token);
             HttpResponseMessage response = await httpClient.SendAsync(request);
             var responseString = await response.Content.ReadAsStringAsync();
             var statusCode = response.StatusCode;*/


            string data = await httpClient.GetStringAsync(baseUrl);

            var deserialize = JsonConvert.DeserializeObject<CovidRoot>(data);


            List<ShowCovidInfo> showCovidInfo = new List<ShowCovidInfo>();

            foreach (var i in deserialize.Countries)
            {
                
                {

                    showCovidInfo.Add(
                        new ShowCovidInfo
                        {
                            Name = i.Country,
                            ConfirmedCases = i.TotalConfirmed,
                            Recovered = i.TotalRecovered,
                            Dead = i.TotalDeaths
                        }
                    );

                };

               
            }

            return View(showCovidInfo.ToList());


        }
    }
}