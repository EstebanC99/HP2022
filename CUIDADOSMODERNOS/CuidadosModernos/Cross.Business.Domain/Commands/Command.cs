namespace Cross.Business.Domain.Commands
{
    public abstract class Command<TKey> : IIdentificable<TKey>
    {
        public TKey ID { get; set; }

        protected Command()
        {

        }
    }
}
