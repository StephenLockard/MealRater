using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealRater.Models
{
    public class VoteListItem
    {
        public int VoteID { get; set; }
        public int MealID { get; set; }
        public string MealName { get; set; }
        [Display(Name = "Vote Date"), DisplayFormat(DataFormatString = "{0:d}")]
        public DateTimeOffset CreatedUtc { get; set; }
        public string UserName { get; set; }
        public int MealScore { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
