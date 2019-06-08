using System;
using System.Collections.Generic;

namespace HealthyMeAPI
{
    public partial class Dpaktivnost
    {
        public int DpaktivnostId { get; set; }
        public int DnevniPlanId { get; set; }
        public int AktivnostId { get; set; }
        public double? Trajanje { get; set; }

        public virtual Aktivnost Aktivnost { get; set; }
        public virtual DnevniPlan DnevniPlan { get; set; }
    }
}
