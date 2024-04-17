using AutorentServer.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AutorentServer.Domain;

public class AutorentContext : DbContext
{
    public DbSet<Car> Cars { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<CarCategory> Categories { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<Rental> Rentals { get; set; }
    
    public string DbPath { get; }

    public AutorentContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "autorent.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>().Property(c => c.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<CarCategory>().Property(c => c.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Sale>().Property(s => s.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Rental>().Property(r => r.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<User>().Property(u => u.Id).ValueGeneratedOnAdd();

        modelBuilder.Entity<Car>().HasData(
            new Car { Id = 1, CategoryId = 1, Brand = "Toyota", Model = "RAV4", DailyPrice = 20000 },
            new Car { Id = 2, CategoryId = 2, Brand = "Honda", Model = "Accord", DailyPrice = 16000 },
            new Car { Id = 3, CategoryId = 3, Brand = "Ford", Model = "Focus", DailyPrice = 14000 },
            new Car { Id = 4, CategoryId = 1, Brand = "Jeep", Model = "Wrangler", DailyPrice = 24000 },
            new Car { Id = 5, CategoryId = 2, Brand = "Nissan", Model = "Altima", DailyPrice = 18000 },
            new Car { Id = 6, CategoryId = 3, Brand = "Volkswagen", Model = "Golf", DailyPrice = 12000 }
        );

        modelBuilder.Entity<CarCategory>().HasData(
            new CarCategory { Id = 1, Name = "SUV" },
            new CarCategory { Id = 2, Name = "Sedan" },
            new CarCategory { Id = 3, Name = "Hatchback" }
        );

        modelBuilder.Entity<Sale>().HasData(
            new Sale { Id = 1, CarId = 1, Description = "End of Year Sale", Percent = 10 },
            new Sale { Id = 2, CarId = 2, Description = "Spring Sale", Percent = 15 },
            new Sale { Id = 3, CarId = 4, Description = "Holiday Special", Percent = 20 }
        );
        
        modelBuilder.Entity<Rental>().HasData(
            new Rental
            {
                Id = 1, UserId = 1, CarId = 1, FromDate = DateOnly.Parse("2024-04-01"),
                ToDate = DateOnly.Parse("2024-04-05"), Created = DateTime.Now
            },
            new Rental
            {
                Id = 2, UserId = 2, CarId = 3, FromDate = DateOnly.Parse("2024-03-28"),
                ToDate = DateOnly.Parse("2024-04-03"), Created = DateTime.Now
            },
            new Rental
            {
                Id = 3, UserId = 3, CarId = 5, FromDate = DateOnly.Parse("2024-04-02"),
                ToDate = DateOnly.Parse("2024-04-04"), Created = DateTime.Now
            }
        );

        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Name = "Administrator", Username = "admin", Password = "admin" },
            new User { Id = 2, Name = "User", Username = "user", Password = "user" }
        );
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}