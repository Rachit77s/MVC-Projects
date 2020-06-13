﻿using DomainModels.Entities;
using DomainModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Abstraction
{
    public interface IAuthenticateRepository : IRepository<User>
    {
        //User ValidateUser(string userName, string password);
        UserViewModel ValidateUser(LoginViewModel model);
    }
}
