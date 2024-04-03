namespace AutorentServer.Models;

public class Rental
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int CarId { get; set; }
    // [ForeignKey(("CarId"))]
    // public Car Car { get; set; }
    public DateOnly FromDate { get; set; }
    public DateOnly ToDate { get; set; }
    public DateTime Created { get; set; }

    // public int getTotalPrice => (ToDate.DayNumber - FromDate.DayNumber) * Car.DailyPrice;
}