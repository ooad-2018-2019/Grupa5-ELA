using System;
using System.Collections.Generic;

namespace HealthyMeAPI
{
    public partial class Rpodsjetnik
    {
        public int RpodsjetnikId { get; set; }
        public int PodsjetnikId { get; set; }
        public int? RegistrovaniId { get; set; }

        public virtual Podsjetnik Podsjetnik { get; set; }
        public virtual Registrovani Registrovani { get; set; }
    }
}
