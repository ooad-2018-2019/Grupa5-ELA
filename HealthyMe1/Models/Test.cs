using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HealthyMe1.Models
{
    public class Test
    {
        [ScaffoldColumn(false)]
        public int ID { get; set; }

        public virtual ICollection<Pitanje> Pitanja { get; set; }
        public virtual ICollection<Registrovani> RKorisnici { get; set; }
    }
}
