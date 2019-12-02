using AceleraDev.Application.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AceleraDev.Application.ViewModels
{
    public class UsuarioViewModel : ViewModelBase
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
        [Required]
        public string Perfil { get; set; }

        public string AccessToken { get; set; }
    }
}
