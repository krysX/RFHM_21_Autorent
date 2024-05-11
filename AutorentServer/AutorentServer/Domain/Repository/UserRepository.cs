using AutorentServer.Domain.Models;

namespace AutorentServer.Domain.Repository;

public interface IUserRepository : IRepositoryBase<User>
{
    public User? FindByUsername(string username);
}

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(AutorentContext context) : base(context)
    {
    }

    public User? FindByUsername(string username)
    {
        var found = _context.Users.Where(usr => usr.Username == username).ToArray();
        return found.Length > 0 ? found[0] : null;
    }
}