using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class ParkSqlDAL
    {
        private string ConnectionString;

        public ParkSqlDAL(string connstring)
        {
            this.ConnectionString = connstring;
        }

        public IList<Park> GetAllParks()
        {
            var parks = new List<Park>();
            string sql = "Select * From park;";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    var cmd = new SqlCommand(sql, conn);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        parks.Add(MapRowToPark(reader));
                    }
                }
            }
            catch (SqlException ex)
            {

                throw;
            }
            return parks;
        }

        public Park GetPark(string code)
        {
            var park = new Park();
            string sql = "Select * From park Where park.parkCode= @code;";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@code", code);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        park= MapRowToPark(reader);
                    }
                }
            }
            catch (SqlException ex)
            {

                throw;
            }
            return park;
        }

        private Park MapRowToPark(SqlDataReader reader)
        {
            return new Park()
            {
                ParkCode=Convert.ToString(reader["parkCode"]),
                Name = Convert.ToString(reader["parkName"]),
                State= Convert.ToString(reader["state"]),
                Acreage= Convert.ToInt32(reader["acreage"]),
                ElevationInFt=Convert.ToInt32(reader["elevationInFeet"]),
                MilesOfTrail= Convert.ToInt32(reader["milesOfTrail"]),
                NumberOfCampsites= Convert.ToInt32(reader["numberOfCampsites"]),
                Climate= Convert.ToString(reader["climate"]),
                YearFounded= Convert.ToInt32(reader["yearFounded"]),
                AnnualVisitorCount= Convert.ToInt32(reader["annualVisitorCount"]),
                InspirationalQuote= Convert.ToString(reader["inspirationalQuote"]),
                QuoteSource= Convert.ToString(reader["inspirationalQuoteSource"]),
               Description = Convert.ToString(reader["parkDescription"]),
                EntryFee= Convert.ToInt32(reader["entryFee"]),
                NumberOfAnimalSpecies= Convert.ToInt32(reader["numberOfAnimalSpecies"])
            };
        }

        public IList<string> GetParkCodes()
        {
            var codes = new List<string>();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    var cmd = new SqlCommand("Select parkCode From park;", conn);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        codes.Add(Convert.ToString(reader["parkCode"]));
                    }
                }
            }
            catch (SqlException x)
            {

                throw;
            }
            return codes;
        }

		
    }
}
