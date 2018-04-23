using System;
using System.Collections.Generic;
using System.Text;

namespace MyTwitter.Data.Repositories.Contracts
{
    public interface IReadonlyRepository<T>
    {
        IEnumerable<T> All { get; }
    }
}