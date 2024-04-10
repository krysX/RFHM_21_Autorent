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

public class CarDto
{
    public string BrandAndModel { get; set; }
    public string Category { get; set; }
    public int DailyPrice { get; set; }
    public bool IsAvailableForRent { get; set; }
}