using AutorentServer.Domain.Models;
using AutorentServer.Domain.Repository;

namespace AutorentServer.Services;

public interface ICarService
{
    public CarDto GetCarDto(Car car);
    public CarCategoryDto GetCategoryDto(CarCategory cat);
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
    
    public CarCategoryDto GetCategoryDto(CarCategory cat)
    {
        var dto = new CarCategoryDto
        {
            Name = cat.Name,
            NoCars = cat.Cars.Count
        };

        return dto;
    }

    public CarCategoryDetailDto GetCategoryDetailDto(CarCategory cat)
    {
        var cars = cat.Cars.ToList();
        List<CarDto> carDtos = new List<CarDto>();

        foreach (Car car in cars)
        {
            carDtos.Append(GetCarDto(car));
        }
        
        var dto = new CarCategoryDetailDto()
        {
            Name = cat.Name,
            NoCars = cat.Cars.Count,
            Cars = carDtos
        };

        return dto;
    }
    
    public bool IsAvailableForRent(int carId)
    {
        DateOnly now = DateOnly.FromDateTime(DateTime.Now);
        var isActual = (Rental r) => (r.FromDate <= now && r.ToDate >= now);
        var rentsForCar = _repository.Rental.FindByCondition(r => isActual(r) && r.CarId == carId);
        return null == rentsForCar;
    }
}