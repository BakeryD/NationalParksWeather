using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public interface IWeatherDAL
    {
        List<WeatherResult> GetWeatherForPark(string parkCode);
    }
}