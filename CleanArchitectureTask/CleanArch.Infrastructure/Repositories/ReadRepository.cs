using Ardalis.Specification.EntityFrameworkCore;
using CleanArch.Application.Abstractions.Repositories;
using CleanArch.Infrastructure.Data;

namespace CleanArch.Infrastructure.Repositories;

public class ReadRepository<TEntity>(ApplicationDbContext dbContext)
    : RepositoryBase<TEntity>(dbContext), IReadRepository<TEntity> where TEntity : class;
