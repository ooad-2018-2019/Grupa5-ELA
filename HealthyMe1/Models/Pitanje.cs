using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HealthyMe1.Models
{
    public class Pitanje
    {
        [ScaffoldColumn(false)]
        public int ID { get; set; }
        [Required]
        public string Naziv { get; set; }
        [Required]
        public int TestID { get; set; }

        public virtual ICollection<Odgovor> Odgovori { get; set; }
        public virtual Test Test { get; set; }

    }
}
