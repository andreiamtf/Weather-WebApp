using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using MyWeatherAPI.Models.WeatherAPI;
using System.Collections;
using System.Collections.Generic;

namespace MyWeatherAPI.Models
{
    public class MyWeather
    {

        public RootObject getWeather(string newPlace)
        {


            string appid = "xx";
            string cityName = newPlace;

            string url = "http://api.openweathermap.org/data/2.5/forecast?q=" + cityName + ",us&mode=json&appid=" + appid + "&units=metric";


            //synchronous client.
            var client = new WebClient();
            var content = client.DownloadString(url);

            // To serializer correctly
            content = content.Replace("\"rain\":{\"3h", "\"rain\":{\"rainvalue");
            content = content.Replace("\"snow\":{\"3h", "\"snow\":{\"snowvalue");

            var serializer = new JavaScriptSerializer();
            var jsonContent = serializer.Deserialize<RootObject>(content);

            return jsonContent;

        }



    }



}