using System;
using System.Collections.Generic;
using HealthyMe.Models.enums;
using System.ComponentModel.DataAnnotations;


namespace HealthyMe1.Models
{
    public class Podsjetnik
    {
        [ScaffoldColumn(false)]
        public int ID { get; set; }
        [Required]
        public string Opis { get; set; }
        [Required]
        public DateTime Period { get; set; }
        [Required]
        public Ponavljanje Ponavljanje { get; set; }

        public virtual ICollection<RPodsjetnik> RPodsjetnici { get; set; }
    }
}
