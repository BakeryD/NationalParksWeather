using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone.Web.Models;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
        private ParkSqlDAL pdal;

        public HomeController()
        {
            this.pdal = new ParkSqlDAL(@"Data Source=.\sqlexpress;Initial Catalog=NPGeek;Integrated Security=True");
        }

        public IActionResult Index()
        {
            var parks = pdal.GetAllParks();

            return View(parks);
        }

        public IActionResult Detail (string id)
        {
            var park = pdal.GetPark(id);

            return View(park);
        }
      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
