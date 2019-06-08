using System;
using System.Collections.Generic;

namespace HealthyMeAPI
{
    public partial class Obrok
    {
        public Obrok()
        {
            Dpobrok = new HashSet<Dpobrok>();
            ObrokNamirnica = new HashSet<ObrokNamirnica>();
        }

        public int Id { get; set; }
        public int Kategorija { get; set; }

        public virtual ICollection<Dpobrok> Dpobrok { get; set; }
        public virtual ICollection<ObrokNamirnica> ObrokNamirnica { get; set; }
    }
}
