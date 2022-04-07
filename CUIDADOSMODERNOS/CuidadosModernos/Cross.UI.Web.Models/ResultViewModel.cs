using System;
using System.Collections.Generic;

namespace Cross.UI.Web.Models
{
    public class ResultViewModel : ViewModel
    {
        public Object List { get; set; }

        public Object SelectedItems { get; set; }
    }

    public class ResultViewModel<TItem> : ResultViewModel
        where TItem : IViewModel
    {
        public new List<TItem> List { get; private set; }

        public ResultViewModel()
        {
            this.List = new List<TItem>();
        }
    }
}
