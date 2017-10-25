using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EAPPracClient.Models
{
    public class Student
    {
        [Display(Name ="Student ID")]
        [Required(ErrorMessage ="Don't empty!")]
        public string StudentID { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Don't empty!")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Don't empty!")]
        public string LastName { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Don't empty!")]
        public int Phone { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Don't empty!")]
        public string Email { get; set; }
    }
}