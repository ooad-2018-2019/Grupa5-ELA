using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HealthyMe1.Models
{
    public class Aktivnost
    {
        [ScaffoldColumn(false)]
        public int ID { get; set; }
        [Required]
        public string Naziv { get; set; }
        [Required]
        public double Kalorije { get; set; }

        public virtual ICollection<DPAktivnost> DPAktivnosti { get; set; }
    }
}
