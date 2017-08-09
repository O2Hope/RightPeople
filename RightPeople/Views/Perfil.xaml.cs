using Android.Graphics;
using Android.Media;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json.Linq;
using Plugin.Media;
using Plugin.Media.Abstractions;
using RightPeople.Helpers;
using RightPeople.Models;
using RightPeople.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RightPeople
{
    public partial class Perfil : ContentPage
    {

        PerfilViewModel vm;
        private ObservableCollection<Usuarios> item;

        private MediaFile _mediaFile;
        private MediaFile _mediaFile2;

        public Perfil()
        {

            InitializeComponent();
            BindingContext = vm = new PerfilViewModel();
            GetUsuario();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {           

            tomarFoto();
          
        }

        private async void tomarFoto()
        {
            vm.Running = true;

            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable
                            || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("Camara", "La camara no responde, vuelve a intentarlo", "OK");
                vm.Running = false;
                return;
            }


            _mediaFile = await CrossMedia.Current.TakePhotoAsync(
               new StoreCameraMediaOptions
               {
                   DefaultCamera = CameraDevice.Front,
                   PhotoSize = PhotoSize.Small,
                   SaveToAlbum = true,
                   Directory = "sample",
                   Name = Guid.NewGuid().ToString() + ".png"
               });

            if (_mediaFile == null)
            {
                vm.Running = false;
                return;
            }

            vm.ImagenPerfil = _mediaFile.Path;
            GuardarFoto();
            vm.Running = false;
        }

        private async Task GetUsuario()
        {
            vm.Running = true;
            var client = new MobileServiceClient("https://coepticket.azurewebsites.net");

            IMobileServiceTable<Usuarios> table = client.GetTable<Usuarios>();
            List<Usuarios> items = await table.Where(u => u.Email == Settings.UserName)
                .Take(1)
                .ToListAsync();

            item = new ObservableCollection<Usuarios>(items);

            vm.Correo = item[0].Email;
            vm.Nombre = item[0].Nombre;
            vm.Apellidos = item[0].Apellido;
            vm.Profesion = item[0].Profesion;
            vm.ImagenPerfil = item[0].Imagen; //Despues cambiar
            vm.CV = item[0].CV;
            vm.ID = item[0].Id;
           

            vm.Running = false;

        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {

            vm.Running = true;
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Ooops", "Esta opcion no esta permitida por el equipo", "Ok");
                vm.Running = false;
                return;
            }

            

             _mediaFile = await CrossMedia.Current.PickPhotoAsync();

            if (_mediaFile == null)
            {
                vm.Running = false;
                return;
            }
            vm.ImagenPerfil = _mediaFile.Path;

            GuardarFoto();

            vm.Running = false;
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {            
            Update();
        }

        private async void GuardarCV()
        {
            
            var content = new MultipartFormDataContent();

            content.Add(new StreamContent(_mediaFile2.GetStream()),
                "\"file\"",
                $"\"{_mediaFile2.Path}\"");

            var httpClient = new HttpClient();

            var uploadServiceBaseAddress = "http://uploadrightp.azurewebsites.net/api/Files/Upload";

            var httpResponseMessage = await httpClient.PostAsync(uploadServiceBaseAddress, content);

            string imagen = await httpResponseMessage.Content.ReadAsStringAsync();

            imagen = imagen.TrimEnd('"');
            imagen = imagen.TrimStart('"');

            vm.CV = "http://uploadrightp.azurewebsites.net/Uploads/" + imagen;
            vm.Running = false;

        }

        private async void GuardarFoto()
        {
            vm.Running = true;
            var content = new MultipartFormDataContent();

            content.Add(new StreamContent(_mediaFile.GetStream()),
                "\"file\"",
                $"\"{_mediaFile.Path}\"");

            var httpClient = new HttpClient();

            var uploadServiceBaseAddress = "http://uploadrightp.azurewebsites.net/api/Files/Upload";

            var httpResponseMessage = await httpClient.PostAsync(uploadServiceBaseAddress, content);

            string imagen = await httpResponseMessage.Content.ReadAsStringAsync();

            imagen = imagen.TrimEnd('"');
            imagen = imagen.TrimStart('"');

            vm.ImagenPerfil = "http://uploadrightp.azurewebsites.net/Uploads/" + imagen;
            vm.Running = false;

        }

        private async void Update()
        {
            vm.Running = true;
            var client = new MobileServiceClient("https://coepticket.azurewebsites.net");

            var table = client.GetTable<Usuarios>();

            JObject jo = new JObject();
            jo.Add("id", vm.ID);
            jo.Add("Nombre", vm.Nombre);
            jo.Add("Apellido", vm.Apellidos);
            jo.Add("Profesion", vm.Profesion);
            jo.Add("Imagen", vm.ImagenPerfil);
            jo.Add("CV", vm.CV);

            var inserted = await table.UpdateAsync(jo);
            vm.Running = false;
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            
            tomarCV();
        }

        private async  void tomarCV()
        {
            vm.Running = true;
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable
                            || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("Camara", "La camara no responde, vuelve a intentarlo", "OK");
                vm.Running = false;
                return;
            }


            _mediaFile2 = await CrossMedia.Current.TakePhotoAsync(
               new StoreCameraMediaOptions
               {
                   DefaultCamera = CameraDevice.Rear,
                   PhotoSize = PhotoSize.Small,
                   SaveToAlbum = true,
                   Directory = "sample",
                   Name = Guid.NewGuid().ToString() + ".png"
               });

            if (_mediaFile2 == null)
            { 
                vm.Running = false;
                return;
            }

            vm.CV = _mediaFile2.Path;
            GuardarCV();
            

            
        }
    }
}
