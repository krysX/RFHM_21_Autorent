namespace AutorentServer.Domain.Models;

public class Rental
{
    public int Id { get; set; }
    public int UserId { get; set; }
    
    public int CarId { get; set; }
    public Car Car { get; set; }
    // [ForeignKey(("CarId"))]
    // public Car Car { get; set; }
    
    public DateOnly FromDate { get; set; }
    public DateOnly ToDate { get; set; }
    public DateTime Created { get; set; }

    // public int getTotalPrice => (ToDate.DayNumber - FromDate.DayNumber) * Car.DailyPrice;
}

public class RentalDto
{
    public string RenterName { get; set; }
    public string CarModel { get; set; }
    public DateOnly FromDate { get; set; }
    public DateOnly ToDate { get; set; }
    public int TotalPrice { get; set; }
}