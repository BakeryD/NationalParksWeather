using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public interface IParkDAL
    {
        IList<Park> GetAllParks();
        Park GetPark(string code);
        IList<string> GetParkCodes();
    }
}