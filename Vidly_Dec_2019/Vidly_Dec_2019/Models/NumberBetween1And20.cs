using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly_Dec_2019.Models
{
    public class NumberBetween1And20 : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movy)validationContext.ObjectInstance;

            //Pay as you go ID it will work assume bday is valid whatever it may be
            //if (customer.MembershipTypeId == 0 || customer.MembershipTypeId == 1)
            //    return ValidationResult.Success;

            if (movie.NumberInStock == null)
                return new ValidationResult("Number In Stock is required");

            var age = DateTime.Today.Year - movie.NumberInStock.Value;


            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("The field Number In Stock must be between 1 and 20");
        }
    }
}