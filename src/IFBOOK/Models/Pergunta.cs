using System;
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
        [Column(TypeName = "datetime2")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataType(DataType.DateTime)]
        public DateTime Data { get; set; }
        [Required]
        public bool Status => !(Resposta==null);

        public string UsuarioID { get; set; }
        public ApplicationUser Usuario { get; set; }

        public int CursoID { get; set; }
        public Curso Curso { get; set; }
    }
}