using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace Vidly.Models
{
    public class CityWeather 
    { 
    
        [Required]
        public string CityName { get; set; }
        [Required]
        public string CountryAbbreviation { get; set; }
    }
}