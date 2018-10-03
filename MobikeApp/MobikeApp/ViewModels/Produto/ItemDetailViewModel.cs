using System;
using RestClient.Model;
using RestClient.Services;

namespace MobikeApp.ViewModels
{
    public class ItemDetailViewModel : ViewModelBase
    {
        public Produto Item { get; set; }
        public ItemDetailViewModel(Produto item)
        {
            Title = item.nome;
            Item = item;
        }
    }
}
