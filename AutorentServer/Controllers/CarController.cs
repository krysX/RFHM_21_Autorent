using AutorentServer.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AutorentServer.Controllers;

[ApiController]
[Route("cars/")]
public class CarController : ControllerBase
{
    private readonly ILogger<CarController> _logger;
    
    public CarController(ILogger<CarController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<Car> GetCars()
    {
        return DbSimulation.Cars;
    }
    
    [HttpGet("{id}")]
    public IActionResult GetCarById(int id)
    {
        var result = DbSimulation.Cars.Find(car => car.Id == id);
        return null == result ? NotFound() : Ok(result);
    }

    [HttpGet("categories")]
    public IEnumerable<CarCategory> GetCategories()
    {
        return DbSimulation.Categories;
    }
    
    [HttpGet("categories/{id}")]
    public IActionResult GetCategory(int id)
    {
        var result = DbSimulation.Categories.Find(cat => cat.Id == id);
        return null == result ? NotFound() : Ok(result);
    }
}