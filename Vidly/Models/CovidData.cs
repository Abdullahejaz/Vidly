using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Provinces
    {
        public string province { get; set; }
        public int confirmed { get; set; }
        public int recovered { get; set; }
        public int deaths { get; set; }
        public int active { get; set; }

    }
    public class Application
    {
        public string country { get; set; }
        public IList<Provinces> provinces { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string date { get; set; }

    }
}