using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWeatherAPI.Models.WeatherAPI
{
    public class Weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }
}