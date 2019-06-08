using System;
using System.Collections.Generic;

namespace HealthyMeAPI
{
    public partial class DnevniPlan
    {
        public DnevniPlan()
        {
            Dpaktivnost = new HashSet<Dpaktivnost>();
            Dpobrok = new HashSet<Dpobrok>();
        }

        public int Id { get; set; }
        public DateTime Period { get; set; }
        public double PreostaleKalorije { get; set; }
        public int RegistrovaniId { get; set; }

        public virtual Registrovani Registrovani { get; set; }
        public virtual ICollection<Dpaktivnost> Dpaktivnost { get; set; }
        public virtual ICollection<Dpobrok> Dpobrok { get; set; }
    }
}
