using Plugin.Connectivity;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;

namespace MobikeApp.ViewModels
{
    public class ChangePasswordViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _pageDialogService;

        private string _currentPassowrd;
        public string CurrentPassowrd
        {
            get { return _currentPassowrd; }
            set { SetProperty(ref _currentPassowrd, value); }
        }

        private string _newPassword;
        public string NewPassword
        {
            get { return _newPassword; }
            set { SetProperty(ref _newPassword, value); }
        }

        private string _newPasswordConfirm;
        public string NewPasswordConfirm
        {
            get { return _newPasswordConfirm; }
            set { SetProperty(ref _newPasswordConfirm, value); }
        }

        public DelegateCommand ChangePasswordCommand { get; set; }

        public ChangePasswordViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base("Alterar senha")
        {
            IsBusy = false;

            _navigationService = navigationService;
            _pageDialogService = pageDialogService;

            //ChangePasswordCommand = new DelegateCommand(ExecuteChangePasswordCommand, CanNavigate).ObservesProperty(() => IsBusy);
        }

        //private async void ExecuteChangePasswordCommand()
        //{
        //    IsBusy = true;

        //    if (NewPassword == NewPasswordConfirm && !string.IsNullOrEmpty(NewPassword))
        //    {

        //        if (CrossConnectivity.Current.IsConnected)
        //        {
        //            Login objLogin = new Login();
        //            SuccessfulAnswer objSuccessfulAnswer = await objLogin.DoPasswordChange(CurrentPassowrd, NewPassword, NewPasswordConfirm);

        //            if (objSuccessfulAnswer.Success == false)
        //            {
        //                await _pageDialogService.DisplayAlertAsync(objSuccessfulAnswer.TitleMessage, objSuccessfulAnswer.Message, "OK");
        //            }
        //            else
        //            {
        //                await _pageDialogService.DisplayAlertAsync(objSuccessfulAnswer.TitleMessage, objSuccessfulAnswer.Message, "OK");

        //                objSuccessfulAnswer = await objLogin.DoLogin(Login.UsuarioValido.login, NewPassword);

        //                if (objSuccessfulAnswer.Success == false)
        //                {
        //                    await _pageDialogService.DisplayAlertAsync(objSuccessfulAnswer.TitleMessage, objSuccessfulAnswer.Message, "OK");
        //                }
        //                else
        //                {
        //                    var storeService = Xamarin.Forms.DependencyService.Get<ICredentialsService>();
        //                    storeService.SaveCredentials(Login.UsuarioValido.usuarioDetalhes.codigo, Login.UsuarioValido.usuarioDetalhes.nome, Login.UsuarioValido.usuarioDetalhes.email, Login.UsuarioValido.accessToken);
        //                    await _navigationService.NavigateAsync("/AppMasterDetailPage/AppNavigationPage/MainPage", animated: true);
        //                }
        //            }
        //        }
        //        else
        //        {
        //            await _pageDialogService.DisplayAlertAsync("Erro", "Sem conectividade com a Internet", "OK");
        //        }
        //    }
        //    else
        //    {
        //        await _pageDialogService.DisplayAlertAsync("Erro", "Confirme a senha", "OK");
        //    }
        //    IsBusy = false;
        //}
    }
}