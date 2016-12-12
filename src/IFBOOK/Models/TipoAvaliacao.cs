using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IFBOOK.Models
{
    public class TipoAvaliacao
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(20)]
        public string Descricao { get; set; }

        public ICollection<Avaliacao> Avaliacoes { get; set; }
    }
}