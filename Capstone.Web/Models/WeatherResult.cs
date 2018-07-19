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
        public string Advisory
        {
            get {

                string adv = "";
                if (Forecast=="snow")
                {
                    adv += "WARNING: Snow expected, pack snowshoes! \n";
                }
                if (Forecast=="sunny")
                {
                    adv += "WARNING: Sunscreen advised. \n";
                }
                if (Forecast== "thunderstorms")
                {
                    adv += "WARNING: Stormy conditions expected. Avoid hiking and seek shelter! \n";
                }
                if (High>75 || Low>75)
                {
                    adv += "WARNING: High temperatures expected, bring 1 gal. water extra/person. \n";
                }
                if (Low<20 || High<20)
                {
                    adv += "WARNING: Temperatures below freezing expected. \n";
                }
                if ((High-Low) > 20)
                {
                    adv += "WARNING: Wear breatheable layers, fluctuations expected. \n";
                }
                return adv;
            }
        }



    }
}