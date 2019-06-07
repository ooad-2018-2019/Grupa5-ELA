using System;
using System.ComponentModel.DataAnnotations;

namespace HealthyMe1.Models
{
    public class PIZabranjena
    {
        [ScaffoldColumn(false)]
        public int PIZabranjenaID { get; set; }
        [Required]
        public int NamirnicaID { get; set; }
        [Required]
        public int PlanIshraneID { get; set; }

        public virtual Namirnica Zabranjena { get; set; }
        public virtual PlanIshrane PlanIshrane { get; set; }
    }
}
