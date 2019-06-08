using System;
using System.Collections.Generic;

namespace HealthyMeAPI
{
    public partial class Recenzija
    {
        public int Id { get; set; }
        public string Komentar { get; set; }
        public int Ocjena { get; set; }
        public int RegistrovaniId { get; set; }

        public virtual Registrovani Registrovani { get; set; }
    }
}
