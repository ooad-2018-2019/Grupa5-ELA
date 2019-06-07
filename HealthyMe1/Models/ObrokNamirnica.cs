using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace HealthyMe1.Models
{
    public class ObrokNamirnica
    {
        [ScaffoldColumn(false)]
        public int ObrokNamirnicaID { get; set; }
        [Required]
        public int ObrokID { get; set; }
        [Required]
        public int NamirnicaID { get; set; }
        public double? Kolicina { get; set; }

        public virtual Obrok Obrok { get; set; }
        public virtual Namirnica Namirnica { get; set; }
    }
}
