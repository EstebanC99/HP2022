namespace Cross.UI.Web.Models
{
    public interface IViewModel
    {
        object ID { get; set; }
    }

    public abstract class ViewModel<TKey> : IViewModel
    {
        public TKey ID { get; set; }

        object IViewModel.ID
        {
            get { return this.ID; }
            set { this.ID = (TKey)value; }
        }

        protected ViewModel() { }
    }

    public abstract class ViewModel : ViewModel<int>
    {
        protected ViewModel() { }
    }
}
