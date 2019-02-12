using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealRater.Data
{
    public class MealVote
    {
        [Key]
        public int VoteId { get; set; }

        [Required]
        public int MealId { get; set; }
        public virtual Meal Meal { get; set; }

        [Required]
        public Guid ApplicationUserId { get; set; }
        public virtual ApplicationUser Voter { get; set; }

        [Required, Range(1,10)]
        public int MealScore { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
