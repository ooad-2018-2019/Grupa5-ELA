using System;
using System.ComponentModel.DataAnnotations;

namespace HealthyMe1.Models
{
    public class DPObrok
    {
        [ScaffoldColumn(false)]
        public int DPObrokID { get; set; }
        [Required]
        public int DnevniPlanID { get; set; }
        [Required]
        public int ObrokID { get; set; }

        public virtual DnevniPlan DnevniPlan { get; set; }
        public virtual Obrok Obrok { get; set; }
    }
}
