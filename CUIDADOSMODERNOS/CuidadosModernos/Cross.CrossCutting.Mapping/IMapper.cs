using System.Collections.Generic;

namespace Cross.CrossCutting.Mapping
{
    public interface IMapper<TIn, TOut>
        where TIn : class
        where TOut : class, new()
    {
        List<TOut> Map(List<TIn> source);

        TOut Map(TIn source);
    }
}