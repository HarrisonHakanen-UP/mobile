using System;

using MobikeApp.Mdels;

namespace MobikeApp.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item)
        {
            Title = item.Nome;
            Item = item;
        }
    }
}
