namespace Cross.UI.Web.Models
{
    public class FilterViewModel<TKey> : ViewModel<TKey>
    {

    }

    public class FilterViewModel : FilterViewModel<int>
    {
        public string Descripcion { get; set; }
    }
}
