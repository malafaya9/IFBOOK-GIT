using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IFBOOK.Models
{
    public class Professor
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(500)]
        public int Nome { get; set; }
        [Required]
        public float Nota { get; set; }
    }
}