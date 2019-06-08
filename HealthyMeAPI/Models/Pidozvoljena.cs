using System;
using System.Collections.Generic;

namespace HealthyMeAPI
{
    public partial class Pidozvoljena
    {
        public int PidozvoljenaId { get; set; }
        public int NamirnicaId { get; set; }
        public int PlanIshraneId { get; set; }

        public virtual Namirnica Namirnica { get; set; }
        public virtual PlanIshrane PlanIshrane { get; set; }
    }
}
