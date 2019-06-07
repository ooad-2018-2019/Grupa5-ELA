using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HealthyMe1.Models
{
    public class PlanIshrane
    {
        [ScaffoldColumn(false)]
        public int ID { get; set; }
        [Required]
        public string Naziv { get; set; }
        public double? DozvoljeneKalorije { get; set; }

        public virtual ICollection<Registrovani> RKorisnici { get; set; }
        public virtual ICollection<PITest> RezultatiTesta { get; set; }
        public virtual ICollection<PIDozvoljena> PIDozvoljene { get; set; }
        public virtual ICollection<PIZabranjena> PIZabranjene { get; set; }
    }
}
