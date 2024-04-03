namespace AutorentServer.Models;

public static class DbSimulation
{
    public static List<User> Users = new List<User>
    {
        new User {Id = 0, Name = "Administrator", Username = "admin", Password = "admin"},
        new User {Id = 1, Name = "User", Username = "user", Password = "user"},
    };

    public static List<Car> Cars = new List<Car>
    {
        new Car { Id = 1, CategoryId = 1, Brand = "Toyota", Model = "RAV4", DailyPrice = 20000 },
        new Car { Id = 2, CategoryId = 2, Brand = "Honda", Model = "Accord", DailyPrice = 16000 },
        new Car { Id = 3, CategoryId = 3, Brand = "Ford", Model = "Focus", DailyPrice = 14000 },
        new Car { Id = 4, CategoryId = 1, Brand = "Jeep", Model = "Wrangler", DailyPrice = 24000 },
        new Car { Id = 5, CategoryId = 2, Brand = "Nissan", Model = "Altima", DailyPrice = 18000 },
        new Car { Id = 6, CategoryId = 3, Brand = "Volkswagen", Model = "Golf", DailyPrice = 12000 }
    };
        
    public static List<CarCategory> Categories = new List<CarCategory>
    {
        new CarCategory { Id = 1, Name = "SUV" },
        new CarCategory { Id = 2, Name = "Sedan" },
        new CarCategory { Id = 3, Name = "Hatchback" }
    };
    
    public static List<Sale> sales = new List<Sale>
    {
        new Sale { Id = 1, CarId = 1, Description = "End of Year Sale", Percent = 10 },
        new Sale { Id = 2, CarId = 2, Description = "Spring Sale", Percent = 15 },
        new Sale { Id = 3, CarId = 4, Description = "Holiday Special", Percent = 20 }
    };
    
    public static List<Rental> rentals = new List<Rental>
    {
        new Rental { Id = 1, UserId = 1, CarId = 1, FromDate = DateOnly.Parse("2024-04-01"), ToDate = DateOnly.Parse("2024-04-05"), Created = DateTime.Now },
        new Rental { Id = 2, UserId = 2, CarId = 3, FromDate = DateOnly.Parse("2024-03-28"), ToDate = DateOnly.Parse("2024-04-03"), Created = DateTime.Now },
        new Rental { Id = 3, UserId = 3, CarId = 5, FromDate = DateOnly.Parse("2024-04-02"), ToDate = DateOnly.Parse("2024-04-04"), Created = DateTime.Now }
    };
    
    
    // public DbSimulation()
    // {
    //     Console.WriteLine("Fake database connection established successfully.");
    // }
}