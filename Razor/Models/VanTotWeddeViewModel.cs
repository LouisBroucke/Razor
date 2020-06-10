using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Razor.Models
{
    public class VanTotWeddeViewModel
    {
        [Display(Name ="Van wedde:")]
        [Required(ErrorMessage ="Van wedde is verplicht")]
        public decimal? VanWedde { get; set; }

        [Display(Name = "Tot wedde:")]
        [Required(ErrorMessage = "Tot wedde is verplicht")]
        public decimal? TotWedde { get; set; }

        public List<Persoon> Personen { get; set; }
    }
}
