using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kolo.Models
{
    public class Player
    {
        [Required]
        public String FirstName { get; set; }
        [Required]
        public String LastName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public int NumOnShirt { get; set; }
        public String Comment { get; set; }
    }
}
