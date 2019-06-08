using System;
using System.Collections.Generic;

namespace HealthyMeAPI
{
    public partial class Test
    {
        public Test()
        {
            Pitanje = new HashSet<Pitanje>();
            Registrovani = new HashSet<Registrovani>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }

        public virtual ICollection<Pitanje> Pitanje { get; set; }
        public virtual ICollection<Registrovani> Registrovani { get; set; }
    }
}
