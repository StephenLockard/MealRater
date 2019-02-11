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
        public MealListItem MealName { get; set; }
        

        //[Required]
        //[MinLength(2, ErrorMessage = "That name is too short!")]
        //public string MealName { get; set; }
        //[Required]
        //[MinLength(2, ErrorMessage = "That description is too short!")]
        //public string MealDescription { get; set; }

        //public override string ToString() => MealName + MealDescription;
    }
}
