using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kolo.Models
{
    public class Team
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public float Score { get; set; }
    }
}
