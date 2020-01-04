using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly_Dec_2019.Models
{
    [MetadataType(typeof(CustomerMetadata))]
    public partial class Customer
    {
    }


    public class CustomerMetadata
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter the name")]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        public Nullable<System.DateTime> BirthDate { get; set; }
        public int MembershipTypeId { get; set; }
        public virtual MembershipType MembershipType { get; set; }
    }

}