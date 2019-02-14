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

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
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

        public ActionResult Edit(int id)
        {
            var service = CreateMealService();
            var detail = service.GetMealById(id);
            var model =
                new MealEdit
                {
                    MealId = detail.MealId,
                    MealName = detail.MealName,
                    MealDescription = detail.MealDescription
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MealEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.MealId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateMealService();

            if (service.UpdateMeal(model))
            {
                TempData["SaveResult"] = "Your meal was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your meal could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateMealService();
            var model = svc.GetMealById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteMeal(int id)
        {
            var service = CreateMealService();

            service.DeleteMeal(id);

            TempData["SaveResult"] = "Your meal was deleted";

            return RedirectToAction("Index");
        }


    }
}