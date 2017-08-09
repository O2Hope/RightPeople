using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using RightPeople.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Microsoft.WindowsAzure.MobileServices;
using RightPeople.Models;
using Newtonsoft.Json.Linq;
using RightPeople.Helpers;

namespace RightPeople.Views
{

    public partial class Registrarse 
    {
        private RegistrarViewModel _vm;

        public Registrarse()
        {
            InitializeComponent();
            BindingContext = _vm = new RegistrarViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            FrameContainer.HeightRequest = -1;



            LoginButton.Scale = 0.3;
            LoginButton.Opacity = 0;

            UsernameEntry.TranslationX = PasswordEntry.TranslationX =  Nombre.TranslationX = Profesion.TranslationX = -10;
            UsernameEntry.Opacity = PasswordEntry.Opacity = Apellido.Opacity = Profesion.Opacity = 0;
        }

        protected async override Task OnAppearingAnimationEnd()
        {
            var translateLength = 400u;

            await Task.WhenAll(
                Nombre.TranslateTo(0, 0, easing: Easing.SpringOut, length: translateLength),
                Apellido.FadeTo(1));

            await Task.WhenAll(
                UsernameEntry.TranslateTo(0, 0, easing: Easing.SpringOut, length: translateLength),
                UsernameEntry.FadeTo(1),
                Profesion.TranslateTo(0, 0, easing: Easing.SpringOut, length: translateLength),
                Profesion.FadeTo(1),

                (new Func<Task>(async () =>
                {
                    await Task.Delay(200);
                    await Task.WhenAll(
                        PasswordEntry.TranslateTo(0, 0, easing: Easing.SpringOut, length: translateLength),
                        PasswordEntry.FadeTo(1));
                }))());


            await Task.WhenAll(
                LoginButton.ScaleTo(1),
                LoginButton.FadeTo(1));
        }

        protected async override Task OnDisappearingAnimationBegin()
        {
            var taskSource = new TaskCompletionSource<bool>();

            var currentHeight = FrameContainer.Height;

            await Task.WhenAll(
                UsernameEntry.FadeTo(0),
                PasswordEntry.FadeTo(0),
                LoginButton.FadeTo(0),
                Nombre.FadeTo(0),
                Apellido.FadeTo(0));

            OctocatImage.Source = "Verified.png";


            FrameContainer.Animate("HideAnimation", d =>
            {
                FrameContainer.HeightRequest = d;
            },
            start: currentHeight,
            end: 170,
            finished: async (d, b) =>
            {
                await Task.Delay(300);
                taskSource.TrySetResult(true);
            });
         

            await taskSource.Task;
        }

        private async void OnLogin(object sender, EventArgs e)
        {
            if (_vm.Nombre != string.Empty && _vm.Apellido != string.Empty && _vm.Correo1 !=string.Empty && _vm.Password1 != string.Empty)
            {

                _vm.EsVisible = true;
                _vm.Corre = true;


                var client = new MobileServiceClient("https://coepticket.azurewebsites.net");

                IMobileServiceTable<Usuarios> table = client.GetTable<Usuarios>();

                string correo = _vm.Correo1;

                List<Usuarios> items = await table.Where(u => u.Email == correo)
                .ToListAsync();

     
               
                if (items.Count ==0)
                {
                    try
                    {
                        JObject jo = new JObject
                        {
                            {"Email", _vm.Correo1},
                            {"Password", _vm.Password1},
                            {"Nombre", _vm.Nombre},
                            {"Apellido", _vm.Apellido},
                            {"DateUtc", DateTime.Now},
                            {"CV", string.Empty},
                            {"Profesion", _vm.Profesion},
                            {"Imagen", "https://azureblobright.blob.core.windows.net/fullres/Profile.png"}
                        };

                        await table.InsertAsync(jo);

                        await DisplayAlert("Bienvenido!", "Gracias por registrarse :)", "Seguir");

                        Settings.SomeInt = 1;
                        Settings.UserName = _vm.Correo1;

                        Xamarin.Forms.Application.Current.MainPage = new MainMenu();

                        CloseAllPopup();                        

                    }
                    catch (Exception)
                    {
                        // ignored
                    }
                }
                else
                {
                    await DisplayAlert("Error", "El correo ingresado ya existe en nuestra base de datos, intenta iniciar sesion o prueba con otro correo", "Entendido");
                    _vm.EsVisible = true;
                    _vm.Corre = false;
                }

            }
            else
            {
                await DisplayAlert("Error", "Verifica que no falten datos por ingresar", "Entendido");
            }




        }

        private void OnCloseButtonTapped(object sender, EventArgs e)
        {
            CloseAllPopup();
        }

        protected override bool OnBackgroundClicked()
        {
            CloseAllPopup();

            return false;
        }

        private async void CloseAllPopup()
        {
            await Navigation.PopAllPopupAsync();
        }
    }
}