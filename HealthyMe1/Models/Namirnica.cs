using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace HealthyMe1.Models
{
    public class Namirnica
    {
        [ScaffoldColumn(false)]
        public int ID { get; set; }
        [Required]
        public string Naziv { get; set; }
        [Required]
        public double Kalorije { get; set; }
        [Required]
        public double Proteini { get; set; }
        [Required]
        public double Ugljikohidrati { get; set; }
        [Required]
        public double Masti { get; set; }

        public virtual ICollection<ObrokNamirnica> ObrokNamirnice { get; set; }
        public virtual ICollection<PIZabranjena> Zabranjene { get; set; }
        public virtual ICollection<PIDozvoljena> Dozvoljene { get; set; }
    }
}
