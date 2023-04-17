using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CallBackForm.Shared
{
    public class UserDetails
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required, EmailAddress]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Required]
        [Display(Name = "Contact Number")]
        [StringLength(11)]
        [RegularExpression("^[0-9]*$")]
        public string ContactNumber { get; set; }

        [Required]
        [Display(Name = "Best Day To Contact")]
        public DateTime BestTimeToContact { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "Please select a school")]
        public string SelectedSchoolName { get; set; }
    }

}
