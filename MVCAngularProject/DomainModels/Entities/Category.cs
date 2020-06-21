using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Entities
{
    public class Category
    {
        public Category()
        {
            CreatedDate = DateTime.Now;
            Products = new HashSet<Product>();
        }
        //[Key]
        public int CategoryId { get; set; }

        //[Column(TypeName = "varchar")]
        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
