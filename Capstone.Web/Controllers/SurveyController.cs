using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {

        /// <summary>
        /// Display all the previous survey results.
        /// </summary>
        /// <returns>The page with the results bound to it.</returns>
        public IActionResult Index()
        {
            return View();
        }
    }
}