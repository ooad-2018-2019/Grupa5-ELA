using System;
using System.ComponentModel.DataAnnotations;

namespace HealthyMe1.Models
{
    public class Recenzija
    {
        [ScaffoldColumn(false)]
        public int ID { get; set; }
        [Required]
        public string Komentar { get; set; }
        [Required]
        public int Ocjena { get; set; }
        [Required]
        public int RegistrovaniID { get; set; }

        public virtual Registrovani Registrovani { get; set; }
    }
}
