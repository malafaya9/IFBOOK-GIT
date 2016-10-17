using System;
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
        [Required]
        [Column(TypeName = "datetime2")]
        [DataType(DataType.DateTime)]
        public DateTime Data { get; set; }

        public int UsuarioID { get; set; }
        public ApplicationUser Usuario { get; set; }
    }
}
