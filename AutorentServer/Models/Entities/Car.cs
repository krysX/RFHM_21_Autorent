namespace AutorentServer.Models;

public class Car
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    // [ForeignKey(("CategoryId"))]
    // public CarCategory Category { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public int DailyPrice { get; set; }
}