using AutorentServer.Domain.Models;

namespace AutorentServer.Domain.Repository;

public interface IRepositoryWrapper
{
    ICarRepository Car { get; }
    ICategoryRepository CarCategory { get; }
    IRentalRepository Rental { get; }
    ISaleRepository Sale { get; }
    IUserRepository User { get; }

    void Save();
}

public class RepositoryWrapper : IRepositoryWrapper
{
    private AutorentContext _context;
    private ICarRepository _car;
    private ICategoryRepository _category;
    private IRentalRepository _rental;
    private ISaleRepository _sale;
    private IUserRepository _user;
    
    public ICarRepository Car
    {
        get
        {
            if (_car == null)
            {
                _car = new CarRepository(_context);
            }

            return _car;
        }
    }
    
    public ICategoryRepository CarCategory
    {
        get
        {
            if (_category == null)
            {
                _category = new CategoryRepository(_context);
            }

            return _category;
        }
    }
    
    public IRentalRepository Rental
    {
        get
        {
            if (_rental == null)
            {
                _rental = new RentalRepository(_context);
            }

            return _rental;
        }
    }
    
    public ISaleRepository Sale
    {
        get
        {
            if (_sale == null)
            {
                _sale = new SaleRepository(_context);
            }

            return _sale;
        }
    }
    
    public IUserRepository User
    {
        get
        {
            if (_user == null)
            {
                _user = new UserRepository(_context);
            }

            return _user;
        }
    }

    public RepositoryWrapper(AutorentContext context)
    {
        _context = context;
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}