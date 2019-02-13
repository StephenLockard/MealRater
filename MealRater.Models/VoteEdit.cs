using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealRater.Models
{
    public class VoteEdit
    {
        public int VoteId { get; set; }
        public int MealId { get; set; }
        public int MealName { get; set; }
        public int MealScore { get; set; }
    }
}
