using System;
using System.ComponentModel.DataAnnotations;
namespace HealthyMe1.Models
{
    public class Administrator
    {
        [ScaffoldColumn(false)]
        public int ID { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string NivoPristupa { get; set; }
    }
}
