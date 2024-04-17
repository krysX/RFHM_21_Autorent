using AutorentServer.Domain.Models;

namespace AutorentServer.Domain.Repository;

public interface ICategoryRepository : IRepositoryBase<CarCategory>
{
    
}

public class CategoryRepository : RepositoryBase<CarCategory>, ICategoryRepository
{
    public CategoryRepository(AutorentContext context) : base(context)
    {
    }
}