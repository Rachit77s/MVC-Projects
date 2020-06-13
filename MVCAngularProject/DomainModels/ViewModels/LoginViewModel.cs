using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.ViewModels
{
   public class LoginViewModel
    {
        [Required(ErrorMessage ="Please Enter Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }
    }
}
