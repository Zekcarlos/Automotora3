using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Automotora3.Models
{
    public class Clientes
    {
        public int Id { get; set; }
        public string Rut { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FenchaNacimiento { get; set; }
    }
}
