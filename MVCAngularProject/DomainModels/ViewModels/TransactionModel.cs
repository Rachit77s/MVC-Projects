﻿using DomainModels.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.ViewModels
{
    [NotMapped]
    public class TransactionModel : Transaction
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }

}