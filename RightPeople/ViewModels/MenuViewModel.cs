using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using RightPeople.Services;
using RightPeople.Models;

namespace RightPeople.ViewModels
{
    public class MenuViewModel : INotifyPropertyChanged
    {

        private List<Menu> _menus;

        public List<Menu> Menus
        {
            get { return _menus; }
            set
            {
                _menus = value;
                OnPropertyChanged();
            }
        }

        public MenuViewModel()
        {
            DownloadData();
        }

        private void DownloadData()
        {
            var MenuServices = new MenuServices();
            Menus = MenuServices.GetMenu();
        }

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set
            {
                nombre = value;
                OnPropertyChanged();
            }
        }

        private string imageen;

        public string Imageen
        {
            get { return imageen; }
            set
            {
                imageen = value;
                OnPropertyChanged();
            }
        }

        private string profesion;

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
