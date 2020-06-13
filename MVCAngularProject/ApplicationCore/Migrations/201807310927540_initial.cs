//namespace ApplicationCore.Migrations
//{
//    using System;
//    using System.Data.Entity.Migrations;
    
//    public partial class initial : DbMigration
//    {
//        public override void Up()
//        {
//            CreateTable(
//                "dbo.CartItems",
//                c => new
//                    {
//                        CartItemId = c.Int(nullable: false, identity: true),
//                        ProductId = c.Int(nullable: false),
//                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
//                        Quantity = c.Int(nullable: false),
//                        Total = c.Int(nullable: false),
//                        CartId = c.Int(nullable: false),
//                    })
//                .PrimaryKey(t => t.CartItemId)
//                .ForeignKey("dbo.Carts", t => t.CartId)
//                .ForeignKey("dbo.Products", t => t.ProductId)
//                .Index(t => t.ProductId)
//                .Index(t => t.CartId);
            
//            CreateTable(
//                "dbo.Carts",
//                c => new
//                    {
//                        CartId = c.Int(nullable: false, identity: true),
//                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
//                        UserId = c.Int(nullable: false),
//                        CreatedDate = c.DateTime(nullable: false),
//                        UpdatedDate = c.DateTime(),
//                    })
//                .PrimaryKey(t => t.CartId)
//                .ForeignKey("dbo.Users", t => t.UserId)
//                .Index(t => t.UserId);
            
//            CreateTable(
//                "dbo.Users",
//                c => new
//                    {
//                        UserId = c.Int(nullable: false, identity: true),
//                        Username = c.String(nullable: false, maxLength: 50, unicode: false),
//                        Password = c.String(nullable: false, maxLength: 50, unicode: false),
//                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
//                        Address = c.String(maxLength: 250, unicode: false),
//                        ContactNo = c.String(nullable: false, maxLength: 20, unicode: false),
//                        CreatedDate = c.DateTime(nullable: false),
//                        UpdateDate = c.DateTime(),
//                    })
//                .PrimaryKey(t => t.UserId);
            
//            CreateTable(
//                "dbo.Roles",
//                c => new
//                    {
//                        RoleId = c.Int(nullable: false, identity: true),
//                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
//                        Description = c.String(nullable: false, maxLength: 250, unicode: false),
//                        CreatedDate = c.DateTime(nullable: false),
//                        UpdateDate = c.DateTime(),
//                    })
//                .PrimaryKey(t => t.RoleId);
            
//            CreateTable(
//                "dbo.Products",
//                c => new
//                    {
//                        ProductId = c.Int(nullable: false, identity: true),
//                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
//                        Description = c.String(nullable: false, maxLength: 250, unicode: false),
//                        ImageName = c.String(nullable: false, maxLength: 250, unicode: false),
//                        ImagePath = c.String(nullable: false, maxLength: 500, unicode: false),
//                        CategoryId = c.Int(nullable: false),
//                        CreatedDate = c.DateTime(nullable: false),
//                        UpdateDate = c.DateTime(),
//                    })
//                .PrimaryKey(t => t.ProductId)
//                .ForeignKey("dbo.Categories", t => t.CategoryId)
//                .Index(t => t.CategoryId);
            
//            CreateTable(
//                "dbo.Categories",
//                c => new
//                    {
//                        CategoryId = c.Int(nullable: false, identity: true),
//                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
//                        CreatedDate = c.DateTime(nullable: false),
//                        UpdateDate = c.DateTime(),
//                    })
//                .PrimaryKey(t => t.CategoryId);
            
//            CreateTable(
//                "dbo.OrderItems",
//                c => new
//                    {
//                        OrderItemId = c.Int(nullable: false, identity: true),
//                        ProductId = c.Int(nullable: false),
//                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
//                        Quantity = c.Int(nullable: false),
//                        Total = c.Int(nullable: false),
//                        OrderId = c.Int(nullable: false),
//                    })
//                .PrimaryKey(t => t.OrderItemId)
//                .ForeignKey("dbo.Orders", t => t.OrderId)
//                .ForeignKey("dbo.Products", t => t.ProductId)
//                .Index(t => t.ProductId)
//                .Index(t => t.OrderId);
            
