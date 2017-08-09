using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Plugin.Settings.Abstractions;
using RightPeople.Helpers;
using System.Threading.Tasks;

namespace RightPeople
{


    public partial class Application : Xamarin.Forms.Application
    {
        public Application()
        {
            InitializeComponent();
            
        }



        protected override void OnStart()
        {


            var uno = Settings.SomeInt;

            if (uno == 1)
            {
                MainPage = new Views.MainMenu();
            }
            else
            {
                MainPage = new NavigationPage( new Login());
            }


        }

    

        protected override void OnSleep()
        {
            
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
