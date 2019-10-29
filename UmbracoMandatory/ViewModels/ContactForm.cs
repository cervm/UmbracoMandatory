using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UmbracoMandatory.ViewModels
{
    public class ContactForm
    {
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter your email address")]
        [Display(Name = "Email")]
        [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$",
            ErrorMessage = "Please enter correct email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter a subject")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Please enter a message")]
        public string Message { get; set; }
    }
}