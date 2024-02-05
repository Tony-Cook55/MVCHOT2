using Microsoft.EntityFrameworkCore;

namespace Hot2.Models
{
    public class SalesOrderContext         : DbContext  // ADD : DbContext to allow certain call ins below to work
    {



        public DbSet<Product> Products { get; set; } = null!;

        public DbSet<Category> Categories { get; set; } = null!;




        // Constructor that sends some options to the parent in this case : DbContext
        public SalesOrderContext(DbContextOptions<SalesOrderContext> options) : base(options) { }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // pppppppppppppppppp PRODUCTS pppppppppppppppppp \\

            // Category
            modelBuilder.Entity<Category>().HasData(
                new Category() { CategoryID = 1, CategoryName = "Accessories" },
                new Category() { CategoryID = 2, CategoryName = "Bikes" },
                new Category() { CategoryID = 3, CategoryName = "Clothing" },
                new Category() { CategoryID = 4, CategoryName = "Components" },
                new Category() { CategoryID = 5, CategoryName = "Car racks" },
                new Category() { CategoryID = 6, CategoryName = "Wheels" }
            );


            // Products
            modelBuilder.Entity<Product>().HasData(

                new Product()
                {
                    ProductID = 1,
                    ProductName = "AeroFlo ATB Wheels",
                    ProductDescShort = "",
                    ProductDescLong = "",
                    ProductImage = "",
                    ProductPrice = 189.00m,
                    ProductQty = 40,

                    CategoryID = 4,
                },
                new Product()
                {
                    ProductID = 2,
                    ProductName = "Clear Shade 85-T Glasses",
                    ProductDescShort = "",
                    ProductDescLong = "",
                    ProductImage = "",
                    ProductPrice = 45.00m,
                    ProductQty = 14,

                    CategoryID = 1,
                },
                new Product()
                {
                    ProductID = 3,
                    ProductName = "Cosmic Elite Road Warrior Wheels",
                    ProductDescShort = "",
                    ProductDescLong = "",
                    ProductImage = "",
                    ProductPrice = 165.00m,
                    ProductQty = 22,

                    CategoryID = 4,
                },
                new Product()
                {
                    ProductID = 4,
                    ProductName = "Cycle-Doc Pro Repair Stand",
                    ProductDescShort = "",
                    ProductDescLong = "",
                    ProductImage = "",
                    ProductPrice = 166.00m,
                    ProductQty = 12,

                    CategoryID = 1,
                },
                new Product()
                {
                    ProductID = 5,
                    ProductName = "Dog Ear Aero-Flow Floor Pump",
                    ProductDescShort = "",
                    ProductDescLong = "",
                    ProductImage = "",
                    ProductPrice = 55.00m,
                    ProductQty = 25,

                    CategoryID = 1,
                }
            );
            // pppppppppppppppppp PRODUCTS pppppppppppppppppp \\

        }






    }


}
