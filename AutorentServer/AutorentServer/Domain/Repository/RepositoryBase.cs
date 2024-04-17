using System.Linq.Expressions;
using AutorentServer.Domain;
using Microsoft.EntityFrameworkCore;

namespace AutorentServer.Domain.Repository;

public interface IRepositoryBase<T>
{
    IQueryable<T> FindAll();
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
}

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    protected AutorentContext _context { get; set; } 
    public RepositoryBase(AutorentContext context) 
    {
        _context = context; 
    }
    public IQueryable<T> FindAll() => _context.Set<T>().AsNoTracking();
    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) => 
        _context.Set<T>().Where(expression).AsNoTracking();
    public void Create(T entity) => _context.Set<T>().Add(entity);
    public void Update(T entity) => _context.Set<T>().Update(entity);
    public void Delete(T entity) => _context.Set<T>().Remove(entity);
}