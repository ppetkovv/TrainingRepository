using System;
using System.Collections.Generic;
using System.Text;

namespace MyTwitter.Data.Repositories.Contracts
{
    public interface IWriteonlyRepository<T>
    {
        void Insert(T entity);
        void Delete(T entity);
        void Attach(T entity);
        void Update(T entity);
    }
}