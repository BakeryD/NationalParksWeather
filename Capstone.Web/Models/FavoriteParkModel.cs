using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class FavoriteParkModel
    {
        public string Name { get; set; }
        public string ParkCode { get; set; }
         public string Quote { get; set; }
         public string QuoteSource { get; set; }
        public int SurveyCount { get; set; }
        public string ImageName => ParkCode.ToLower() + ".jpg";
    }
}
