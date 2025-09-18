using Ardalis.Specification.EntityFrameworkCore;
using CleanArch.Application.Abstractions.Repositories;
using CleanArch.Infrastructure.Data;

namespace CleanArch.Infrastructure.Repositories;

public class Repository<TEntity>(ApplicationDbContext dbContext)
    : RepositoryBase<TEntity>(dbContext), IRepository<TEntity> where TEntity : class;
