using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IFBOOK.Models
{
    public class Evento
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "O campo não pode ser vazio")]
        [StringLength(60, ErrorMessage = "O {0} deve ter no mínimo {2} e no máximo {1} caracteres de comprimento.", MinimumLength = 1)]
        [MaxLength(60)]
        public string Nome { get; set; }
        [Column(TypeName = "datetime2")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "O campo não pode ser vazio")]
        [DataType(DataType.DateTime)]
        public DateTime Data { get; set; }
        public Boolean Status { get; set; }
        [Display(Name = "Usuário")]
        public string UsuarioID { get; set; }
        public ApplicationUser Usuario { get; set; }
        public string GetStatus => (Status ? "Aprovado" : "Analisando");
    }
}
