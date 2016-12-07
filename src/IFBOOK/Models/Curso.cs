using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IFBOOK.Models
{
    public class Curso
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "O campo não pode ser vazio")]
        [StringLength(60, ErrorMessage = "O {0} deve ter no mínimo {2} e no máximo {1} caracteres de comprimento.", MinimumLength = 1)]
        [MaxLength(60)]
        public string Nome { get; set; }

        //Alunos membros do curso
        public ICollection<ApplicationUser> Alunos { get; set; }

        public ICollection<Pergunta> Perguntas { get; set; }
    }
}
