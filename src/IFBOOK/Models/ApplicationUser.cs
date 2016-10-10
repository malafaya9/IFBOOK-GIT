﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace IFBOOK.Models
{
    //Aqui estão armazenadas as propriedades personalizadas do ApplicationUser(IdentityUser)
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }
        [Required]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "A Matrícula deverá possuir 14 digitos.")]
        public string Matricula { get; set; }



    }
}
