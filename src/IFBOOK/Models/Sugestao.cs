using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IFBOOK.Models
{
    public class Sugestao
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(500)]
        public string Nome { get; set; }
    }
}
