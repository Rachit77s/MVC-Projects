using FiltersExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FiltersExample.DataAccess.Managers
{
    public class UserManager
    {
        public static List<User> GetAll()
        {
            using (TestEntities context = new TestEntities())
            {
                return context.Users.OrderBy(x => x.Name).ToList();
            }
        }

        public static User GetByID(int id)
        {
            using (TestEntities context = new TestEntities())
            {
                return context.Users.Find(id);
            }
        }
    }
}