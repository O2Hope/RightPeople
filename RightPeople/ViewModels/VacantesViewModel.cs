using Microsoft.WindowsAzure.MobileServices;
using RightPeople.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RightPeople.ViewModels
{
    public class VacantesViewModel : INotifyPropertyChanged
    {

        private List<Empleo> listaEmpleos;

        public List<Empleo> ListaEmpleos
        {
            get { return listaEmpleos; }
            set
            {
                listaEmpleos = value;
                OnPropertyChanged();
            }
        }


        private bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                if (isBusy == value)
                    return;

                isBusy = value;
                OnPropertyChanged();
            }
        }


        private Command loadEmpleosCommand;

        public Command LoadEmpleosCommand
        {
            get
            {
                return loadEmpleosCommand ?? (loadEmpleosCommand = new Command(ExecuteLoadEmpleosCommand, () =>
                {
                    return !IsBusy;
                }));
            }
        }

        private async void ExecuteLoadEmpleosCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            LoadEmpleosCommand.ChangeCanExecute();

            var client = new MobileServiceClient("https://coepticket.azurewebsites.net");

            IMobileServiceTable<Empleo> table = client.GetTable<Empleo>();
            ListaEmpleos = await table.ToListAsync();

            IsBusy = false;
            LoadEmpleosCommand.ChangeCanExecute();
        }





        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
