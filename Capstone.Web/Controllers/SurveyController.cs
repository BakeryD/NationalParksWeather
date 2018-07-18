using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {
		private readonly SurveySqlDAL dal;
		public SurveyController()
		{
			this.dal = new SurveySqlDAL(@"Data Source =.\Sqlexpress; Initial Catalog = NPGeek; Integrated Security = True");
		}

        public IList<string> parkCodes => dal.GetParkCodes();

        public IEnumerable<SelectListItem> ParkCodes => parkCodes.Select(code => new SelectListItem() { Text = code, Value = code });

        /// <summary>
        /// Display all the previous survey results.
        /// </summary>
        /// <returns>The page with the results bound to it.</returns>
        public IActionResult Index()
        {
            var favoriteParks = dal.GetAllResults();

            return View(favoriteParks);
        }

		[HttpGet]
		public IActionResult New()
		{
            ViewBag.ParkCodes = ParkCodes;

			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult New(Survey survey)
		{
			if (ModelState.IsValid)
			{
				dal.SaveSurvey(survey);
				TempData["Show_Message"] = true;
				return RedirectToAction("Index");
			}
			return View(survey);
		}
    }
}