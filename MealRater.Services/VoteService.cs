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

        public IEnumerable<VoteListItem> GetVotes(bool isAdmin)
        {
            using (var ctx = new ApplicationDbContext())
            {
                //var adminRoleId = ctx.Roles.FirstOrDefault(u => u.Name.Equals("Admin")).Id;
                //var list = ctx.Users.Where(u => u.Roles.Any(r => r.RoleId == adminRoleId)).ToList();

                //var admins = ctx.Roles.FirstOrDefault(u => u.Name.Equals("Admin")).Users;
                //bool isAdmin = admins.Where(a => a.UserId == _userId.ToString()).Count() != 0;
                var interrogation =
                    ctx
                        .MealVotes
                        .Where(vote => vote.ApplicationUserId == _userId || isAdmin)
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

        public bool DeleteVote(int voteId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .MealVotes
                        .Single(e => e.VoteId == voteId);

                ctx.MealVotes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