//            CreateTable(
//                "dbo.Orders",
//                c => new
//                    {
//                        OrderId = c.Int(nullable: false, identity: true),
//                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
//                        Customer = c.String(nullable: false, maxLength: 50, unicode: false),
//                        ContactNo = c.String(nullable: false, maxLength: 20, unicode: false),
//                        ShippingAddress = c.String(maxLength: 250, unicode: false),
//                        Status = c.String(maxLength: 20, unicode: false),
//                        CartId = c.Int(nullable: false),
//                        UserId = c.Int(nullable: false),
//                        CreatedDate = c.DateTime(nullable: false),
//                        UpdatedDate = c.DateTime(),
//                    })
//                .PrimaryKey(t => t.OrderId)
//                .ForeignKey("dbo.Carts", t => t.CartId)
//                .ForeignKey("dbo.Users", t => t.UserId)
//                .Index(t => t.CartId)
//                .Index(t => t.UserId);
            
//            CreateTable(
//                "dbo.Transactions",
//                c => new
//                    {
//                        TransactionId = c.String(nullable: false, maxLength: 128),
//                        PaymentId = c.String(),
//                        Status = c.String(nullable: false, maxLength: 20, unicode: false),
//                        PaymentType = c.String(maxLength: 20, unicode: false),
//                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
//                        UserId = c.Int(nullable: false),
//                        CartId = c.Int(nullable: false),
//                        CreatedDate = c.DateTime(nullable: false),
//                        UpdatedDate = c.DateTime(),
//                    })
//                .PrimaryKey(t => t.TransactionId)
//                .ForeignKey("dbo.Carts", t => t.CartId)
//                .ForeignKey("dbo.Users", t => t.UserId)
//                .Index(t => t.UserId)
//                .Index(t => t.CartId);
            
//            CreateTable(
//                "dbo.UserRoles",
//                c => new
//                    {
//                        UserId = c.Int(nullable: false),
//                        RoleId = c.Int(nullable: false),
//                    })
//                .PrimaryKey(t => new { t.UserId, t.RoleId })
//                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
//                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
//                .Index(t => t.UserId)
//                .Index(t => t.RoleId);
            
//        }
        
//        public override void Down()
//        {
//            DropForeignKey("dbo.Transactions", "UserId", "dbo.Users");
//            DropForeignKey("dbo.Transactions", "CartId", "dbo.Carts");
//            DropForeignKey("dbo.OrderItems", "ProductId", "dbo.Products");
//            DropForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders");
//            DropForeignKey("dbo.Orders", "UserId", "dbo.Users");
//            DropForeignKey("dbo.Orders", "CartId", "dbo.Carts");
//            DropForeignKey("dbo.CartItems", "ProductId", "dbo.Products");
//            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
//            DropForeignKey("dbo.CartItems", "CartId", "dbo.Carts");
//            DropForeignKey("dbo.Carts", "UserId", "dbo.Users");
//            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
//            DropForeignKey("dbo.UserRoles", "UserId", "dbo.Users");
//            DropIndex("dbo.UserRoles", new[] { "RoleId" });
//            DropIndex("dbo.UserRoles", new[] { "UserId" });
//            DropIndex("dbo.Transactions", new[] { "CartId" });
//            DropIndex("dbo.Transactions", new[] { "UserId" });
//            DropIndex("dbo.Orders", new[] { "UserId" });
//            DropIndex("dbo.Orders", new[] { "CartId" });
//            DropIndex("dbo.OrderItems", new[] { "OrderId" });
//            DropIndex("dbo.OrderItems", new[] { "ProductId" });
//            DropIndex("dbo.Products", new[] { "CategoryId" });
//            DropIndex("dbo.Carts", new[] { "UserId" });
//            DropIndex("dbo.CartItems", new[] { "CartId" });
//            DropIndex("dbo.CartItems", new[] { "ProductId" });
//            DropTable("dbo.UserRoles");
//            DropTable("dbo.Transactions");
//            DropTable("dbo.Orders");
//            DropTable("dbo.OrderItems");
//            DropTable("dbo.Categories");
//            DropTable("dbo.Products");
//            DropTable("dbo.Roles");
//            DropTable("dbo.Users");
//            DropTable("dbo.Carts");
//            DropTable("dbo.CartItems");
//        }
//    }
//}
