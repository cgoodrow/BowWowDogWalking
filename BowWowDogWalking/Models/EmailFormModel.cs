using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BowWowDogWalking.Models
{
    public class EmailFormModel
    {
        [Required, Display(Name = "Name")]
        public string Name { get; set; }
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Invalid email format."), Required]
        public string Email { get; set; }       
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number"), Required]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
        [Required, Display(Name="Schedule Date"), DataType(DataType.Date)]
        public DateTime ScheduleDate { get; set; }
        [Display(Name = "Hour")]
        public bool SixtyMin { get; set; }
        [Display(Name = "Half Hour")]
        public bool ThirtyMin { get; set; }
    }
}