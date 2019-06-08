using System;
using System.Collections.Generic;

namespace HealthyMeAPI
{
    public partial class Pitest
    {
        public int PitestId { get; set; }
        public int OdgovorId { get; set; }
        public int PlanIshraneId { get; set; }
        public int RegistrovaniId { get; set; }

        public virtual Odgovor Odgovor { get; set; }
        public virtual PlanIshrane PlanIshrane { get; set; }
        public virtual Registrovani Registrovani { get; set; }
    }
}
