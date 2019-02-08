using MealRater.Data;
using MealRater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealRater.Services
{
    public class MealService
    {

        public bool CreateMeal(MealCreate model)
        {
            var entity =
                new Meal()
                {
                    MealName = model.MealName,
                    MealDescription = model.MealDescription,
                    CreatedUtc = DateTimeOffset.Now,

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Meals.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<MealListItem> GetMeals()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                   ctx
                     .Meals
                     .Select(
                         e =>
                             new MealListItem
                             {
                                 MealID = e.MealId,
                                 MealName = e.MealName,
                                 MealDescription = e.MealDescription,
                                 CreatedUtc = e.CreatedUtc
                             }
                     );
                return query.ToArray();
            }
        }

        public MealDetail GetMealById(int mealId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Meals
                        .Single(e => e.MealId == mealId);
                return
                    new MealDetail
                    {
                        MealId = entity.MealId,
                        MealName = entity.MealName,
                        MealDescription = entity.MealDescription,
                        CreatedUtc = entity.CreatedUtc
                    };
            }

        }
    }
}