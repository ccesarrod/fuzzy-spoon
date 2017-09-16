namespace NorthWind2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderlist : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            //DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            //DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            //DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            //DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            //DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            //DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            //DropIndex("dbo.AspNetUsers", "UserNameIndex");
            //DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            //DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            //CreateTable(
            //    "dbo.Products",
            //    c => new
            //        {
            //            ProductID = c.Int(nullable: false, identity: true),
            //            ProductName = c.String(nullable: false, maxLength: 40),
            //            CategoryID = c.Int(),
            //            QuantityPerUnit = c.String(maxLength: 20),
            //            UnitPrice = c.Decimal(precision: 18, scale: 2),
            //            UnitsInStock = c.Short(),
            //            UnitsOnOrder = c.Short(),
            //            ReorderLevel = c.Short(),
            //            Discontinued = c.Boolean(nullable: false),
            //        })
            //    .PrimaryKey(t => t.ProductID)
            //    .ForeignKey("dbo.Categories", t => t.CategoryID)
            //    .Index(t => t.CategoryID);
            
            //CreateTable(
            //    "dbo.Categories",
            //    c => new
            //        {
            //            CategoryID = c.Int(nullable: false, identity: true),
            //            CategoryName = c.String(nullable: false, maxLength: 15),
            //            Description = c.String(),
            //            Picture = c.Binary(),
            //        })
            //    .PrimaryKey(t => t.CategoryID);
            
            //CreateTable(
            //    "dbo.Carts",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            CustomerID = c.String(maxLength: 5, fixedLength: true),
            //            ProductId = c.Int(nullable: false),
            //            Quantity = c.Int(nullable: false),
            //            UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.Customers", t => t.CustomerID)
            //    .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
            //    .Index(t => t.CustomerID)
            //    .Index(t => t.ProductId);
            
            //CreateTable(
            //    "dbo.Customers",
            //    c => new
            //        {
            //            CustomerID = c.String(nullable: false, maxLength: 5, fixedLength: true),
            //            CompanyName = c.String(nullable: false, maxLength: 40),
            //            ContactName = c.String(maxLength: 30),
            //            ContactTitle = c.String(maxLength: 30),
            //            Email = c.String(maxLength: 70),
            //            Password = c.String(maxLength: 30),
            //            Address = c.String(maxLength: 60),
            //            City = c.String(maxLength: 15),
            //            Region = c.String(maxLength: 15),
            //            PostalCode = c.String(maxLength: 10),
            //            Country = c.String(maxLength: 15),
            //            Phone = c.String(maxLength: 24),
            //            Fax = c.String(maxLength: 24),
            //        })
            //    .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        CustomerID = c.String(maxLength: 5, fixedLength: true),
                        OrderDate = c.DateTime(),
                        RequiredDate = c.DateTime(),
                        ShippedDate = c.DateTime(),
                        Freight = c.Decimal(precision: 18, scale: 2),
                        ShipName = c.String(maxLength: 40),
                        ShipAddress = c.String(maxLength: 60),
                        ShipCity = c.String(maxLength: 15),
                        ShipRegion = c.String(maxLength: 15),
                        ShipPostalCode = c.String(maxLength: 10),
                        ShipCountry = c.String(maxLength: 15),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Customers", t => t.CustomerID)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.Order Details",
                c => new
                    {
                        OrderID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        Discount = c.Single(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderID, t.ProductID })
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.OrderID)
                .Index(t => t.ProductID);
            
            //DropTable("dbo.AspNetRoles");
            //DropTable("dbo.AspNetUserRoles");
            //DropTable("dbo.AspNetUsers");
            //DropTable("dbo.AspNetUserClaims");
            //DropTable("dbo.AspNetUserLogins");
        }
        
        //public override void Down()
        //{
        //    CreateTable(
        //        "dbo.AspNetUserLogins",
        //        c => new
        //            {
        //                LoginProvider = c.String(nullable: false, maxLength: 128),
        //                ProviderKey = c.String(nullable: false, maxLength: 128),
        //                UserId = c.String(nullable: false, maxLength: 128),
        //            })
        //        .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId });
            
        //    CreateTable(
        //        "dbo.AspNetUserClaims",
        //        c => new
        //            {
        //                Id = c.Int(nullable: false, identity: true),
        //                UserId = c.String(nullable: false, maxLength: 128),
        //                ClaimType = c.String(),
        //                ClaimValue = c.String(),
        //            })
        //        .PrimaryKey(t => t.Id);
            
        //    CreateTable(
        //        "dbo.AspNetUsers",
        //        c => new
        //            {
        //                Id = c.String(nullable: false, maxLength: 128),
        //                Email = c.String(maxLength: 256),
        //                EmailConfirmed = c.Boolean(nullable: false),
        //                PasswordHash = c.String(),
        //                SecurityStamp = c.String(),
        //                PhoneNumber = c.String(),
        //                PhoneNumberConfirmed = c.Boolean(nullable: false),
        //                TwoFactorEnabled = c.Boolean(nullable: false),
        //                LockoutEndDateUtc = c.DateTime(),
        //                LockoutEnabled = c.Boolean(nullable: false),
        //                AccessFailedCount = c.Int(nullable: false),
        //                UserName = c.String(nullable: false, maxLength: 256),
        //            })
        //        .PrimaryKey(t => t.Id);
            
        //    CreateTable(
        //        "dbo.AspNetUserRoles",
        //        c => new
        //            {
        //                UserId = c.String(nullable: false, maxLength: 128),
        //                RoleId = c.String(nullable: false, maxLength: 128),
        //            })
        //        .PrimaryKey(t => new { t.UserId, t.RoleId });
            
        //    CreateTable(
        //        "dbo.AspNetRoles",
        //        c => new
        //            {
        //                Id = c.String(nullable: false, maxLength: 128),
        //                Name = c.String(nullable: false, maxLength: 256),
        //            })
        //        .PrimaryKey(t => t.Id);
            
        //    DropForeignKey("dbo.Carts", "ProductId", "dbo.Products");
        //    DropForeignKey("dbo.Carts", "CustomerID", "dbo.Customers");
        //    DropForeignKey("dbo.Order Details", "ProductID", "dbo.Products");
        //    DropForeignKey("dbo.Order Details", "OrderID", "dbo.Orders");
        //    DropForeignKey("dbo.Orders", "CustomerID", "dbo.Customers");
        //    DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
        //    DropIndex("dbo.Order Details", new[] { "ProductID" });
        //    DropIndex("dbo.Order Details", new[] { "OrderID" });
        //    DropIndex("dbo.Orders", new[] { "CustomerID" });
        //    DropIndex("dbo.Carts", new[] { "ProductId" });
        //    DropIndex("dbo.Carts", new[] { "CustomerID" });
        //    DropIndex("dbo.Products", new[] { "CategoryID" });
        //    DropTable("dbo.Order Details");
        //    DropTable("dbo.Orders");
        //    DropTable("dbo.Customers");
        //    DropTable("dbo.Carts");
        //    DropTable("dbo.Categories");
        //    DropTable("dbo.Products");
        //    CreateIndex("dbo.AspNetUserLogins", "UserId");
        //    CreateIndex("dbo.AspNetUserClaims", "UserId");
        //    CreateIndex("dbo.AspNetUsers", "UserName", unique: true, name: "UserNameIndex");
        //    CreateIndex("dbo.AspNetUserRoles", "RoleId");
        //    CreateIndex("dbo.AspNetUserRoles", "UserId");
        //    CreateIndex("dbo.AspNetRoles", "Name", unique: true, name: "RoleNameIndex");
        //    AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        //    AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        //    AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        //    AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id", cascadeDelete: true);
        //}
    }
}
