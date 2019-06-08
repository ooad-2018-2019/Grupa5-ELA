using System;
using System.Collections.Generic;

namespace HealthyMeAPI
{
    public partial class ObrokNamirnica
    {
        public int ObrokNamirnicaId { get; set; }
        public int ObrokId { get; set; }
        public int NamirnicaId { get; set; }
        public double? Kolicina { get; set; }

        public virtual Namirnica Namirnica { get; set; }
        public virtual Obrok Obrok { get; set; }
    }
}
