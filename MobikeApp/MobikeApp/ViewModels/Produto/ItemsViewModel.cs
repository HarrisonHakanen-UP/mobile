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
using Prism.Commands;

namespace MobikeApp.ViewModels
{
    public class ItemsViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        private ObservableCollection<Produto> _items;
        public ObservableCollection<Produto> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }
        public Command LoadItemsCommand { get; set; }

        public DelegateCommand<Produto> SelectedItem { get; set; }

        public ProdutoService ProdutoService = new ProdutoService();

        public ItemsViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Title = "Produtos";
            Items = new ObservableCollection<Produto>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            SelectedItem = new DelegateCommand<Produto>(ExecuteSelectedItem);

        }

        private async void ExecuteSelectedItem(Produto obj)
        {
            var navigateParam = new NavigationParameters()
                        {
                            { "Produto", obj },
                        };
            await _navigationService.NavigateAsync("ItemDetailPage", navigateParam, true, true);
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
