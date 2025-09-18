using Ardalis.Specification;

namespace CleanArch.Application.Abstractions.Repositories;

public interface IRepository<TEntity> : IRepositoryBase<TEntity> where TEntity : class;
