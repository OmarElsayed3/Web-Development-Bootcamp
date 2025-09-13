namespace Task_3.Repositories.Implementations
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public virtual async Task Create(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public virtual void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }
        public virtual async Task<List<TEntity>> GetAll(IBaseSpecification<TEntity> spec)
        {
            var query = SpecificationEvaluator<TEntity>.GetQueryWithSpec(_context.Set<TEntity>().AsQueryable(), spec);
            return await query.ToListAsync();
        }

        public virtual async Task<int> CountAsync(IBaseSpecification<TEntity> spec)
        {
            // Count should not apply pagination
            var query = SpecificationEvaluator<TEntity>.GetQueryWithSpec(_context.Set<TEntity>().AsQueryable(), new NoPaginationSpecification<TEntity>(spec));
            return await query.CountAsync();
        }

        public virtual async Task<TEntity> GetById(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task<TEntity> GetByIds(params object[] keyValues)
        {
            return await _context.Set<TEntity>().FindAsync(keyValues);
        }

        public virtual async Task Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
