using System;
using System.Collections.Generic;

namespace HealthyMeAPI
{
    public partial class Podsjetnik
    {
        public Podsjetnik()
        {
            Rpodsjetnik = new HashSet<Rpodsjetnik>();
        }

        public int Id { get; set; }
        public string Opis { get; set; }
        public DateTime Period { get; set; }
        public int Ponavljanje { get; set; }

        public virtual ICollection<Rpodsjetnik> Rpodsjetnik { get; set; }
    }
}
