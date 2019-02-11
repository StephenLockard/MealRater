using MealRater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MealRater.WebMVC.Controllers
{
    [Authorize]
    public class MealVoteController : Controller
    {
        // GET: MealVote
        public ActionResult Index()
        {
            var model = new VoteListItem[0];
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        

    }
}