namespace AutorentServer.Models;

public class CarCategory
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class CarCategoryDto
{
    public string Name { get; set; }
    public int NoCars { get; set; }
}

public class CarCategoryDetailDto
{
    public string Name { get; set; }
    public int NoCars { get; set; }
    public List<Car> Cars { get; set; }
}