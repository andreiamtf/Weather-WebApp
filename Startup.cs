﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyWeatherAPI.Startup))]
namespace MyWeatherAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
