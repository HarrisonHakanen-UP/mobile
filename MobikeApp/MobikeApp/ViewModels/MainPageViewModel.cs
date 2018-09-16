using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobikeApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public DelegateCommand<string> NavigateCommand { get; set; }

        public MainPageViewModel(INavigationService navigationService)
            : base("MobikeApp")
        {    _navigationService = navigationService;
        
            NavigateCommand = new DelegateCommand<string>(async (string name) => await Navigate(name));

        }
        private async Task Navigate(string name)
        {
            await _navigationService.NavigateAsync(name);
        }
    }
}
