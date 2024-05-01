using AutorentServer.Domain.Models;
using AutorentServer.Domain.Repository;

namespace AutorentServer.Services;

public interface ICarService
{
    public CarDto GetCarDto(Car car);
    public List<CarDto> GetCarDtos(IEnumerable<Car> cars);
    public CarCategoryDto GetCategoryDto(CarCategory cat);
    public List<CarCategoryDto> GetCategoryDtos(IEnumerable<CarCategory> cats);
    public CarCategoryDetailDto GetCategoryDetailDto(CarCategory cat);
    public bool IsAvailableForRent(int carId);
    
}

public class CarService : ICarService
{
    private readonly IRepositoryWrapper _repository;

    public CarService(IRepositoryWrapper repository)
    {
        _repository = repository;
    }
    
    public CarDto GetCarDto(Car car)
    {
        var dto = new CarDto
        {
            BrandAndModel = $"{car.Brand} {car.Model}",
            CategoryName = _repository.CarCategory.FindById(car.CategoryId)?.Name ?? "Uncategorized",
            DailyPrice = car.DailyPrice,
            IsAvailableForRent = IsAvailableForRent(car.Id)
        };

        return dto;
    }

    public List<CarDto> GetCarDtos(IEnumerable<Car> cars)
    {
        List<CarDto> dtos = new List<CarDto>();
        cars.ToList().ForEach(car => dtos.Add(GetCarDto(car)));
        return dtos;
    }
    
    public CarCategoryDto GetCategoryDto(CarCategory cat)
    {
        var dto = new CarCategoryDto
        {
            Name = cat.Name,
            NoCars = cat.Cars.Count
        };

        return dto;
    }

    public List<CarCategoryDto> GetCategoryDtos(IEnumerable<CarCategory> cats)
    {
        var dtos = new List<CarCategoryDto>();
        cats.ToList().ForEach(cat => dtos.Add(GetCategoryDto(cat)));
        return dtos;
    }

    public CarCategoryDetailDto GetCategoryDetailDto(CarCategory cat)
    {
        var cars = GetCarDtos(cat.Cars);
        
        var dto = new CarCategoryDetailDto()
        {
            Name = cat.Name,
            NoCars = cat.Cars.Count,
            Cars = cars
        };

        return dto;
    }
    
    public bool IsAvailableForRent(int carId)
    {
        DateOnly now = DateOnly.FromDateTime(DateTime.Now);
        var isActual = (Rental r) => (r.FromDate <= now && r.ToDate >= now);
        var condition = (Rental r) => (isActual(r) && r.CarId == carId);
        var isRented = _repository.Rental.FindAll().ToList().Exists(r => condition(r));
        return !isRented;
    }
}