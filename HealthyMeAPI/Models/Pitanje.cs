using System;
using System.Collections.Generic;

namespace HealthyMeAPI
{
    public partial class Pitanje
    {
        public Pitanje()
        {
            Odgovor = new HashSet<Odgovor>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        public int TestId { get; set; }

        public virtual Test Test { get; set; }
        public virtual ICollection<Odgovor> Odgovor { get; set; }
    }
}
