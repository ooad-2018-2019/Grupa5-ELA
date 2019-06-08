using System;
using System.Collections.Generic;

namespace HealthyMeAPI
{
    public partial class Odgovor
    {
        public Odgovor()
        {
            Pitest = new HashSet<Pitest>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        public int PitanjeId { get; set; }

        public virtual Pitanje Pitanje { get; set; }
        public virtual ICollection<Pitest> Pitest { get; set; }
    }
}
