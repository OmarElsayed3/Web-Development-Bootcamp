using API_Task2.Data;
using API_Task2.Interfaces;

namespace API_Task2.Services;

public class GenericRepository<TEntity>(ApplicationDbContext context) : IGenericRepository<TEntity> where TEntity : class
{
    public void Add(TEntity entity)
    {
        context.Set<TEntity>().Add(entity);
    }

    public void Delete(TEntity entity)
    {
        context.Set<TEntity>().Remove(entity);
    }

    public void Update(TEntity entity)
    {
        context.Set<TEntity>().Update(entity);
    }

    public TEntity? GetById(int id)
    {
        return context.Set<TEntity>().Find(id);
    }

    public IEnumerable<TEntity> GetAll()
    {
        return context.Set<TEntity>().ToList();
    }
}