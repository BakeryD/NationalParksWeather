using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class ParkDetailModel
    {
        public Park Park { get; set; }
        public IList <WeatherResult> ParkWeather { get; set; }
    }
}
