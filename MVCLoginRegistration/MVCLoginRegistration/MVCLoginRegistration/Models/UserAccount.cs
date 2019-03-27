using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCLoginRegistration.Models
{
    public class UserAccount
    {
        // How to create Custom Login Registration in Asp.Net MVC 5 (Code First) - YOUTUBE
        [Key]
        public int UserID { get; set; }
        [Required(ErrorMessage = "FirstName is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required.")]
        public string LastName  { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        public string Username  { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Please confirm your Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

    }
}