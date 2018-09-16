using System.Linq;
using Xamarin.Auth;
using Xamarin.Forms;
using MobikeApp.Droid.Services;
//using MobikeBusinessObject.IServices;
using Android.App;

[assembly: Dependency(typeof(CredentialsService))]
namespace MobikeApp.Droid.Services
{
    public class CredentialsService //: ICredentialsService
    {
        public string Code => throw new System.NotImplementedException();

        public string UserName => throw new System.NotImplementedException();

        public string Email => throw new System.NotImplementedException();

        public string Token => throw new System.NotImplementedException();

        public void DeleteCredentials()
        {
            throw new System.NotImplementedException();
        }

        public bool DoCredentialsExist()
        {
            throw new System.NotImplementedException();
        }

        public void SaveCredentials(string codigo, string userName, string email, string token)
        {
            throw new System.NotImplementedException();
        }
    }
}
