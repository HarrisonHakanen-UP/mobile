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
        public ObservableCollection<Produto> Items { get; set; }
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
                try
                {
                    Items.Clear();
                    var itemss = await ProdutoService.GetOne("");
                    foreach (var item in itemss.Property1)
                    {
                        Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
                finally
                {
                    IsBusy = true;
                }
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;


            try
            {
                Items.Clear();
                var itemss = await ProdutoService.GetOne("");
                foreach (var item in itemss.Property1)
                {
                    Items.Add(item);
                }
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
