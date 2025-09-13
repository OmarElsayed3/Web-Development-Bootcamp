namespace Task_3.Repositories.Interfaces
{
    public interface IGenericRepository <TEntity> where TEntity : class
    {
        public Task Create(TEntity entity);

        public Task<TEntity> GetById(int id);

        // For composite key support (StudentCourse)
        Task<TEntity> GetByIds(params object[] keyValues);

        public Task Update(TEntity entity);

        public void Delete(TEntity entity);

        // New: GetAll with specification (filtering, includes, ordering, pagination)
        Task<List<TEntity>> GetAll(IBaseSpecification<TEntity> spec);
        // New: Get count for pagination
        Task<int> CountAsync(IBaseSpecification<TEntity> spec);
    }
}
