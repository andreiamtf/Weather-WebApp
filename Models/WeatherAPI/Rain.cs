using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWeatherAPI.Models.WeatherAPI
{
    public class Rain
    {
        public Rain() { rainvalue = 0.0; }
        public double rainvalue { get; set; }

        //public Dictionary<string, double> h { get; set; }
    }
}