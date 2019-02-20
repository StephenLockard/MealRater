using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealRater.Models
{
    public class MealCreate
    {
        [Required]
        [DisplayName("Menu Name")]
        [MinLength(2, ErrorMessage = "That name is too short!")]
        public string MealName { get; set; }
        [Required]
        [DisplayName("Description")]
        [MinLength(2, ErrorMessage = "That description is too short!")]
        public string MealDescription { get; set; }

        public override string ToString() => MealName + MealDescription;
    }
}
