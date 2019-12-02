using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AceleraDev.Application.ViewModels.Autenticacao
{
    public class LoginViewModel
    {
        [Required]
        [MaxLength(150)]
        public string Login { get; set; }
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
    }
}
