using AutorentServer.Domain;
using AutorentServer.Domain.Models;
using AutorentServer.Domain.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AutorentServer.Services;

namespace AutorentServer.Controllers;

[Authorize(Roles = "Admin,User")]
[ApiController]
[Route("cars/")]
public class CarController : ControllerBase
{
    private readonly ILogger<CarController> _logger;
    private readonly IRepositoryWrapper _repository;
    private readonly IRentalService _rentalService;
    
    public CarController(ILogger<CarController> logger, IRepositoryWrapper repository, IRentalService rentalService)
    {
        _logger = logger;
        _repository = repository;
        _rentalService = rentalService;
    }

    [HttpGet]
    public IActionResult GetCars()
    {
        var cars = _repository.Car.FindAll();
        List<CarDto> carDtos = new List<CarDto>();
        foreach (var car in cars)
        {
            carDtos.Append(new CarDto { 
                BrandAndModel = string.Concat(car.Brand, " ", car.Model), 
                CategoryName = _repository.CarCategory.FindById(car.CategoryId).Name, 
                DailyPrice = car.DailyPrice, 
                IsAvailableForRent = _rentalService.IsAvailableForRent(car.Id)
            });
        }
        return Ok(carDtos);
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