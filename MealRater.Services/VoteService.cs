using MealRater.Data;
using MealRater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealRater.Services
{
    public class VoteService
    {
        private readonly Guid _userId;

        public VoteService()
        {
        }

        public VoteService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateVote(VoteCreate model)
        {
            var vote =
                new MealVote()
                {
                    MealId = model.MealId,
                    MealScore = model.MealScore,
                    CreatedUtc = DateTimeOffset.Now,
                    ApplicationUserId = _userId,
                };

            using (var ctx = new ApplicationDbContext())
            {
                //var meal = ctx.Meals.SingleOrDefault(m => m.MealId == model.MealId);
                ctx.MealVotes.Add(vote);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<VoteListItem> GetVotes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var interrogation =
                    ctx
                        .MealVotes
                        .Select(
                        e =>
                            new VoteListItem
                            {
                                MealID = e.MealId,
                                MealName = e.Meal.MealName,
                                CreatedUtc = e.CreatedUtc,
                                MealScore = e.MealScore,
                                VoteID = e.VoteId
                            });
                return interrogation.ToArray();
            }
        }

        public VoteDetail GetVoteById(int voteId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .MealVotes
                        .Single(e => e.VoteId == voteId);
                return
                    new VoteDetail
                    {
                        VoteId = entity.VoteId,
                        MealId = entity.MealId,
                        MealName = entity.Meal.MealName,
                        MealDescription = entity.Meal.MealDescription,
                        MealScore = entity.MealScore,
                        CreatedUtc = entity.CreatedUtc

                    };
            }
        }

        public bool UpdateVote(VoteEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .MealVotes
                        .Single(e => e.VoteId == model.VoteId);

                entity.MealId = model.MealId;
                entity.MealScore = model.MealScore;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteNote(int voteId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .MealVotes
                        .Single(e => e.VoteId == voteId && e.ApplicationUserId == _userId);

                ctx.MealVotes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
