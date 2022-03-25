namespace Cross.Business.Domain.Queries
{
    public class Criteria<TKey> : IIdentificable<TKey>
    {
        public TKey ID { get; set; }

        public string Descripcion { get; set; }
    }

    public class Criteria : Criteria<int>
    {

    }
}
