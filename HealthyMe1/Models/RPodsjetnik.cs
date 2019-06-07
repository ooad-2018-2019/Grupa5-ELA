using System;
using System.ComponentModel.DataAnnotations;
namespace HealthyMe1.Models
{
    public class RPodsjetnik
    {
        [ScaffoldColumn(false)]
        public int RPodsjetnikID { get; set; }
        [Required]
        public int PodsjetnikID { get; set; }

        public virtual Registrovani Registrovani { get; set; }
        public virtual Podsjetnik Podsjetnik { get; set; }
    }
}
