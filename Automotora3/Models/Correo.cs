using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Automotora3.Models
{
    public class Correo
    {
        [Display(Name = "ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int id { get; set; }

        [Display(Name = "De")]
        public string from { get; set; }

        [Display(Name = "Hacia")]
        public string to { get; set; }

        [Display(Name = "Mensaje")]
        public string body { get; set; }
    }
}
