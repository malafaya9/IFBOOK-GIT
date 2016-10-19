using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IFBOOK.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="O campo não pode ser vazio")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo não pode ser vazio")]
        [StringLength(100, ErrorMessage = "A {0} deve ter no mínimo {2} e no máximo {1} caracteres de comprimento.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Senha")]
        [Compare("Password", ErrorMessage = "Os campos não possuem o mesmo valor.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "O campo não pode ser vazio")]
        [StringLength(14, ErrorMessage = "A {0} deve ter no mínimo {2} e no máximo {1} caracteres de comprimento.", MinimumLength = 14)]
        [DataType(DataType.Text)]
        [Display(Name = "Matrícula")]
        public string Matricula { get; set; }

        [Required(ErrorMessage = "O campo não pode ser vazio")]
        [StringLength(100, ErrorMessage = "A {0} deve ter no mínimo {2} e no máximo {1} caracteres de comprimento.", MinimumLength = 6)]
        [DataType(DataType.Text)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Display(Name = "Curso")]
        public int Curso { get; set; }
    }
}
