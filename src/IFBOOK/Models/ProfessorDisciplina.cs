using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IFBOOK.Models
{
    public class ProfessorDisciplina
    {
        public int ProfessorID { get; set; }
        public Professor Professor { get; set; }

        public int DisciplinaID { get; set; }
        public Disciplina Disciplina { get; set; }
    }
}
