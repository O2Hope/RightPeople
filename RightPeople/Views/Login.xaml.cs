using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Settings.Abstractions;
using RightPeople.Helpers;
using Rg.Plugins.Popup.Extensions;
using RightPeople.Views;

namespace RightPeople
{

    public partial class Login : ContentPage
    {


        public Login()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }




        private  void btnGoogle_Clicked(object sender, EventArgs e)
        {

          //  var auth = new OAuth2Authenticator(
          //Constants.ClientId,
          //Constants.ClientSecret,
          //Constants.Scope,
          //new Uri(Constants.AuthorizeUrl),
          //new Uri(Constants.RedirectUrl),
          //new Uri(Constants.AccessTokenUrl));

        }

        private async void IniciarSesion_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushPopupAsync(new IniciarSesion());
        }

        private async void Registrarse_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushPopupAsync(new Registrarse());
        }
    }
}
