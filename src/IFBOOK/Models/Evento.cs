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
        [Required]
        [MaxLength(60)]
        public string Nome { get; set; }
        [Column(TypeName = "datetime2")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataType(DataType.DateTime)]
        public DateTime Data { get; set; }
        [Required]
        public Boolean Status { get; set; }

        public string UsuarioID { get; set; }
        public ApplicationUser Usuario { get; set; }
    }
}
