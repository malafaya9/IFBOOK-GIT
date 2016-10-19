﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IFBOOK.Models
{
    public class Resposta
    {
        [Key]
        public int PerguntaID { get; set; }
        public Pergunta Pergunta { get; set; }

        [Required]
        [MaxLength(500)]
        public string Descricao { get; set; }
        [Column(TypeName = "datetime2")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataType(DataType.DateTime)]
        public DateTime Data { get; set; }

        public string UsuarioID { get; set; }
        public ApplicationUser Usuario { get; set; }
    }
}
