using System;
using System.Collections.Generic;

namespace HealthyMeAPI
{
    public partial class Namirnica
    {
        public Namirnica()
        {
            ObrokNamirnica = new HashSet<ObrokNamirnica>();
            Pidozvoljena = new HashSet<Pidozvoljena>();
            Pizabranjena = new HashSet<Pizabranjena>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        public double Kalorije { get; set; }
        public double Proteini { get; set; }
        public double Ugljikohidrati { get; set; }
        public double Masti { get; set; }

        public virtual ICollection<ObrokNamirnica> ObrokNamirnica { get; set; }
        public virtual ICollection<Pidozvoljena> Pidozvoljena { get; set; }
        public virtual ICollection<Pizabranjena> Pizabranjena { get; set; }
    }
}
