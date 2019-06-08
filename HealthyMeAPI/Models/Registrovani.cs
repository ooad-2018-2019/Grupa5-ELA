using System;
using System.Collections.Generic;

namespace HealthyMeAPI
{
    public partial class Registrovani
    {
        public Registrovani()
        {
            DnevniPlan = new HashSet<DnevniPlan>();
            Pitest = new HashSet<Pitest>();
            Rpodsjetnik = new HashSet<Rpodsjetnik>();
        }

        public int Id { get; set; }
        public int Spol { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public double Visina { get; set; }
        public double Tezina { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? TestId { get; set; }
        public int? PlanIshraneId { get; set; }
        public string Ime { get; set; }

        public virtual PlanIshrane PlanIshrane { get; set; }
        public virtual Test Test { get; set; }
        public virtual Recenzija Recenzija { get; set; }
        public virtual ICollection<DnevniPlan> DnevniPlan { get; set; }
        public virtual ICollection<Pitest> Pitest { get; set; }
        public virtual ICollection<Rpodsjetnik> Rpodsjetnik { get; set; }
    }
}
