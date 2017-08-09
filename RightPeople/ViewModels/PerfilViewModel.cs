using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RightPeople.ViewModels
{
    public class PerfilViewModel : INotifyPropertyChanged
    {

        private string nombre =string.Empty;

        public string Nombre
        {
            get { return nombre; }
            set
            {
                nombre = value;
                OnPropertyChanged();
            }
        }

        private string apellidos = string.Empty;

        public string Apellidos
        {
            get { return apellidos; }
            set
            {
                apellidos = value;
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

        private string imagenPerfil = string.Empty;

        public string ImagenPerfil
        {
            get { return imagenPerfil; }
            set
            {
                imagenPerfil = value;
                OnPropertyChanged();   
            }
        }

        private string cv = string.Empty;

        public string CV
        {
            get { return cv; }
            set
            {
                cv = value;
                OnPropertyChanged();
            }
        }

        private bool running = false;

        public bool Running
        {
            get { return running; }
            set
            {
                running = value;
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

        private string correo = string.Empty;

        public string Correo
        {
            get { return correo; }
            set
            {
                correo = value;
                OnPropertyChanged();
            }
        }

        private string id;

        public string ID
        {
            get { return id; }
            set
            {
                id = value;
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
