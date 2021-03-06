﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IFBOOK.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Usuário:")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Senha:")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Lembrar-me?")]
        public bool RememberMe { get; set; }
    }
}
