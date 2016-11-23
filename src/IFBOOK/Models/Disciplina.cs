using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IFBOOK.Models
{
    public class Disciplina
    {
        [Key]
        public int ID { get; set; }
        public IEnumerable<ProfessorDisciplina> ProfessorDisciplina { get; set; }
        [Required]
        [MaxLength(100)]
        public int Nome { get; set; }
        [NotMapped]
        public float Nota => (float)Avaliacoes.Average(a => a.Nota);
        public IEnumerable<Avaliacao> Avaliacoes { get; set; }
    }
}