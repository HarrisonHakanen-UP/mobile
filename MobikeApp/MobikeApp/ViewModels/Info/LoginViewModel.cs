using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Plugin.Connectivity;
using Acr.UserDialogs;
//using MobikeApp.Services;
using System.Collections.Generic;

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
            Cpf = "AZURIS";
            Password = "12345";
            #endif
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;

           // LoginCommand = new DelegateCommand(ExecuteDoLogin, CanNavigate).ObservesProperty(() => IsBusy);
            RequestAccessCommand = new DelegateCommand(async () => await _navigationService.NavigateAsync("RequestAccessPage", null, true, true));
            PasswordRecoveryCommand = new DelegateCommand(async () => await _navigationService.NavigateAsync("PasswordRecoveryPage", null, true, true));
          //  AppVersion = $"Versão {GetVersion()}";

//            storeService = Xamarin.Forms.DependencyService.Get<ICredentialsService>();
        }

        //private static string GetVersion()
        //{
        //    //return Xamarin.Forms.DependencyService.Get<IAppVersionService>().GetVersion();
        //}

        //private async void ExecuteDoLogin()
        //{
        //    IsBusy = true;
        //    if (CrossConnectivity.Current.IsConnected)
        //    {
        //        Login objLogin = new Login();
        //        SuccessfulAnswer objSuccessfulAnswer = await objLogin.DoLogin(Cpf, Password);

        //        if (objSuccessfulAnswer.Success == false)
        //        {
        //            await _pageDialogService.DisplayAlertAsync(objSuccessfulAnswer.TitleMessage, objSuccessfulAnswer.Message, "OK");
        //        }
        //        else
        //        {

        //            bool doCredentialsExist = storeService.DoCredentialsExist();
        //            if (!doCredentialsExist)
        //            {
        //                storeService.SaveCredentials(Login.UsuarioValido.usuarioDetalhes.codigo, Login.UsuarioValido.usuarioDetalhes.nome, Login.UsuarioValido.usuarioDetalhes.email, Login.UsuarioValido.accessToken);
        //            }

        //            UnitBo objUnitBo = new UnitBo();
        //            List<Unit> objListUnit = await objUnitBo.GetAllAsync();

        //            foreach (Unit objItem in objListUnit)
        //            {
        //                if (objItem.Main == true)
        //                {
        //                    objUnitBo = new UnitBo(objItem);
        //                }
        //            }

        //            /// Busca perguntas do questionario
        //            QuestionaryBo objQuestionaryBo = new QuestionaryBo();
        //            await objQuestionaryBo.GetQuestionnaire(Settings.Offline);

        //            /// Busca perguntas do diagnostico
        //            DiagnosticBo objDiagnosticBo = new DiagnosticBo();
        //            await objDiagnosticBo.GetDiagnosticQuestionnaire(Settings.Offline);

        //            await _navigationService.NavigateAsync("/AppMasterDetailPage/AppNavigationPage/MainPage", animated: true);
        //        }
        //    }
        //    else
        //    {
        //        var options = new AlertConfig
        //        {
        //            Title = "Erro",
        //            Message = "Sem conectividade com a Internet",
        //            OkText = "OK"
        //        };

        //        await ShowAlert(options);
        //    }
        //    IsBusy = false;
        //}
    }
}
