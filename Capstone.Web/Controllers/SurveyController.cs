using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {
		private readonly SurveySqlDAL dal;
		public SurveyController()
		{
			this.dal = new SurveySqlDAL(@"Data Source =.\Sqlexpress; Initial Catalog = NPGeek; Integrated Security = True");
		}

        /// <summary>
        /// Display all the previous survey results.
        /// </summary>
        /// <returns>The page with the results bound to it.</returns>
        public IActionResult Index()
        {
            return View();
        }

		[HttpGet]
		public IActionResult New()
		{
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