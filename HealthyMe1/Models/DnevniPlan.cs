using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HealthyMe1.Models
{
    public class DnevniPlan
    {
        [ScaffoldColumn(false)]
        public int ID { get; set; }
        [Required]
        public DateTime Period { get; set; }
        [Required]
        public double PreostaleKalorije { get; set; }
        [Required]
        public int RegistrovaniID { get; set; }

        public virtual ICollection<DPObrok> DPObroci { get; set; }
        public virtual ICollection<DPAktivnost> DPAktivnosti { get; set; }
        public virtual Registrovani Registrovani { get; set; }
    }
}
