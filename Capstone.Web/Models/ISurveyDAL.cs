using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public interface ISurveyDAL
    {
        IList<FavoriteParkModel> GetAllResults();
        void SaveSurvey(Survey newSurvey);
        IList<string> GetParkCodes();
    }
}