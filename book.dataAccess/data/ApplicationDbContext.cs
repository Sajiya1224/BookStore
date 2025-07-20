using book.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace book.dataAccess.data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
      public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        }   
        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 10 },
                new Category { Id = 2, Name = "Thriller", DisplayOrder = 12 },
                new Category { Id = 3, Name = "Friction", DisplayOrder = 14 },
                new Category { Id = 4, Name = "Horror", DisplayOrder = 16 },
                new Category { Id = 5, Name = "Adventure", DisplayOrder = 11 },
                new Category { Id = 6, Name = "Classical Litrature", DisplayOrder = 15 },
                new Category { Id = 7, Name = " Romance", DisplayOrder = 18 }
                );


            modelBuilder.Entity<Company>().HasData(
                new Company
                {
                    Id = 1,
                    Name = "Tech solution",
                    StreetAddress = "123 Tech st",
                    City = "Tech city",
                    PostalCode = "12121",
                    State = "IL",
                    PhoneNumber = "9811111111"
                },
                new Company
                {
                    Id = 2,
                    Name = "Bulky book",
                    StreetAddress = "234 bulk st",
                    City = "Bulky city",
                    PostalCode = "99999",
                    State = "NY",
                    PhoneNumber = "7896543210"
                },
                new Company
                {
                    Id = 3,
                    Name = "Reader station",
                    StreetAddress = "666 reader st",
                    City = "xyz city",
                    PostalCode = "989898",
                    State = "IL",
                    PhoneNumber = "9812763456"
                }
                );

            modelBuilder.Entity<Product>().HasData(
                 new Product 
                 {   
                     Id = 1, 
                     Title = "Charli and chocolate Factory", 
                     Author = "Roald Dahl", 
                     Description = "Charlie and the Chocolate Factory is a 1964 children's novel by British author Roald Dahl.", 
                     ISBN = "978-0142410318",
                     ListPrice = 30,
                     Price100 = 25,
                     Price50 = 26,
                     Price = 18, 
                     Availability=true,
                     CategoryId = 5,
                     ImgUrl=""
                 },

                 new Product
                 {
                     Id = 2,
                     Title = "Harry Potter",
                     Author = " J.K. Rowling",
                     Description = "Harry Potter is a globally recognized fictional character and the main protagonist of J.K.",
                     ISBN = "FOT000000001",
                     ListPrice = 40,
                     Price100 = 35,
                     Price50 = 30,
                     Price = 28,
                     Availability = true,
                     CategoryId = 2,
                     ImgUrl = ""
                 },

            new Product
                 {
                     Id = 3,
                     Title = "Sophie's World",
                     Author = "Jostein Gaarder",
                     Description = "A novel that explores the history of philosophy through the eyes of a young girl, Sophie, who receives mysterious letters that lead her on a philosophical journey",
                     ISBN = "978-0374530716",
                     ListPrice = 55,
                     Price100 = 44,
                     Price50 = 47,
                     Price = 49,
                     Availability = true,
                     CategoryId = 3,
                     ImgUrl = ""
                 },
            new Product
            {
                Id = 4,
                Title = "The Alchemist",
                Author = "Paulo Coelho",
                Description = " A young shepherd named Santiago embarks on a journey to discover his personal legend, learning about the importance of following one's dreams and listening to one's heart along the way.",
                ISBN = "978-0062315007",
                ListPrice = 30,
                Price100 = 22,
                Price50 = 18,
                Price = 15,
                Availability = true,
                CategoryId = 5,
                ImgUrl = ""
            },

            new Product
            {
                Id = 5,
                Title = "The Great Gatsby",
                Author = " F. Scott Fitzgerald",
                Description = " Set in the Roaring Twenties, this novel tells the story of Jay Gatsby and his unrequited love for Daisy Buchanan, exploring themes of wealth, class, and the American Dream.",
                ISBN = "978-0743273565",
                ListPrice = 49,
                Price100 = 42,
                Price50 = 45,
                Price = 40,
                Availability = true,
                CategoryId = 6,
                ImgUrl = ""
            },
            new Product
             {
                 Id = 6,
                 Title = "The Shining",
                 Author = "Stephen King",
                 Description = "A chilling tale about Jack Torrance, an aspiring writer and recovering alcoholic who becomes the winter caretaker of the haunted Overlook Hotel, where supernatural forces influence his sanity.",
                 ISBN = " 978-0307743657",
                 ListPrice = 46,
                 Price100 = 38,
                 Price50 = 32,
                 Price = 27,
                 Availability = true,
                 CategoryId = 4,
                 ImgUrl = ""
             },

             new Product
             {
                 Id = 7,
                 Title = "Gone Girl",
                 Author = "Gillian Flynn",
                 Description = " A psychological thriller that explores the complexities of marriage and deception, centering on Nick and Amy Dunne, whose lives unravel when Amy goes missing on their anniversary.",
                 ISBN = "978-0307588364",
                 ListPrice = 50,
                 Price100 = 45,
                 Price50 = 40,
                 Price = 35,
                 Availability = true,
                 CategoryId = 2,
                 ImgUrl = ""
             }
                );

        }                                                                                                                                                                                                   

    }
}
