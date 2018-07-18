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

        public SurveySqlDAL (string constring)
        {
            this.ConnectionString = constring;
        }

        public IList<Survey> GetAllResults()
        {
            var results = new List<Survey>();
            string sql = "Select * From survey_result;";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    var cmd = new SqlCommand(sql, conn);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        results.Add(MapRowToSurvey(reader));
                    }
                }
            }
            catch (SqlException ex)
            {

                throw;
            }
            return results;
        }

        public Survey MapRowToSurvey(SqlDataReader reader)
        {
            return new Survey()
            {
                ID =Convert.ToInt32( reader["surveyId"]),
                ParkCode=Convert.ToString( reader["parkCode"]),
                State = Convert.ToString(reader["state"]),
                ActivityLevel= Convert.ToString(reader["activityLevel"]),
                Email= Convert.ToString(reader["emailAddress"])

               
            };
        }
    }
}
