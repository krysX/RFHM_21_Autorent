using AutorentServer.Domain;
using AutorentServer.Domain.Models;
using AutorentServer.Domain.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AutorentServer.Controllers;

[ApiController]
[Route("cars/")]
public class CarController : ControllerBase
{
    private readonly ILogger<CarController> _logger;
    private readonly ICarRepository _car;
    private readonly ICategoryRepository _category;
    
    public CarController(ILogger<CarController> logger, ICarRepository car, ICategoryRepository category)
    {
        _logger = logger;
        _car = car;
        _category = category;
    }

    [HttpGet]
    public IActionResult GetCars()
    {
        var result = _car.FindAll();
        return null == result ? NotFound() : Ok(result);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetCarById(int id)
    {
        var result = _car.FindByCondition((Car car) => car.Id == id);
        return null == result ? NotFound() : Ok(result);
    }

    [HttpGet("categories")]
    public IActionResult GetCategories()
    {
        var result = _category.FindAll();
        return null == result ? NotFound() : Ok(result);
    }
    
    [HttpGet("categories/{id}")]
    public IActionResult GetCategory(int id)
    {
        var result = _category.FindByCondition((CarCategory cat) => cat.Id == id);
        return null == result ? NotFound() : Ok(result);
    }
}