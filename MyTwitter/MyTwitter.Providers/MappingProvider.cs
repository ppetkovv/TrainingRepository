using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyTwitter.Providers
{
    public class MappingProvider : IMappingProvider
    {
        private readonly IMapper mapper;

        public MappingProvider(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public T MapTo<T>(object source)
        {
            return this.mapper.Map<T>(source);
        }

        public IQueryable<T> ProjectTo<T>(IQueryable<object> source)
        {
            return source.ProjectTo<T>();
        }

        public IEnumerable<T> ProjectTo<T>(IEnumerable<object> source)
        {
            return source.AsQueryable().ProjectTo<T>();
        }
    }
}
