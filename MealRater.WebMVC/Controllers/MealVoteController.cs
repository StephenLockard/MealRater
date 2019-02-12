using MealRater.Models;
using MealRater.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MealRater.Data;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace MealRater.WebMVC.Controllers
{
    [Authorize]
    public class MealVoteController : Controller
    {
        //Get
        public ActionResult Index()
        {
            var service = CreateVoteService();
            var model = service.GetVotes();
            return View(model);
        }

        public ActionResult Create()
        {
            var service = new MealService();
            ViewBag.MealId = new SelectList(service.GetMeals(), "MealID", "MealName");
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VoteCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateVoteService();
            if (service.CreateVote(model))
            {
                TempData["SaveResult"] = "Your vote was cast.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Something went wrong and your vote was not cast!");
            return View(model);
        }

        private VoteService CreateVoteService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new VoteService(userId);
            return service;
        }

        /*
        private MealService CreateMealService()
        {
            var service = new MealService();
            return service;
        }
        */

        /*
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
        */



    }
}
 