using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class WeatherInfo
    {
        public string Weather { get; set; }
        public double Temperature { get; set; }
        public double TemperatureMin { get; set; }
        public double TemperatureMax { get; set; }
    }
}