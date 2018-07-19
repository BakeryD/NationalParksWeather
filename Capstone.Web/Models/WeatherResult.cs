using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class WeatherResult
    {
        public string ParkCode { get; set; }
        public int DayOfForecast { get; set; } //fiveDayForecastValue
        public int Low { get; set; }
        public int High { get; set; }
        public string Forecast { get; set; }
    }
}