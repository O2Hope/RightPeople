using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RightPeople.Models;
using RightPeople;

namespace RightPeople.Services
{
    public class MenuServices
    {

        public List<Menu> GetMenu()
        {

            var menuItems = new List<Menu>
            {
                new Menu
                {
                
                    Image="User.png",
                    Name="Perfil",
                    TargetType=typeof(Perfil)
                    
                },
                new Menu
                {

                    Image="Message.png",
                    Name="Mensajes",
                    TargetType=typeof(Mensajes)
                    
                },
                new Menu
                {

                    Image="Alert.png",
                    Name="Alertas",
                    TargetType=typeof(Alertas)

                },
                new Menu
                {

                    Image="people.png",
                    Name="Personas",
                    TargetType=typeof(Personas)

                },
                new Menu
                {

                    Image="Jobs.png",
                    Name="Empleos",
                    TargetType=typeof(Empleos)

                },
                new Menu
                {

                    Image="Book.png",
                    Name="Cursos",
                    TargetType=typeof(Cursos)

                },
                new Menu
                {

                    Image="Shop.png",
                    Name="Compras",
                    TargetType=typeof(Compras)

                },
            };

            return menuItems;

        }

    }
}
