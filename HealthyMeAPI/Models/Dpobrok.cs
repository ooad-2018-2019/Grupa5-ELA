using System;
using System.Collections.Generic;

namespace HealthyMeAPI
{
    public partial class Dpobrok
    {
        public int DpobrokId { get; set; }
        public int DnevniPlanId { get; set; }
        public int ObrokId { get; set; }

        public virtual DnevniPlan DnevniPlan { get; set; }
        public virtual Obrok Obrok { get; set; }
    }
}
