namespace Cross.Business.Domain
{
    public interface IIdentificable<TKey>
    {
        TKey ID { get; }
    }
}