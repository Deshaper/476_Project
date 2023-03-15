namespace RetailManagment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Commo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cart",
                c => new
                    {
                        Cart_id = c.Int(nullable: false, identity: true),
                        Product_name = c.String(maxLength: 50),
                        Quantity = c.Int(),
                        Cus_id = c.Int(),
                    })
                .PrimaryKey(t => t.Cart_id)
                .ForeignKey("dbo.Customer", t => t.Cus_id)
                .Index(t => t.Cus_id);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Cus_id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255, unicode: false),
                        Email = c.String(nullable: false, maxLength: 50, unicode: false),
                        Username = c.String(maxLength: 50, unicode: false),
                        Password = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Cus_id);
            
            CreateTable(
                "dbo.Check_out",
                c => new
                    {
                        Cho_id = c.Int(nullable: false, identity: true),
                        Amount = c.Single(nullable: false),
                        Cus_id = c.Int(),
                    })
                .PrimaryKey(t => t.Cho_id)
                .ForeignKey("dbo.Customer", t => t.Cus_id)
                .Index(t => t.Cus_id);
            
            CreateTable(
                "dbo.Recipt",
                c => new
                    {
                        Rec_id = c.Int(nullable: false, identity: true),
                        Cho_id = c.Int(),
                    })
                .PrimaryKey(t => t.Rec_id)
                .ForeignKey("dbo.Check_out", t => t.Cho_id)
                .Index(t => t.Cho_id);
            
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        Comm_id = c.Int(nullable: false, identity: true),
                        Comments = c.String(nullable: false, maxLength: 255, unicode: false),
                        Comm_date = c.DateTime(nullable: false),
                        Cus_id = c.Int(),
                        Commo_id = c.Int(),
                    })
                .PrimaryKey(t => t.Comm_id)
                .ForeignKey("dbo.Commodity", t => t.Commo_id)
                .ForeignKey("dbo.Customer", t => t.Cus_id)
                .Index(t => t.Cus_id)
                .Index(t => t.Commo_id);

            CreateTable(
                "dbo.Commodity",
                c => new
                {
                    Commo_id = c.Int(nullable: false, identity: true),
                    Price = c.Single(nullable: false),
                    Commo_name = c.String(nullable: false, maxLength: 50, unicode: false),
                    Category = c.String(maxLength: 50, unicode: false),
                    Brand = c.String(nullable: false, maxLength: 50, unicode: false),
                    Stocks = c.Int(nullable: false),
                    Description = c.String(maxLength: 255, unicode: false),
                    Commodities_img = c.Binary(),
                    Leadtime = c.Int(),
                    DemandVarialbility = c.Decimal(),
                    Seller_id = c.Int(),
                })
                .PrimaryKey(t => t.Commo_id)
                .ForeignKey("dbo.Seller", t => t.Seller_id)
                .Index(t => t.Seller_id);
            
            CreateTable(
                "dbo.Seller",
                c => new
                    {
                        Seller_id = c.Int(nullable: false, identity: true),
                        Seller_Name = c.String(nullable: false, maxLength: 50, unicode: false),
                        Cus_id = c.Int(),
                    })
                .PrimaryKey(t => t.Seller_id)
                .ForeignKey("dbo.Customer", t => t.Cus_id)
                .Index(t => t.Cus_id);
            
            CreateTable(
                "dbo.Rate",
                c => new
                    {
                        rate_id = c.Int(nullable: false, identity: true),
                        Rate = c.Int(nullable: false),
                        Seller_id = c.Int(),
                    })
                .PrimaryKey(t => t.rate_id)
                .ForeignKey("dbo.Seller", t => t.Seller_id)
                .Index(t => t.Seller_id);
            
            CreateTable(
                "dbo.Commodity_rate",
                c => new
                    {
                        Com_rate_id = c.Int(nullable: false, identity: true),
                        Com_rate = c.Int(nullable: false),
                        Comm_id = c.Int(),
                    })
                .PrimaryKey(t => t.Com_rate_id)
                .ForeignKey("dbo.Comment", t => t.Comm_id)
                .Index(t => t.Comm_id);

            CreateTable(
                "dbo.Purchased",
                c => new
                {
                    Pur_id = c.Int(nullable: false, identity: true),
                    Product_name = c.String(nullable: false, maxLength: 50, unicode: false),
                    Brand = c.String(nullable: false, maxLength: 50, unicode: false),
                    Quantity = c.Int(),
                    Price = c.Decimal(),
                    Status = c.String(),
                    Pur_date = c.DateTime(nullable: false),
                    Delivery_date = c.DateTime(nullable: false),
                    Cus_id = c.Int(),
                    Commo_id = c.Int()
                })
                .PrimaryKey(t => t.Pur_id)
                .ForeignKey("dbo.Customer", t => t.Cus_id)
                .ForeignKey("dbo.Commodity", t => t.Commo_id)
                .Index(t => t.Cus_id)
                .Index(t => t.Commo_id);

            CreateTable(
                "dbo.Shipment",
                c => new
                    {
                        Ship_id = c.Int(nullable: false, identity: true),
                        Estimate_date = c.DateTime(nullable: false, storeType: "date"),
                        Duration = c.Int(nullable: false),
                        Pur_id = c.Int(),
                    })
                .PrimaryKey(t => t.Ship_id)
                .ForeignKey("dbo.Purchased", t => t.Pur_id)
                .Index(t => t.Pur_id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Category_name = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.sysdiagrams",
                c => new
                    {
                        diagram_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 128),
                        principal_id = c.Int(nullable: false),
                        version = c.Int(),
                        definition = c.Binary(),
                    })
                .PrimaryKey(t => t.diagram_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shipment", "Pur_id", "dbo.Purchased");
            DropForeignKey("dbo.Purchased", "Cus_id", "dbo.Customer");
            DropForeignKey("dbo.Purchased", "Commo_id", "dbo.Commodity");
            DropForeignKey("dbo.Comment", "Cus_id", "dbo.Customer");
            DropForeignKey("dbo.Commodity_rate", "Comm_id", "dbo.Comment");
            DropForeignKey("dbo.Rate", "Seller_id", "dbo.Seller");
            DropForeignKey("dbo.Seller", "Cus_id", "dbo.Customer");
            DropForeignKey("dbo.Commodity", "Seller_id", "dbo.Seller");
            DropForeignKey("dbo.Comment", "Commo_id", "dbo.Commodity");
            DropForeignKey("dbo.Recipt", "Cho_id", "dbo.Check_out");
            DropForeignKey("dbo.Check_out", "Cus_id", "dbo.Customer");
            DropForeignKey("dbo.Cart", "Cus_id", "dbo.Customer");
            DropIndex("dbo.Shipment", new[] { "Pur_id" });
            DropIndex("dbo.Purchased", new[] { "Cus_id" });
            DropIndex("dbo.Purchased", new[] { "Commo_id" });
            DropIndex("dbo.Commodity_rate", new[] { "Comm_id" });
            DropIndex("dbo.Rate", new[] { "Seller_id" });
            DropIndex("dbo.Seller", new[] { "Cus_id" });
            DropIndex("dbo.Commodity", new[] { "Seller_id" });
            DropIndex("dbo.Comment", new[] { "Commo_id" });
            DropIndex("dbo.Comment", new[] { "Cus_id" });
            DropIndex("dbo.Recipt", new[] { "Cho_id" });
            DropIndex("dbo.Check_out", new[] { "Cus_id" });
            DropIndex("dbo.Cart", new[] { "Cus_id" });
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.Categories");
            DropTable("dbo.Shipment");
            DropTable("dbo.Purchased");
            DropTable("dbo.Commodity_rate");
            DropTable("dbo.Rate");
            DropTable("dbo.Seller");
            DropTable("dbo.Commodity");
            DropTable("dbo.Comment");
            DropTable("dbo.Recipt");
            DropTable("dbo.Check_out");
            DropTable("dbo.Customer");
            DropTable("dbo.Cart");
        }
    }
}
