using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyTwitter.Providers
{
    public interface IMappingProvider
    {
        T MapTo<T>(object source);

        IQueryable<T> ProjectTo<T>(IQueryable<object> source);

        IEnumerable<T> ProjectTo<T>(IEnumerable<object> source);
    }
}