using Prism.Commands;
using Prism.Navigation;
using Prism.Services;

namespace MobikeApp.ViewModels
{
    public class PasswordRecoveryViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _pageDialogService;

        private string _cpf;
        public string Cpf
        {
            get { return _cpf; }
            set { SetProperty(ref _cpf, value); }
        }

        public DelegateCommand CancelCommand { get; set; }
        public DelegateCommand RecoverPasswordCommand { get; set; }

        public PasswordRecoveryViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base("Recuperar senha")
        {
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;
            CancelCommand = new DelegateCommand(async () => await _navigationService.NavigateAsync("LoginPage", null, true, true));
          //  RecoverPasswordCommand = new DelegateCommand(ExecuteRecoverPasswordCommand);
        }


        //private async void ExecuteRecoverPasswordCommand()
        //{

        //    if (CrossConnectivity.Current.IsConnected)
        //    {
        //        Login objLogin = new Login();
        //        SuccessfulAnswer objValidationField = objLogin.ValidationFields(Cpf);

        //        if (objValidationField.Success == false)
        //        {
        //            await _pageDialogService.DisplayAlertAsync(objValidationField.TitleMessage, objValidationField.Message, "OK");
        //        }
        //        else
        //        {
                    
        //            SuccessfulAnswer objSuccessfulAnswer = await objLogin.DoPasswordRecovery(Cpf);

        //            if (objSuccessfulAnswer.Success == false)
        //                await _pageDialogService.DisplayAlertAsync("Erro!", objSuccessfulAnswer.Message, "OK");
        //            else
        //            {
        //                var msg = "Você recebera um lembrete de senha no email!";
        //                await _pageDialogService.DisplayAlertAsync("Aguarde!", msg, "OK");
        //                await _navigationService.NavigateAsync("LoginPage", null, true, true);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        await _pageDialogService.DisplayAlertAsync("Erro", "Sem conectividade com a Internet", "OK");
        //    }
        //}
    }
}
