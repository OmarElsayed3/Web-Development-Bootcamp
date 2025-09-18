using Ardalis.Specification;

namespace CleanArch.Application.Abstractions.Repositories;

public interface IReadRepository<TEntity> : IReadRepositoryBase<TEntity> where TEntity : class;
