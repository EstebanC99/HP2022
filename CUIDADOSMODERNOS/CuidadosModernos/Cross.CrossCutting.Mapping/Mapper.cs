using AutoMapper;
using System;
using System.Collections.Generic;

namespace Cross.CrossCutting.Mapping
{
    public class Mapper
    {
        public TDestination Map<TSource, TDestination>(TSource objetoAMapear)
            where TSource : class
            where TDestination : class, new()
        {
            var mapper = new Mapper<TSource, TDestination>(cfg =>
            {
                cfg.CreateMap<TSource, TDestination>();
            });

            return mapper.Map(objetoAMapear);
        }

        public TDestination Map<TSource, TDestination>(TSource objetoAMapear, Action<IMapperConfigurationExpression> configuration)
            where TSource : class
            where TDestination : class, new()
        {
            var mapper = new Mapper<TSource, TDestination>(configuration);

            return mapper.Map(objetoAMapear);
        }
    }

    public class Mapper<TIn, TOut> : IMapper<TIn, TOut>
        where TIn : class
        where TOut : class, new()
    {
        private IMapper mapper { get; set; }

        public Mapper()
        {
            var mapperConfig = new MapperConfiguration((c) => c.CreateMap<TIn, TOut>());
            this.mapper = mapperConfig.CreateMapper();
        }

        public Mapper(Action<IMapperConfigurationExpression> configuration)
        {
            var mapperConfig = new MapperConfiguration(configuration);

            this.mapper = mapperConfig.CreateMapper();
        }

        public List<TOut> Map(List<TIn> source)
        {
            var list = new List<TOut>();

            foreach (TIn item in source)
            {
                var mapped = this.mapper.Map<TOut>(item);
                list.Add(mapped);
            }

            return list;
        }

        public TOut Map(TIn source)
        {
            return this.mapper.Map<TOut>(source);
        }

        public TOut Map(TIn source, TOut destination)
        {
            return this.mapper.Map<TIn, TOut>(source, destination);
        }
    }
}
