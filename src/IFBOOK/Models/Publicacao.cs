﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IFBOOK.Models
{
    public class Publicacao
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(500)]
        public string Descricao { get; set; }
        [Column(TypeName = "datetime2")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime Data { get; set; }

        public string UsuarioID { get; set; }
        public ApplicationUser Usuario { get; set; }

        public ICollection<Comentario> Comentarios { get; set; }
    }
}
