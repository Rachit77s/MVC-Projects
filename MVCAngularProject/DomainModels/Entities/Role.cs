using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Entities
{
    public class Role
    {
        //Date should be added automatically
        public Role()
        {
            CreatedDate = DateTime.Now;
            //HashSet will not accept duplicate values so when we are performing DB operations then there should be unique record.
            Users = new HashSet<User>();
        }
        public int RoleId { get; set; }

        //[Column(TypeName = "varchar")]
        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        //[Column(TypeName = "varchar")]
        [StringLength(250)]
        [Required]
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        //Rachit
        //As User and Roles have many to many properties so below property is used for Navigation purpose
        //For defining mapping we need to define the navigation property on both the classes
        //Virtual keyword is used for Lazy Loading Concept
        public virtual ICollection<User> Users { get; set; }
    }
}
