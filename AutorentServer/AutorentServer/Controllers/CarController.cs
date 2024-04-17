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
    private readonly IRepositoryWrapper _repository;
    
    public CarController(ILogger<CarController> logger, IRepositoryWrapper repository)
    {
        _logger = logger;
        _repository = repository;
    }

    [HttpGet]
    public IActionResult GetCars()
    {
        var result = _repository.Car.FindAll();
        return null == result ? NotFound() : Ok(result);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetCarById(int id)
    {
        var result = _repository.Car.FindByCondition((Car car) => car.Id == id);
        return null == result ? NotFound() : Ok(result);
    }

    [HttpGet("categories")]
    public IActionResult GetCategories()
    {
        var result = _repository.CarCategory.FindAll();
        return null == result ? NotFound() : Ok(result);
    }
    
    [HttpGet("categories/{id}")]
    public IActionResult GetCategory(int id)
    {
        var result = _repository.CarCategory.FindByCondition((CarCategory cat) => cat.Id == id);
        return null == result ? NotFound() : Ok(result);
    }
}