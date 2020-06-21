using DomainModels.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DomainModels.ViewModels
{
    [NotMapped]
    public class ProductViewModel : Product
    {
        //This file we will upload at the application level and not saving it in the DB
        public HttpPostedFileBase file { get; set; }
    }
}
