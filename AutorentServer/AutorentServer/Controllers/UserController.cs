using AutorentServer.Domain;
using AutorentServer.Domain.Models;
using AutorentServer.Domain.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AutorentServer.Controllers;
[ApiController]
[Route("users/")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IRepositoryWrapper _repository;

    public UserController(ILogger<UserController> logger, IRepositoryWrapper repository)
    {
        _logger = logger;
        _repository = repository;
    }
    
    [HttpGet]
    public IActionResult GetAllUsers()
    {
        var result = _repository.User.FindAll();
        return null == result ? NotFound() : Ok(result);
    }
    
    // nagyon kókány authentikáció
    [HttpGet("login")]
    public IActionResult Login(string username, string password)
    {
        var result = _repository.User.FindByCondition(usr => usr.Username == username && usr.Password == password);
        
        return null == result ? Unauthorized() : Ok(result);
    }

    [HttpGet("{id}")]
    public ActionResult<User> GetUserDataById(int id)
    {
        var result = _repository.User.FindByCondition(usr => usr.Id == id);
        return null == result ? NotFound() : Ok(result);
    }

    [HttpGet("{userId}/rentals/")]
    public IActionResult GetRentalHistory(int userId)
    {
        var result = _repository.Rental.FindByCondition(rent => rent.UserId == userId);
        return null == result ? NotFound() : Ok(result); 
    }
    
    [HttpGet("{userId}/rentals/{rentalId}")]
    public IActionResult GetRental(int userId, int rentalId)
    {
        var result = _repository.Rental.FindByCondition
            (rent => rent.UserId == userId && rent.Id == rentalId);
        return null == result ? NotFound() : Ok(result); 
    }

    [HttpPost("{userId}/rentals/")]
    public IActionResult RentCar(int userId, int carId, string from, string to)
    {
        Rental r = new Rental
        {
            Id = _repository.Rental.FindAll().OrderBy(r => r.Id).LastOrDefault().Id + 1,
            UserId = userId,
            CarId = carId,
            FromDate = DateOnly.Parse(from),
            ToDate = DateOnly.Parse(to),
            Created = DateTime.Now
        };

        _repository.Rental.Create(r);
        _repository.Save();
        return Ok();
    }
}