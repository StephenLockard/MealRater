using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealRater.Models
{
    public class VoteDetail
    {
        public int VoteId { get; set; }
        public int MealId { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public int MealScore { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
        public override string ToString() => $"[{MealId}] {MealName}";
    }
}
