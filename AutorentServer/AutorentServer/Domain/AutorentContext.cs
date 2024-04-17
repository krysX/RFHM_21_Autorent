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
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}