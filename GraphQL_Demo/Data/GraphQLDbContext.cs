using GraphQL_Demo.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQL_Demo.Data
{
    public class GraphQLDbContext : DbContext
    {
        public GraphQLDbContext(DbContextOptions<GraphQLDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Appetizers", Description = "Start your meal right!" },
                new Category { Id = 2, Name = "Main Course", Description = "Hearty and satisfying meals." },
                new Category { Id = 3, Name = "Desserts", Description = "Sweet treats to end your meal." }
            );

            // Seed Menus
            modelBuilder.Entity<Menu>().HasData(
                new Menu
                {
                    Id = 1,
                    Name = "Garlic Bread",
                    Description = "Crispy garlic bread served with marinara sauce.",
                    Price = 5.99,
                    ImageUrl = "/images/garlic_bread.jpg",
                    CategoryId = 1
                },
                new Menu
                {
                    Id = 2,
                    Name = "Bruschetta",
                    Description = "Toasted bread topped with fresh tomatoes, garlic, and basil.",
                    Price = 6.49,
                    ImageUrl = "/images/bruschetta.jpg",
                    CategoryId = 1
                },
                new Menu
                {
                    Id = 3,
                    Name = "Grilled Chicken",
                    Description = "Juicy grilled chicken with herb butter and vegetables.",
                    Price = 13.99,
                    ImageUrl = "/images/grilled_chicken.jpg",
                    CategoryId = 2
                },
                new Menu
                {
                    Id = 4,
                    Name = "Beef Lasagna",
                    Description = "Classic Italian lasagna with layers of beef and cheese.",
                    Price = 14.50,
                    ImageUrl = "/images/lasagna.jpg",
                    CategoryId = 2
                },
                new Menu
                {
                    Id = 5,
                    Name = "Chocolate Cake",
                    Description = "Moist chocolate cake with rich ganache frosting.",
                    Price = 7.25,
                    ImageUrl = "/images/chocolate_cake.jpg",
                    CategoryId = 3
                },
                new Menu
                {
                    Id = 6,
                    Name = "Tiramisu",
                    Description = "Classic coffee-flavored Italian dessert with mascarpone.",
                    Price = 7.75,
                    ImageUrl = "/images/tiramisu.jpg",
                    CategoryId = 3
                }
            );

            // Seed Reservations
            modelBuilder.Entity<Reservation>().HasData(
                new Reservation
                {
                    Id = 1,
                    CustomerName = "John Doe",
                    ReservationDate = new DateTime(2025, 9, 15, 19, 0, 0),
                    NumberOfGuests = 2,
                    SpecialRequests = "Window seat, please.",
                    ContactInfo = "john@example.com"
                },
                new Reservation
                {
                    Id = 2,
                    CustomerName = "Alice Smith",
                    ReservationDate = new DateTime(2025, 9, 16, 20, 30, 0),
                    NumberOfGuests = 4,
                    SpecialRequests = "Vegetarian options.",
                    ContactInfo = "alice.smith@example.com"
                },
                new Reservation
                {
                    Id = 3,
                    CustomerName = "Michael Johnson",
                    ReservationDate = new DateTime(2025, 9, 17, 18, 45, 0),
                    NumberOfGuests = 6,
                    SpecialRequests = "Birthday celebration.",
                    ContactInfo = "michael.j@example.com"
                },
                new Reservation
                {
                    Id = 4,
                    CustomerName = "Sara Lee",
                    ReservationDate = new DateTime(2025, 9, 18, 21, 15, 0),
                    NumberOfGuests = 3,
                    SpecialRequests = "No peanuts, please.",
                    ContactInfo = "sara.lee@example.com"
                }
            );
        }

        public DbSet<Menu> Menus { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }
}
