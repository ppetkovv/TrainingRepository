using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MyTwitter.Data.Repositories.Contracts
{
    public interface IGenericRepository<T> : IReadonlyRepository<T>, IWriteonlyRepository<T> where T : class
    {
        IEnumerable<T> SearchFor(Expression<Func<T, bool>> predicate);
    }
}