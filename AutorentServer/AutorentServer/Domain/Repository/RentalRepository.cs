using AutorentServer.Domain.Models;

namespace AutorentServer.Domain.Repository;

public interface IRentalRepository : IRepositoryBase<Rental>
{
    
}

public class RentalRepository : RepositoryBase<Rental>, IRentalRepository
{
    public RentalRepository(AutorentContext context) : base(context)
    {
    }
}