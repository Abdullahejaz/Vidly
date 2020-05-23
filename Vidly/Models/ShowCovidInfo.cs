using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class ShowCovidInfo
    {
        public string Name { get; set; }
        public int ConfirmedCases { get; set; }
        public int Recovered { get; set; }
        public int Dead { get; set; }
        public int ActiveCases { get; set; }
    }
}