using Microsoft.EntityFrameworkCore;

namespace DATABASE
{
    public static class DefaultInfo
    {
        public static void AddDefaultInfo(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(x => x.Phone)
                .WithOne(x => x.User)
                .HasForeignKey<Phone>(x => x.UserId);

            modelBuilder.Entity<ProductsOrder>()
                .HasKey(x => new { x.ProductId, x.OrderId });

            modelBuilder.Entity<ProductsOrder>()
                .HasOne(x => x.Product)
                .WithMany(x => x.ProductsOrders)
                .HasForeignKey(x => x.ProductId);

            modelBuilder.Entity<ProductsOrder>()
                .HasOne(x => x.Order)
                .WithMany(x => x.ProductsOrders)
                .HasForeignKey(x => x.OrderId);

            var countries = new List<Country>()
            {
                new Country(){ Id = 1, Name = "Belarus"},
                new Country(){ Id = 2, Name = "Russia"},
                new Country(){ Id = 3, Name = "USA"}
            };

            modelBuilder.Entity<Country>().HasData(countries);

            var cities = new List<City>()
            {
                new City(){ Id = 1, Name = "Minsk", CountryId = 1 },
                new City(){ Id = 2, Name = "Brest", CountryId = 1 },
                new City(){ Id = 3, Name = "Gomel", CountryId = 1 },
                new City(){ Id = 4, Name = "Moscow", CountryId = 2 },
                new City(){ Id = 5, Name = "Saint Petersburg", CountryId = 2 },
                new City(){ Id = 6, Name = "Novosibirsk", CountryId = 2 },
                new City(){ Id = 7, Name = "New York", CountryId = 3 },
                new City(){ Id = 8, Name = "Los Angeles", CountryId = 3 },
                new City(){ Id = 9, Name = "Chicago", CountryId = 3 }
            };

            modelBuilder.Entity<City>().HasData(cities);

            var users = new List<User>()
            {
                new User() { Id = 1, Name = "Aleksandr", Surname = "Vysotski", Age = 23, CityId = 1 },
                new User() { Id = 2, Name = "Pavel", Surname = "Motuz", Age = 22, CityId = 1 },
                new User() { Id = 3, Name = "Artemiy", Surname = "Kasabuka", Age = 22, CityId = 1 },
                new User() { Id = 4, Name = "Ivan", Surname = "Ivanov", Age = 33, CityId = 2 },
                new User() { Id = 5, Name = "Nikolai", Surname = "Krasko", Age = 29, CityId = 3 },
                new User() { Id = 6, Name = "Maksim", Surname = "Galkin", Age = 40, CityId = 4 },
                new User() { Id = 7, Name = "Alla", Surname = "Pugacheva", Age = 58, CityId = 4 },
                new User() { Id = 8, Name = "Egor", Surname = "Zhelobanov", Age = 9, CityId = 5 },
                new User() { Id = 9, Name = "Nikita", Surname = "Milyavskiy", Age = 78, CityId = 6 },
                new User() { Id = 10, Name = "Tom", Surname = "Kruz", Age = 18, CityId = 7 },
                new User() { Id = 11, Name = "Leonardo", Surname = "Dicaprio", Age = 28, CityId = 7 },
                new User() { Id = 12, Name = "Dwayne", Surname = "Jonson", Age = 41, CityId = 8 },
                new User() { Id = 13, Name = "Henry", Surname = "Cavill", Age = 38, CityId = 8 },
                new User() { Id = 14, Name = "Brad", Surname = "Pitt", Age = 46, CityId = 8 },
                new User() { Id = 15, Name = "Will", Surname = "Smith", Age = 49, CityId = 9 }
            };

            modelBuilder.Entity<User>().HasData(users);

            var phones = new List<Phone>()
            {
                new Phone() { Id = 1, Model = "Xiaomi", Number = "375293776020", UserId = 1 },
                new Phone() { Id = 2, Model = "Iphone", Number = "375296332394", UserId = 2 },
                new Phone() { Id = 3, Model = "Iphone", Number = "375297764345", UserId = 3 },
                new Phone() { Id = 4, Model = "Nokia", Number = "375297463543", UserId = 4 },
                new Phone() { Id = 5, Model = "Iphone", Number = "375256787534", UserId = 5 },
                new Phone() { Id = 6, Model = "Iphone", Number = "802545346", UserId = 6 },
                new Phone() { Id = 7, Model = "Iphone", Number = "802565756", UserId = 7 },
                new Phone() { Id = 8, Model = "Samsung", Number = "802525645", UserId = 8 },
                new Phone() { Id = 9, Model = "Nokia", Number = "802542354", UserId = 9 },
                new Phone() { Id = 10, Model = "Iphone", Number = "125453434", UserId = 10 },
                new Phone() { Id = 11, Model = "Iphone", Number = "123468675", UserId = 11 },
                new Phone() { Id = 12, Model = "Iphone", Number = "123423444", UserId = 12 },
                new Phone() { Id = 13, Model = "Iphone", Number = "123454622", UserId = 13 },
                new Phone() { Id = 14, Model = "Iphone", Number = "123457783", UserId = 14 },
                new Phone() { Id = 15, Model = "Iphone", Number = "123443453", UserId = 15 }
            };

            modelBuilder.Entity<Phone>().HasData(phones);

            var categories = new List<Category>()
            {
                new Category() { Id = 1, Name = "Pizzas" },
                new Category() { Id = 2, Name = "Burgers" },
                new Category() { Id = 3, Name = "Drinks" },
                new Category() { Id = 4, Name = "Snacks" },
                new Category() { Id = 5, Name = "Sauces" }
            };

            modelBuilder.Entity<Category>().HasData(categories);

            var products = new List<Product>()
            {
                new Product() { Id = 1, Name = "California Pizza", Description = "Description of California Pizza", Price = 20, CategoryId = 1 },
                new Product() { Id = 2, Name = "Greek Pizza", Description = "Description of Greek Pizza", Price = 20, CategoryId = 1 },
                new Product() { Id = 3, Name = "Sicilian Pizza", Description = "Description of Sicilian Pizza", Price = 20, CategoryId = 1 },
                new Product() { Id = 4, Name = "Hamburger", Description = "Description of Hamburger", Price = 10, CategoryId = 2 },
                new Product() { Id = 5, Name = "Cheeseburger", Description = "Description of Cheeseburger", Price = 10, CategoryId = 2 },
                new Product() { Id = 6, Name = "Coca cola", Description = "Description of Coca cola", Price = 5, CategoryId = 3 },
                new Product() { Id = 7, Name = "Fanta", Description = "Description of Fanta", Price = 5, CategoryId = 3 },
                new Product() { Id = 8, Name = "Sprite", Description = "Description of Sprite", Price = 5, CategoryId = 3 },
                new Product() { Id = 9, Name = "Fries", Description = "Description of Fries", Price = 7, CategoryId = 4 },
                new Product() { Id = 10, Name = "Sushi", Description = "Description of Sushi", Price = 7, CategoryId = 4 },
                new Product() { Id = 11, Name = "Ketchup", Description = "Description of Ketchup", Price = 3, CategoryId = 5 },
                new Product() { Id = 12, Name = "Soy sauce", Description = "Description of Soy sauce", Price = 3, CategoryId = 5 },
                new Product() { Id = 13, Name = "Tartar sauce", Description = "Description of Tartar sauce", Price = 3, CategoryId = 5 },
                new Product() { Id = 14, Name = "Taco sauce", Description = "Description of Taco sauce", Price = 3, CategoryId = 5 },
                new Product() { Id = 15, Name = "Barbecue sauce", Description = "Description of Barbecue sauce", Price = 3, CategoryId = 5 },
                new Product() { Id = 16, Name = "Cheese sauce", Description = "Description of Cheese sauce", Price = 3, CategoryId = 5 }
            };

            modelBuilder.Entity<Product>().HasData(products);

            DateTime date = DateTime.Now;
            string dateString = date.ToString("g");

            var orders = new List<Order>()
            {
                new Order() { Id = 1, Date = $"{dateString}", UserId = 5 },
                new Order() { Id = 2, Date = $"{dateString}", UserId = 1 },
                new Order() { Id = 3, Date = $"{dateString}", UserId = 14 },
                new Order() { Id = 4, Date = $"{dateString}", UserId = 9 },
                new Order() { Id = 5, Date = $"{dateString}", UserId = 6 },
                new Order() { Id = 6, Date = $"{dateString}", UserId = 15 }
            };

            modelBuilder.Entity<Order>().HasData(orders);

            var productsOrders = new List<ProductsOrder>()
            {
                new ProductsOrder() { OrderId = 1, ProductId = 6 },
                new ProductsOrder() { OrderId = 2, ProductId = 1 },
                new ProductsOrder() { OrderId = 3, ProductId = 10 },
                new ProductsOrder() { OrderId = 4, ProductId = 8 },
                new ProductsOrder() { OrderId = 5, ProductId = 5 },
                new ProductsOrder() { OrderId = 6, ProductId = 14 }
            };

            modelBuilder.Entity<ProductsOrder>().HasData(productsOrders);
        }
    }
}
