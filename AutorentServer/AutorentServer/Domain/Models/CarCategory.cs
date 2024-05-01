namespace AutorentServer.Domain.Models;

public class CarCategory
{
    public int Id { get; set; }
    public string Name { get; set; }
    public IList<Car> Cars { get; set; }
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
    public List<CarDto> Cars { get; set; }
}