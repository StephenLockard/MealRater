using MealRater.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MealraterWebAPI.Controllers
{
    [Authorize]
    public class MealController : ApiController
    {
        public IHttpActionResult Get()
        {
            MealService mealService = CreateMealService();
            var meals = mealService.GetMeals();
            return Ok(meals);
        }

        private MealService CreateMealService()
        {
            var service = new MealService();
            return service;
        }
    }
}
