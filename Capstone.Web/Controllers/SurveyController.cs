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
        private ISurveyDAL dal;
        public SurveyController(ISurveyDAL dal)
        {
            this.dal = dal; 
        }

        public IList<string> parkCodes => dal.GetParkCodes();

       // public List<SelectListItem> ParkCodes => parkCodes.Select(code => new SelectListItem() { Text = code, Value = code });
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
            var ParkCodes = parkCodes.Select(code => new SelectListItem() { Text = code, Value = code });
           ParkCodes = ParkCodes.Append(new SelectListItem() { Text = "--Select A Park", Value = null,Selected=true,Disabled=true});
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
            else
            {
                var ParkCodes = parkCodes.Select(code => new SelectListItem() { Text = code, Value = code });
                ParkCodes.Append(new SelectListItem() { Text = "--Select A Park", Value = null , Selected=true, Disabled=true});
                ViewBag.ParkCodes = ParkCodes;
                return View(survey);
            }
        }
    }
}