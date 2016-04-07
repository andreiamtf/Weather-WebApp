using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNet.Highcharts;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using MyWeatherAPI.Models.WeatherAPI;

  

namespace MyWeatherAPI.ViewModel
{
    public class wholeWeather
    {
        public Highcharts charts { get; set; }

        public RootObject rootWeatherAPI {get; set;}

        public Dictionary<string, List<List>> WeatherByDays { get; set;}
    }
}