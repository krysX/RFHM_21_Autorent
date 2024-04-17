using AutorentServer.Domain.Models;

namespace AutorentServer.Domain.Repository;

public interface ICarRepository : IRepositoryBase<Car>
{
    
}

public class CarRepository : RepositoryBase<Car>, ICarRepository
{
    public CarRepository(AutorentContext context) : base(context)
    {
        
    }
}