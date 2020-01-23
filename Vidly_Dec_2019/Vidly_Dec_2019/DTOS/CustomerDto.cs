using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly_Dec_2019.Models;

namespace Vidly_Dec_2019.DTOS
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
            
        [Min18YearsIfAMember]
        public Nullable<System.DateTime> BirthDate { get; set; }


        public int MembershipTypeId { get; set; }
       // public virtual MembershipType MembershipType { get; set; }
    }
}