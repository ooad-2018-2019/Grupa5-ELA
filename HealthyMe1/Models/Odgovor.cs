using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HealthyMe1.Models
{
    public class Odgovor
    {
        [ScaffoldColumn(false)]
        public int ID { get; set; }
        [Required]
        public string Naziv { get; set; }
        [Required]
        public int PitanjeID { get; set; }

        public virtual ICollection<PITest> RezultatiTesta { get; set; }
        public virtual Pitanje Pitanje { get; set; }

    }
}
