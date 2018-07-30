using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class WeatherSqlDAL : IWeatherDAL
    {
        private string ConnectionString;
        public WeatherSqlDAL(string conString)
        {
            this.ConnectionString = conString;
        }


        /// <summary>
        /// Get all weather data for a given park in the next 5 days.
        /// </summary>
        /// <param name="parkCode">Code of the desired park.</param>
        /// <returns>5 Day forecast for the specified park.</returns>
        public List<WeatherResult> GetWeatherForPark(string parkCode)
        {
            var results = new List<WeatherResult>();
            string sql = "Select * From weather Where weather.parkCode = @pcode;";

            try
            {
                using (SqlConnection conn = new SqlConnection (ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@pcode", parkCode);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        results.Add(MapRowToWeatherResult(reader));
                    }
                }
            }
            catch (SqlException)
            {

                throw;
            }

            return results;
        }

        /// <summary>
        /// Maps database column values to a WeatherResult.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>New WeatherResult object.</returns>
        private WeatherResult MapRowToWeatherResult (SqlDataReader reader)
        {
            return new WeatherResult()
            {
                ParkCode=Convert.ToString(reader["parkCode"]),
                DayOfForecast = Convert.ToInt32(reader["fiveDayForecastValue"]),
                Low = Convert.ToInt32(reader["low"]),
                High = Convert.ToInt32(reader["high"]),
                Forecast = Convert.ToString(reader["forecast"])
            };
        }

    }
}
