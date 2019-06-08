using System;
using System.Collections.Generic;

namespace HealthyMeAPI
{
    public partial class Pizabranjena
    {
        public int PizabranjenaId { get; set; }
        public int NamirnicaId { get; set; }
        public int PlanIshraneId { get; set; }

        public virtual Namirnica Namirnica { get; set; }
        public virtual PlanIshrane PlanIshrane { get; set; }
    }
}
