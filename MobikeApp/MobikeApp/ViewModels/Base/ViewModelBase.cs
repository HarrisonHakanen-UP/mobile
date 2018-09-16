using Acr.UserDialogs;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobikeApp.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware
    {

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        private bool _isBusy;
        public bool IsBusy
        {
            get { return !_isBusy; }
            set { SetProperty(ref _isBusy, value); RaisePropertyChanged("IsBusy"); }
        }

        public ViewModelBase(string title = "")
        {
            _title = title;
        }
        public virtual bool CanNavigate()
        {
            return IsBusy;
        }
        public static void Initialize()
        {

        }
        public virtual void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(NavigationParameters parameters)
        {

        }

        public virtual void OnNavigatingTo(NavigationParameters parameters)
        {

        }

        public virtual void Destroy()
        {

        }

        public void ShowLoading(string message, MaskType? masktype = default(MaskType?))
        {
            UserDialogs.Instance.ShowLoading(message, masktype);
        }
        public void ShowToast(ToastConfig options)
        {
            UserDialogs.Instance.Toast(options);
        }
        public Task ShowAlert(AlertConfig options)
        {
            var result = UserDialogs.Instance.AlertAsync(options);

            return result;
        }


        public void HideLoading()
        {
            UserDialogs.Instance.HideLoading();
        }
    }
}
