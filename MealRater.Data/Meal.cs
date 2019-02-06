using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealRater.Data
{
    public class Meal
    {
        [Key]
        public int MealId { get; set; }
        [Required]
        public string MealName { get; set; }
        [Required]
        public string Description { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }
    }
}