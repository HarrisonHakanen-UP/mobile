using System;
using Prism.Navigation;
using RestClient.Model;
using RestClient.Services;

namespace MobikeApp.ViewModels
{
    public class ItemDetailViewModel : ViewModelBase
    {
        private Produto _item;
        public Produto Item
        {
            get { return _item; }
            set { SetProperty(ref _item, value); }
        }
        public ItemDetailViewModel()
        {
            
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {

            Item = (Produto)parameters["Produto"];
        }
    }
}
