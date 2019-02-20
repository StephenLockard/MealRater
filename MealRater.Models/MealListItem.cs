using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealRater.Models
{
    public class MealListItem
    {
        [DisplayName("Menu #")]
        public int MealID { get; set; }
        [DisplayName("Menu Name")]
        public string MealName { get; set; }
        [Display(Name = "Created"), DisplayFormat(DataFormatString = "{0:d}")]
        public DateTimeOffset CreatedUtc { get; set; }
        [DisplayName("Description")]
        public string MealDescription { get; set; }

        public override string ToString() => MealName;
    }
}
