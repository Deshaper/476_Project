namespace RetailManagment.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RetailManagment.Data.Model1>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RetailManagment.Data.Model1 context)
        {
            context.Customers.AddOrUpdate(
                d => d.Cus_id,
                new Models.Customer { Cus_id = 1, Name = "Jay", Email = "Jay123@uregina.ca", Username = "Jay123", Password = "Jay123" },
                new Models.Customer { Cus_id = 2, Name = "Kay", Email = "Kay123@uregina.ca", Username = "Kay123", Password = "Kay123" },
                new Models.Customer { Cus_id = 3, Name = "Ken", Email = "Kenken@uregina.ca", Username = "Ken123", Password = "Ken123" }
            );

            context.Sellers.AddOrUpdate(
                d => d.Seller_id,
                new Models.Seller { Seller_id = 1, Seller_Name = "JayJayJay", Cus_id = 1 },
                new Models.Seller { Seller_id = 2, Seller_Name = "KayKalon", Cus_id = 2 },
                new Models.Seller { Seller_id = 3, Seller_Name = "KenKenKen", Cus_id = 3 }
                );

            context.Commodities.AddOrUpdate(
        new Models.Commodity { Commo_id = 1, Price = 10.99f, Commo_name = "Product 1", Category = "Books", Stocks = 100, Description = "Book for computer science", Seller_id = 3 },
        new Models.Commodity { Commo_id = 2, Price = 12.99f, Commo_name = "Product 2", Category = "Games", Stocks = 200, Description = "Description 2", Seller_id = 3 },
        new Models.Commodity { Commo_id = 3, Price = 15.99f, Commo_name = "Product 3", Category = "Electronics", Stocks = 150, Description = "Description 3", Seller_id = 3 },
        new Models.Commodity { Commo_id = 4, Price = 8.99f, Commo_name = "Product 4", Category = "Games", Stocks = 300, Description = "Description 4", Seller_id = 3 },
        new Models.Commodity { Commo_id = 5, Price = 11.99f, Commo_name = "Product 5", Category = "Games", Stocks = 250, Description = "Description 5", Seller_id = 3 },
        new Models.Commodity { Commo_id = 6, Price = 14.99f, Commo_name = "Product 6", Category = "Games", Stocks = 200, Description = "Description 6", Seller_id = 3 },
        new Models.Commodity { Commo_id = 7, Price = 9.99f, Commo_name = "Product 7", Category = "Games", Stocks = 400, Description = "Description 7", Seller_id = 3 },
        new Models.Commodity { Commo_id = 8, Price = 13.99f, Commo_name = "Product 8", Category = "Electronics", Stocks = 300, Description = "Description 8", Seller_id = 3 },
        new Models.Commodity { Commo_id = 9, Price = 16.99f, Commo_name = "Product 9", Category = "Books", Stocks = 250, Description = "Description 9", Seller_id = 3 },
        new Models.Commodity { Commo_id = 10, Price = 7.99f, Commo_name = "Product 10", Category = "Books", Stocks = 500, Description = "Description 10", Seller_id = 3 },
        new Models.Commodity { Commo_id = 11, Price = 10.99f, Commo_name = "Product 11", Category = "Books", Stocks = 350, Description = "Description 11", Seller_id = 3 },
        new Models.Commodity { Commo_id = 12, Price = 12.99f, Commo_name = "Product 12", Category = "Books", Stocks = 300, Description = "Description 12", Seller_id = 3 },
        new Models.Commodity { Commo_id = 13, Price = 8.99f, Commo_name = "Product 13", Category = "Books", Stocks = 600, Description = "Description 13", Seller_id = 3 }
                    );

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}