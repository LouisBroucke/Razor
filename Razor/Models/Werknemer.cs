using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Razor.Models
{
    public class Werknemer
    {
        public string Voornaam { get; set; }

        [DisplayFormat(DataFormatString ="{0:€ #,##0.00}")]
        public decimal Wedde { get; set; }

        [DisplayFormat(DataFormatString ="{0:d}")]
        public DateTime InDienst { get; set; }

    }
}
