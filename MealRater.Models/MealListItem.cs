using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealRater.Models
{
    public class MealListItem
    {
        public int MealID { get; set; }
        public string MealName { get; set; }
        [Display(Name = "Created"), DisplayFormat(DataFormatString = "{0:d}")]
        public DateTimeOffset CreatedUtc { get; set; }
        public string MealDescription { get; set; }

        public override string ToString() => MealName;
    }
}
