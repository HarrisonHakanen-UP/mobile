using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Plugin.Connectivity;

namespace MobikeApp.ViewModels
{
    public class RequestAccessViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _pageDialogService;

        private string _cpf;
        public string Cpf
        {
            get { return _cpf; }
            set { SetProperty(ref _cpf, value); }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        private string _motivation;
        public string Motivation
        {
            get { return _motivation; }
            set { SetProperty(ref _motivation, value); }
        }

        public DelegateCommand CancelCommand { get; set; }
        public DelegateCommand RequestAccessCommand { get; set; }

        public RequestAccessViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;
            CancelCommand = new DelegateCommand(async () => await _navigationService.NavigateAsync("LoginPage", null, true, true));
           // RequestAccessCommand = new DelegateCommand(ExecuteRequestAccessCommand);
        }

        //public async void ExecuteRequestAccessCommand()
        //{
        //    if (CrossConnectivity.Current.IsConnected)
        //    {

        //        Login objLogin = new Login();
        //        SuccessfulAnswer objValidationField = objLogin.ValidationFields(Cpf, Email, Motivation);

        //        if (objValidationField.Success == false)
        //        {
        //            await _pageDialogService.DisplayAlertAsync(objValidationField.TitleMessage, objValidationField.Message, "OK");
        //        }
        //        else
        //        {
        //            SuccessfulAnswer objSuccessfulAnswer = await objLogin.DoRequestAcess(Cpf, Email, Motivation);

        //            if (objSuccessfulAnswer.Success == false)
        //                await _pageDialogService.DisplayAlertAsync("Erro!", objSuccessfulAnswer.Message, "OK");
        //            else
        //            {
        //                var msg = "Você recebera por email a confirmação do seu cadastro!";
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