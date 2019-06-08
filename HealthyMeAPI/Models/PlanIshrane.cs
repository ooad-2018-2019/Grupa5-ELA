using System;
using System.Collections.Generic;

namespace HealthyMeAPI
{
    public partial class PlanIshrane
    {
        public PlanIshrane()
        {
            Pidozvoljena = new HashSet<Pidozvoljena>();
            Pitest = new HashSet<Pitest>();
            Pizabranjena = new HashSet<Pizabranjena>();
            Registrovani = new HashSet<Registrovani>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        public double? DozvoljeneKalorije { get; set; }

        public virtual ICollection<Pidozvoljena> Pidozvoljena { get; set; }
        public virtual ICollection<Pitest> Pitest { get; set; }
        public virtual ICollection<Pizabranjena> Pizabranjena { get; set; }
        public virtual ICollection<Registrovani> Registrovani { get; set; }
    }
}
