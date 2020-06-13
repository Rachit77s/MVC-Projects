//namespace ApplicationCore.Migrations
//{
//    using DomainModels.Entities;
//    using System;
//    using System.Data.Entity;
//    using System.Data.Entity.Migrations;
//    using System.Linq;

//    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationCore.DatabaseContext>
//    {
//        public Configuration()
//        {
//            AutomaticMigrationsEnabled = false;
//        }

//        protected override void Seed(ApplicationCore.DatabaseContext context)
//        {
//            Category c1 = new Category { Name = "Books" };
//            Category c2 = new Category { Name = "Toys" };
//            context.Categories.Add(c1);
//            context.Categories.Add(c2);

//            Role r1 = new Role { Name = "Admin", Description = "Administrator" };
//            Role r2 = new Role { Name = "User", Description = "End User" };

//            User user1 = new User
//            {
//                Username = "admin",
//                Name = "Admin",
//                Password = "123456",
//                ContactNo = "9876543210",
//                Address = "Noida"
//            };
//            User user2 = new User
//            {
//                Username = "user",
//                Name = "User",
//                Password = "123456",
//                ContactNo = "9876543210",
//                Address = "Noida"
//            };

//            user1.Roles.Add(r1);
//            user2.Roles.Add(r2);

//            context.Users.Add(user1);
//            context.Users.Add(user2);
//        }
//    }
//}
