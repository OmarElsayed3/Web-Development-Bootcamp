namespace Task_3.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class;
        Task<int> CompleteAsync();
    }
}
