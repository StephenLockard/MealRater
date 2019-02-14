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
            bool isAdmin = false ;
            if (User.IsInRole("Admin"))
            {
                isAdmin = true;
            }
            
            var service = CreateVoteService();
            var model = service.GetVotes(isAdmin);
            return View(model);
        }

        public ActionResult Create()
        {
            var service = new MealService();
            ViewBag.MealId = new SelectList(service.GetMeals(), "MealID", "MealName");
            return View();
        }

        //Post
        [HttpPost, ValidateAntiForgeryToken]
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

        public ActionResult Details(int id)
        {
            var svc = CreateVoteService();
            var model = svc.GetVoteById(id);
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateMealService();
            var voteService = CreateVoteService();
            var detail = voteService.GetVoteById(id);
            ViewBag.MealID = new SelectList(service.GetMeals(), "MealID", "MealName");
            var model =
                new VoteEdit
                {
                    MealId = detail.MealId,
                    MealScore = detail.MealScore,
                    VoteId = detail.VoteId
                };
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var svc = CreateVoteService();
            var model = svc.GetVoteById(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateVoteService();

            service.DeleteVote(id);

            TempData["SaveResult"] = "Your note was deleted";

            return RedirectToAction("Index");
        }



        private MealService CreateMealService()
        {
            var service = new MealService();
            return service;
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(int id, VoteEdit model)
        {
            if (!ModelState.IsValid) return View(model);


            var voteService = CreateVoteService();
            var service = CreateMealService();
            ViewBag.MealID = new SelectList(service.GetMeals(), "MealID", "MealName");

            if (model.VoteId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }


            if (voteService.UpdateVote(model))
            {
                TempData["SaveResult"] = "Your vote was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your vote could not be updated.");
            return View(model);
        }


    }
}
