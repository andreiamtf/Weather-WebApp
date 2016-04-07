using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWeatherAPI.Models.WeatherAPI
{
    public class List
    {

        public List() { rain = new Rain(); clouds = new Clouds(); wind = new Wind(); sys = new Sys2(); }

        public int dt { get; set; }
        public Main main { get; set; }
        public List<Weather> weather { get; set; }
        public Clouds clouds { get; set; }
        public Wind wind { get; set; }
        public Sys2 sys { get; set; }
        public string dt_txt { get; set; }
        public Rain rain { get; set; }
    }
}