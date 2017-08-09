using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RightPeople.ViewModels
{
    public class RegistrarViewModel : INotifyPropertyChanged
    {

        private string correo1 = string.Empty;

        public string Correo1
        {
            get { return correo1; }
            set
            {
                correo1 = value;
                OnPropertyChanged();
            }
        }

        private string correo2 = string.Empty;

        public string Correo2
        {
            get { return correo2; }
            set
            {
                correo2 = value;
                OnPropertyChanged();
            }
        }

        private string password1 = string.Empty;

        public string Password1
        {
            get { return password1; }
            set
            {
                password1 = value;
                OnPropertyChanged();
            }
        }

        private string password2 = string.Empty;

        public string Password2
        {
            get { return password2; }
            set
            {
                password2 = value;
                OnPropertyChanged();
            }
        }

        private string nombre = string.Empty;

        public string Nombre
        {
            get { return nombre; }
            set
            {
                nombre = value;
                OnPropertyChanged();
            }
        }

        private string apellido = string.Empty;

        public string Apellido
        {
            get { return apellido; }
            set
            {
                apellido = value;
                OnPropertyChanged();
            }
        }

        private bool esVisible = false;

        public bool EsVisible
        {
            get { return esVisible; }
            set
            {
                esVisible = value;
                OnPropertyChanged();
            }
        }

        private bool corre = false;

        public bool Corre
        {
            get { return corre; }
            set
            {
                corre = value;
                OnPropertyChanged();
            }
        }

        private string profesion = string.Empty;

        public string Profesion
        {
            get { return profesion; }
            set
            {
                profesion = value;
                OnPropertyChanged();
            }
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
