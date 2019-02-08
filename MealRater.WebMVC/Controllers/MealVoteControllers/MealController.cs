using MealRater.Models;
using MealRater.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MealRater.WebMVC.Controllers.MealVoteControllers
{
    [Authorize]
    public class MealController : Controller
    {
        // GET: MealVoteApp
        public ActionResult Index()
        {
            var service = CreateMealService();
            var model = service.GetMeals();
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
            if(!ModelState.IsValid) return View(model);

            var service = CreateMealService();

            if (service.CreateMeal(model))
            {
               TempData["SaveResult"] = "Your meal was created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Error when attempting to create meal.");
            return View(model);
        }

        private MealService CreateMealService()
        {
            var service = new MealService();
            return service;
        }

        public ActionResult Details(int id)
        {
            var svc = CreateMealService();
            var model = svc.GetMealById(id);

            return View(model);
        }

    }
}