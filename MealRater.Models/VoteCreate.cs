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
        
    }
}
