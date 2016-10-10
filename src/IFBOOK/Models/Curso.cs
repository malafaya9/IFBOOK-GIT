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

        [Required]
        [MaxLength(30)]
        public string Nome { get; set; }

        //Alunos membros do curso
        public IEnumerable<ApplicationUser> Alunos { get; set; }

    }
}
