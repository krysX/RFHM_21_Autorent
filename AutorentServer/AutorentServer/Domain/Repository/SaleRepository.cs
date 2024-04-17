using AutorentServer.Domain.Models;

namespace AutorentServer.Domain.Repository;

public interface ISaleRepository : IRepositoryBase<Sale>
{
    
}

public class SaleRepository : RepositoryBase<Sale>, ISaleRepository
{
    public SaleRepository(AutorentContext context) : base(context)
    {
    }
}