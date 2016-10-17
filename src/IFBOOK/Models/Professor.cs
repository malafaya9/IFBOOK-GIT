using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IFBOOK.Models
{
    public class Professor
    {
        [Key]
        public int ID { get; set; }
        public IEnumerable<ProfessorDisciplina> ProfessorDisciplina { get; set; }
        [Required]
        [MaxLength(100)]
        public int Nome { get; set; }
        [Required]
        public float Nota { get; set; }
    }
}