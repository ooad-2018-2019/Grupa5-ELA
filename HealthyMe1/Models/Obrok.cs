using System;
using System.Collections.Generic;
using HealthyMe.Models.enums;
using System.ComponentModel.DataAnnotations;

namespace HealthyMe1.Models
{
    public class Obrok
    {
        [ScaffoldColumn(false)]
        public int ID { get; set; }
        [Required]
        public Kategorija Kategorija { get; set; }

        public virtual ICollection<ObrokNamirnica> ObrokNamirnice { get; set; }
        public virtual ICollection<DPObrok> DPObroci { get; set; }
    }
}
