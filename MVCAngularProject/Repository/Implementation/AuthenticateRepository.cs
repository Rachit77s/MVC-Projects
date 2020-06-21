using ApplicationCore;
using DomainModels.Entities;
using DomainModels.ViewModels;
using Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class AuthenticateRepository : Repository<User>, IAuthenticateRepository
    {
        //Using Application.Core class
        private DatabaseContext context
        {
            get
            {
                return db as DatabaseContext;
            }
        }
        public AuthenticateRepository(DbContext _db)//: base(_db)
        {
            this.db = _db;
        }
        public UserViewModel ValidateUser(LoginViewModel model)
        {
            //Included Eager Loading
            User data = context.Users.Include("Roles").Where(u => u.Username == model.Username && u.Password == model.Password).FirstOrDefault();

            if (data != null)
            {
                UserViewModel obj = new UserViewModel
                {
                    UserId = data.UserId,
                    Name = data.Name,
                    Username = data.Username,
                    Address = data.Address,
                    ContactNo = data.ContactNo,
                    Roles = data.Roles.Select(r => r.Name).ToArray()
                };

                //Rachit: Because role is not populating hence did this fix.
                if (obj.Name.Contains("Admin"))
                {
                    var adminRole = new[] { "Admin" };
                    obj.Roles = adminRole;
                }
                else
                {
                    var userRole = new[] { "User" };
                    obj.Roles = userRole;
                }
                return obj;
            }
            else
            {
                return null;
            }
        }
    }
}
