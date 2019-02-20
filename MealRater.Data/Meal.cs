using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealRater.Data
{
    public class Meal
    {
        [Key]
        [DisplayName("Menu #")]
        public int MealId { get; set; }
        [Required]
        [DisplayName("Menu Name")]
        public string MealName { get; set; }
        [Required]
        [DisplayName("Description")]
        public string MealDescription { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }
    }
}