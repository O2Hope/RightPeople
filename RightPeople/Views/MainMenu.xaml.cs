using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using RightPeople.Helpers;
using RightPeople.Models;
using RightPeople.ViewModels;
using Xamarin.Forms;

namespace RightPeople.Views
{

    public partial class MainMenu 
    {

        private ObservableCollection<Usuarios> _item;
        MenuViewModel vm;

        public MainMenu()
        {
            InitializeComponent();
            BindingContext = vm = new MenuViewModel();
            Verdatos();


        }

        private async void Verdatos()
        {
            await GetUsuario();
        }

        void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            if (e.SelectedItem == null)
               return;

         
            var item = (Menu)e.SelectedItem;

            Type page = item.TargetType;

            try
            {

                IsPresented = false;

                Detail = new NavigationPage((Page)Activator.CreateInstance(page))
                {

                    BarBackgroundColor = Color.FromHex("#244764")

                };

                

                ((ListView)sender).SelectedItem = null; 
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private async Task GetUsuario()
        {
            
            var client = new MobileServiceClient("https://coepticket.azurewebsites.net");

            IMobileServiceTable<Usuarios> table = client.GetTable<Usuarios>();
            List<Usuarios> items = await table.Where(u => u.Email == Settings.UserName)
                .Take(1)
                .ToListAsync();

            _item = new ObservableCollection<Usuarios>(items);

            vm.Nombre = _item[0].Nombre + " " + _item[0].Apellido;
            vm.Profesion = _item[0].Profesion;
            vm.Imageen = _item[0].Imagen;

        }

    }
}
