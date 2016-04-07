using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using MyWeatherAPI.Models;
using System.IO;
using System.Text.RegularExpressions;
using DotNet.Highcharts;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using MyWeatherAPI.ViewModel;
using MyWeatherAPI.Models.WeatherAPI;
using System.Drawing;
using DotNet.Highcharts.Enums;


namespace MyWeatherAPI.Controllers
{

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("_GetCity");
        }


        [HttpPost]
        public ActionResult GetReportValues(string cityName)
        {
            wholeWeather viewModel = new wholeWeather();
            string newPlace = cityName;

            //To get the temperature Values
            Object[] chartTempValues = new Object[8];
            //To get the precipitation Values
            Object[] chartRainValues = new Object[8];
            //To get the X values
            String[] chartXValues = new String[8];

            MyWeather weather = new MyWeather();
            var result = weather.getWeather(newPlace);

            for (int i = 0; i < 8; i++)
            {

                chartTempValues[i] = (result.list[i].main.temp);
                chartXValues[i] = (result.list[i].dt_txt);
                chartRainValues[i] = (result.list[i].rain.rainvalue);
            }

          // DotNet.Highcharts.Highcharts chart = new DotNet.Highcharts.Highcharts("chart") 
            var chart = new Highcharts("chart")

             .InitChart(new DotNet.Highcharts.Options.Chart { })
             .SetPane(new Pane
             {
                 Size = new PercentageOrPixel(50, true)
             })

            //Define the type of the chart
            .SetTitle(new Title { Text = "Next 8 hours: Temperature and Precipitation " })
                // Load the x values
                .SetXAxis(new XAxis
                {
                    Categories = new[] { chartXValues[0], chartXValues[1], chartXValues[2], chartXValues[3], chartXValues[4], chartXValues[5], chartXValues[6], chartXValues[7] }
                })
                
                //Load the y values
                .SetSeries(new[]{new Series { Name = "Temperature", Data = new Data(chartTempValues)},
                new Series { Name = "Precipitation", Data = new Data(chartRainValues) }
        
                })

             //Set the Y Title
             .SetYAxis(new[] {new YAxis { 
                 
               Id = "1",
               Title = new YAxisTitle { Text = "Temperature (°C) / Precipitation (mm)", Style = "color:'#468847'" },
               Min=-5,
               Labels = new YAxisLabels { Formatter = "function() { return this.value}" },

             }
                         
             })
             .SetTooltip(new Tooltip
             {
                 Enabled = true,
                 Formatter = @"function() {return '<b>'+ this.series.name + '</b><br/>'+ this.y +': '+ this.x;}"
             })

             .SetPlotOptions(new PlotOptions
             {
                 Line = new PlotOptionsLine
                 {
                     DataLabels = new PlotOptionsLineDataLabels { Enabled = true },
                     EnableMouseTracking = true
                 }
             })

             ;


            // To get the temperature values/data

            Dictionary<string, List<List>> dict = new Dictionary<string, List<List>>();
            DateTime MyDateTime = new DateTime();
            List<string> MyWeatherValues = new List<string>();
            
            int j = 0;
            while (j < result.list.Count)
            {

                //Convert to a (string)short data
                MyDateTime = DateTime.ParseExact(result.list[j].dt_txt, "yyyy-MM-dd HH:mm:ss", null);
                string MyNewDateTime = MyDateTime.ToString("d");

                if (dict.ContainsKey(MyNewDateTime))
                {

                    dict[MyNewDateTime].Add(result.list[j]);
                }
                else
                {   
                    //Initialize the dictionary
                    List<List> tempListObjects = new List<List>();
                    tempListObjects.Add(result.list[j]);
                    dict.Add(MyNewDateTime, tempListObjects);
                }

                j++;
            }

            viewModel.charts = chart;
            viewModel.rootWeatherAPI = result;
            viewModel.WeatherByDays = dict;

            return View("Index", viewModel);

        }

    }
}