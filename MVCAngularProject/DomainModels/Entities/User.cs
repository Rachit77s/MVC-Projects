using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DomainModels.Entities
{
    //[Table("Users")]
    public class User
    {
        //Date should be added automatically
        public User()
        {
            CreatedDate = DateTime.Now;
            //HashSet will not accept duplicate values so when we are performing DB operations then there should be unique record.
            Roles = new HashSet<Role>();
            Orders = new HashSet<Order>();
        }
        //[Key]
        public int UserId { get; set; }

        //[Column(TypeName ="varchar")]
        [StringLength(50)]
        [Required]
        public string Username { get; set; }

        //[Column(TypeName = "varchar")]
        [StringLength(50)]
        [Required]
        public string Password { get; set; }

        //[Column(TypeName = "varchar")]
        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        //[Column(TypeName = "varchar")]
        [StringLength(250)]
        public string Address { get; set; }

        //[Column(TypeName = "varchar")]
        [StringLength(20)]
        [Required]
        public string ContactNo { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        //Rachit
        //As User and Roles have many to many properties so below property is used for Navigation purpose
        //For defining mapping we need to define the navigation property on both the classes
        //Virtual keyword is used for Lazy Loading Concept
        public virtual ICollection<Role> Roles { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
