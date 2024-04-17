using AutorentServer.Domain.Models;

namespace AutorentServer.Domain.Repository;

public interface IUserRepository : IRepositoryBase<User>
{
    
}

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(AutorentContext context) : base(context)
    {
    }
}