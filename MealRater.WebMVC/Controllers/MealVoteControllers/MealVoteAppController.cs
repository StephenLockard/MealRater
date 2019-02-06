using MealRater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MealRater.WebMVC.Controllers.MealVoteControllers
{
    [Authorize]
    public class MealVoteAppController : Controller
    {
        // GET: MealVoteApp
        public ActionResult Index()
        {
            var model = new MealListItem[0];
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MealCreate model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}