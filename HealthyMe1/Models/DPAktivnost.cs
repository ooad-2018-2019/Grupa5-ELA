using System;
using System.ComponentModel.DataAnnotations;

namespace HealthyMe1.Models
{
    public class DPAktivnost
    {
        [ScaffoldColumn(false)]
        public int DPAktivnostID { get; set; }
        [Required]
        public int DnevniPlanID { get; set; }
        [Required]
        public int AktivnostID { get; set; }
        public double? Trajanje { get; set; }

        public virtual DnevniPlan DnevniPlan { get; set; }
        public virtual Aktivnost Aktivnost { get; set; }
    }
}
