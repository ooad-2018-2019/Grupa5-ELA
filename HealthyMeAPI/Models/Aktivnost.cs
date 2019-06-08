using System;
using System.Collections.Generic;

namespace HealthyMeAPI
{
    public partial class Aktivnost
    {
        public Aktivnost()
        {
            Dpaktivnost = new HashSet<Dpaktivnost>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        public double Kalorije { get; set; }

        public virtual ICollection<Dpaktivnost> Dpaktivnost { get; set; }
    }
}
