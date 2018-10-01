using Prism.Commands;
using Prism.Navigation;
using Prism.Services;

namespace MobikeApp.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _pageDialogService;

        private string _cpf;
        public string Cpf
        {
            get { return _cpf; }
            set { SetProperty(ref _cpf, value); }
        }

        private string _appVersion;
        public string AppVersion
        {
            get { return _appVersion; }
            set { SetProperty(ref _appVersion, value); }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public DelegateCommand LoginCommand { get; set; }
        public DelegateCommand PasswordRecoveryCommand { get; set; }
        public DelegateCommand RequestAccessCommand { get; set; }

        public LoginViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            IsBusy = false;

#if (DEBUG)
            Cpf = "Andre@gmail.com";
            Password = "12345";
#endif
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;

            LoginCommand = new DelegateCommand(ExecuteDoLogin, CanNavigate).ObservesProperty(() => IsBusy);
            RequestAccessCommand = new DelegateCommand(async () => await _navigationService.NavigateAsync("RequestAccessPage", null, true, true));
          
        }



        private async void ExecuteDoLogin()
        {
            await _navigationService.NavigateAsync("MainPage", null, true, true);
        }
    }
}
