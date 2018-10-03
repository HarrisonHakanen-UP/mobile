using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using MobikeApp.ViewModels;
using MobikeApp.Views;
using RestClient.Services;
using Prism.Navigation;
using RestClient.Model;

namespace MobikeApp.ViewModels
{
    public class ItemsViewModel : ViewModelBase
    {
        private ObservableCollection<Produto> _items;
        public ObservableCollection<Produto> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }
        public Command LoadItemsCommand { get; set; }

        public ProdutoService ProdutoService = new ProdutoService();

        public ItemsViewModel()
        {
            Title = "Produtos";
            Items = new ObservableCollection<Produto>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            //MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
            // {
            //     var _item = item as Item;
            //     Items.Add(_item);
            //     await DataStore.AddItemAsync(_item);
            // });
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            //if (IsBusy)
            //    return;

            IsBusy = false;

            Task.Run(async () =>
            {
                await GetProdutos();
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            await GetProdutos();

           
        }

        private async Task GetProdutos()
        {
            try
            {
                Items.Clear();
                Items = await ProdutoService.Get("");
               
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = true;
            }
        }
    }
}
