using AutorentServer.Domain.Models;
using AutorentServer.Domain.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AutorentServer.Services;

namespace AutorentServer.Controllers;

[Authorize]
[ApiController]
[Route("cars/")]
public class CarController : ControllerBase
{
    private readonly ILogger<CarController> _logger;
    private readonly IRepositoryWrapper _repository;
    private readonly ICarService _carService;
    
    public CarController(ILogger<CarController> logger, IRepositoryWrapper repository, ICarService carService)
    {
        _logger = logger;
        _repository = repository;
        _carService = carService;
    }

    [HttpGet]
    public IActionResult GetCars()
    {
        var cars = _repository.Car.FindAll().ToList();
        List<CarDto> carDtos = new List<CarDto>();
        foreach (var car in cars)
        {
            carDtos.Append(_carService.GetCarDto(car));
        }
        return Ok(carDtos);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetCarById(int id)
    {
        var result = _repository.Car.FindById(id);
        return null == result ? NotFound() : Ok(_carService.GetCarDto(result));
    }

    [HttpGet("categories")]
    public IActionResult GetCategories()
    {
        var result = _repository.CarCategory.FindAll();
        List<CarCategoryDto> categoryDtos = new List<CarCategoryDto>();
        foreach (var cat in result)
        {
            categoryDtos.Append(_carService.GetCategoryDto(cat));
        }

        return null == result ? NotFound() : Ok(categoryDtos);
    }
    
    [HttpGet("categories/{id}")]
    public IActionResult GetCategory(int id)
    {
        var result = _repository.CarCategory.FindByCondition((CarCategory cat) => cat.Id == id)?.ToArray()[0];
        return null == result ? NotFound() : Ok(_carService.GetCategoryDetailDto(result));
    }
}