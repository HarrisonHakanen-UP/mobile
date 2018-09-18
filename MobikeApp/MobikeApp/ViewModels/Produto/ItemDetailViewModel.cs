using System;

using MobikeApp.Models;

namespace MobikeApp.ViewModels
{
    public class ItemDetailViewModel : ViewModelBase
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item)
        {
            Title = item.Nome;
            Item = item;
        }
    }
}
