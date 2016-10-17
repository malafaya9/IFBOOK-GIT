﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IFBOOK.Models
{
    public class Pergunta
    {
        [Key]
        public int ID { get; set; }
        public Resposta Resposta { get; set; }

        [Required]
        [MaxLength(500)]
        public string Descricao { get; set; }
        [Required]
        [Column(TypeName = "datetime2")]
        [DataType(DataType.DateTime)]
        public DateTime Data { get; set; }
        [Required]
        public Boolean Status { get; set; }

        public int UsuarioID { get; set; }
        public ApplicationUser Usuario { get; set; }

        public int CursoID { get; set; }
        public Curso Curso { get; set; }
    }
}