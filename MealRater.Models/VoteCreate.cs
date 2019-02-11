using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealRater.Models
{
    public class VoteCreate
    {   
        [Required]
        public int MealId { get; set; }

        [Required, Range(1, 10)]
        public int MealScore { get; set; }
       
    }
}
