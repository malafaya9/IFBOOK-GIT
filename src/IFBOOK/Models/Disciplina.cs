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
        public ICollection<ProfessorDisciplina> ProfessorDisciplina { get; set; }
        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }
        [NotMapped]
        public float? Nota => Avaliacoes?.Any() ?? false ? (float)Avaliacoes.Average(a => a.Nota) : -1;
        public ICollection<Avaliacao> Avaliacoes { get; set; }
    }
}