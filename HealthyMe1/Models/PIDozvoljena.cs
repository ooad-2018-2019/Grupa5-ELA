using System;
using HealthyMe.Models;
using System.ComponentModel.DataAnnotations;

namespace HealthyMe1.Models
{
    public class PIDozvoljena
    {
        [ScaffoldColumn(false)]
        public int PIDozvoljenaID { get; set; }
        [Required]
        public int NamirnicaID { get; set; }
        [Required]
        public int PlanIshraneID { get; set; }

        public virtual Namirnica Dozvoljena { get; set; }
        public virtual PlanIshrane PlanIshrane { get; set; }
    }
}
