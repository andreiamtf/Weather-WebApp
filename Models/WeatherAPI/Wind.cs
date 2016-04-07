using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWeatherAPI.Models.WeatherAPI
{
    public class Wind
    {
        public Wind() { speed = 0.0; deg = 0.0; }

        public double speed { get; set; }
        public double deg { get; set; }
    }
}