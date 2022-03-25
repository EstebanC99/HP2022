namespace Cross.Business.Domain.Queries
{
    public class DataView<TKey> : IIdentificable<TKey>
    {
        public TKey ID { get; set; }

        public string Descripcion { get; set; }
    }

    public class DataView : DataView<int>
    {

    }
}
