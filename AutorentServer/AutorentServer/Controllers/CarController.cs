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
        var carDtos = _carService.GetCarDtos(cars);
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
        List<CarCategory> categories = _repository.CarCategory.FindAll().ToList();
        if (categories.Count == 0)
        {
            return NotFound();
        }
        var categoryDtos = _carService.GetCategoryDtos(categories);

        return Ok(categoryDtos);
    }
    
    [HttpGet("categories/{id}")]
    public IActionResult GetCategory(int id)
    {
        var result = _repository.CarCategory.FindById(id);
        return null == result ? NotFound() : Ok(_carService.GetCategoryDetailDto(result));
    }

    [HttpGet("sales/")]
    public IActionResult GetSales()
    {
        var sales = _repository.Sale.FindAll().ToList();
        return Ok(sales);
    }
}