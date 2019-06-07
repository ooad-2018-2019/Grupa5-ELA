﻿using System;
using System.Collections.Generic;
using HealthyMe.Models.enums;
using System.ComponentModel.DataAnnotations;


namespace HealthyMe1.Models
{
    public class Registrovani
    {
        [ScaffoldColumn(false)]
        public int ID { get; set; }
        [Required]
        public Spol Spol { get; set; }
        [Required]
        public string Ime { get; set; }
        [Required]
        public DateTime DatumRodjenja { get; set; }
        [Required]
        public double Visina { get; set; }
        [Required]
        public double Tezina { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        public virtual ICollection<DnevniPlan> DnevniPlanovi { get; set; }
        public virtual ICollection<RPodsjetnik> RPodsjetnici { get; set; }
        public virtual ICollection<PITest> RezultatiTesta { get; set; }
        public virtual Test Test { get; set; }
        public virtual PlanIshrane PlanIshrane { get; set; }
        public virtual Recenzija Recenzija { get; set; }
    }
}
