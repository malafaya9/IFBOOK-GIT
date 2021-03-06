﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IFBOOK.Models
{
    public class Avaliacao
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int Nota { get; set; }
        [Column(TypeName = "datetime2")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataType(DataType.DateTime)]
        public DateTime Data { get; set; }
        [Display(Name ="Usuário")]
        public string UsuarioID { get; set; }
        public ApplicationUser Usuario { get; set; }

        public int TipoAvaliacaoID { get; set; }
        public TipoAvaliacao TipoAvaliacao { get; set; }

        public int? DisciplinaID { get; set; }
        public Disciplina Disciplina { get; set; }

        public int? ProfessorID { get; set; }
        public Professor Professor { get; set; }
    }
}
