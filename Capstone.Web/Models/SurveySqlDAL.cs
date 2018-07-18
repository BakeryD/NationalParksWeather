using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class SurveySqlDAL
    {
        private string ConnectionString;

        public SurveySqlDAL(string constring)
        {
            this.ConnectionString = constring;
        }

        public IList<FavoriteParkModel> GetAllResults()
        {
            var results = new List<FavoriteParkModel>();
            string sql = $"select park.parkName,park.parkCode, Count(survey_result.state) as surveyCount " +
                         $"from park " +
                         $"Inner Join survey_result on survey_result.parkCode = park.parkCode " +
                         $"group by park.parkName,park.parkCode " +
                         $"Order by Count(survey_result.state) DESC";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    var cmd = new SqlCommand(sql, conn);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        results.Add(MapRowToFavoriteParkModel(reader));
                    }
                }
            }
            catch (SqlException ex)
            {

                throw;
            }
            return results;
        }


        private FavoriteParkModel MapRowToFavoriteParkModel(SqlDataReader reader)
        {
            return new FavoriteParkModel()
            {
                ParkCode = Convert.ToString(reader["parkCode"]),
                Name = Convert.ToString(reader["parkName"]),
                SurveyCount = Convert.ToInt32(reader["surveyCount"])
            };
        }

        /// <summary>
        /// Saves a new survey to the system.
        /// </summary>
        public void SaveSurvey(Survey newSurvey)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    string sql = $"INSERT INTO survey_result VALUES(@parkCode, @emailAddress, @state, @activityLevel)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@parkCode", newSurvey.ParkCode);
                    cmd.Parameters.AddWithValue("@emailAddress", newSurvey.Email);
                    cmd.Parameters.AddWithValue("@state", newSurvey.State);
                    cmd.Parameters.AddWithValue("@activityLevel", newSurvey.ActivityLevel);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public Survey MapRowToSurvey(SqlDataReader reader)
        {
            return new Survey()
            {
                //ID =Convert.ToInt32( reader["surveyId"]),
                ParkCode = Convert.ToString(reader["parkCode"]),
                State = Convert.ToString(reader["state"]),
                ActivityLevel = Convert.ToString(reader["activityLevel"]),
                Email = Convert.ToString(reader["emailAddress"])


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
