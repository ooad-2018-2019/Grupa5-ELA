using System;
using System.ComponentModel.DataAnnotations;

namespace HealthyMe1.Models
{
    public class PITest
    {
        [ScaffoldColumn(false)]
        public int PITestID { get; set; }
        [Required]
        public int OdgovorID { get; set; }
        [Required]
        public int PlanIshraneID { get; set; }
        [Required]
        public int RegistrovaniID { get; set; }


        public virtual Odgovor Odgovor { get; set; }
        public virtual PlanIshrane PlanIshrane { get; set; }
        public virtual Registrovani Registrovani { get; set; }
     }
}
