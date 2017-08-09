using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightPeople.Models
{
    public class Empleo
    {
        [Newtonsoft.Json.JsonProperty("id")]
        public string Id { get; set; }

        [Microsoft.WindowsAzure.MobileServices.Version]
        public string AzureVersion { get; set; }


        public DateTime DateUtc { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public string DateDisplay { get { return DateUtc.ToLocalTime().ToString("d"); } }

        [Newtonsoft.Json.JsonIgnore]
        public string TimeDisplay { get { return DateUtc.ToLocalTime().ToString("t"); } }

        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Requisitos { get; set; }
        public string Salario { get; set; }
        public string Ubicacion { get; set; }
        public string Empresa { get; set; }
    }
}
