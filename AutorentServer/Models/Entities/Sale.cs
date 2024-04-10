namespace AutorentServer.Models;

public class Sale
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public string Description { get; set; }
    public int Percent { get; set; }
}