﻿using Prism;
using Prism.Ioc;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using MobikeApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.DryIoc;
using Prism.Navigation;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MobikeApp
{
    public partial class App : PrismApplication
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            AppCenter.Start("android=c181f1ac-ea8d-48eb-baf6-4fc3dfa9e57d;" + 
                "uwp={Your UWP App secret here};" + 
                "ios={Your iOS App secret here}", 
                typeof(Analytics), typeof(Crashes));
            InitializeComponent();

            //Login objLogin = new Login(new UsuarioDetalhes() { Codigo = DependencyService.Get<ICredentialsService>().Code, Email = DependencyService.Get<ICredentialsService>().Email, Nome = DependencyService.Get<ICredentialsService>().UserName }, DependencyService.Get<ICredentialsService>().Token);

             NavigationService.NavigateAsync("LoginPage", null, true, true);
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage>();
            containerRegistry.RegisterForNavigation<ChangePasswordPage>();
            containerRegistry.RegisterForNavigation<AppMasterDetailPage>();
        }
    }
}
