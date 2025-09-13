using RepositoryImplementation.EF.BaseSpecification;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

public class NoPaginationSpecification<T> : IBaseSpecification<T>
{
    public List<Expression<Func<T, bool>>> Criterias { get; set; }
    public List<Expression<Func<T, object>>> Includes { get; set; }
    public Expression<Func<T, object>> OrderByAsc { get; set; }
    public Expression<Func<T, object>> OrderByDesc { get; set; }
    public int Skip { get; set; }
    public int Take { get; set; }
    public bool IsPaginationEnabled { get; set; } = false;

    public NoPaginationSpecification(IBaseSpecification<T> spec)
    {
        Criterias = spec.Criterias;
        Includes = spec.Includes;
        OrderByAsc = spec.OrderByAsc;
        OrderByDesc = spec.OrderByDesc;
        Skip = 0;
        Take = 0;
        IsPaginationEnabled = false;
    }
}

