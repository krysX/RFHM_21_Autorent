using AutorentServer.Domain.Repository;
using AutorentServer.Domain.Models;

namespace AutorentServer.Services;

public interface IRentalService
{
    public bool IsAvailableForRent(int carId);
}

public class RentalService : IRentalService
{
    private readonly IRepositoryWrapper _repository;
    


    public RentalService(IRepositoryWrapper repository)
    {
        _repository = repository;
    }

    public bool IsAvailableForRent(int carId)
    {
        DateOnly now = DateOnly.FromDateTime(DateTime.Now);
        var isActual = (Rental r) => (r.FromDate <= now && r.ToDate >= now);
        var rentsForCar = _repository.Rental.FindByCondition(r => isActual(r) && r.CarId == carId);
        return null == rentsForCar;
    }
}