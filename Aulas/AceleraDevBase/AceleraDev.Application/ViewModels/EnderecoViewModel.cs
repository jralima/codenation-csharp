using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AceleraDev.Application.ViewModels
{
    public class EnderecoViewModel
    {
        [Required]
        public string Cep { get; set; }
        [Required]
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        [Required]
        public string Cidade { get; set; }
        [Required]
        public string Estado { get; set; }
        public Guid ClienteId { get; set; }
        public ClienteViewModel Cliente { get; set; }
    }
}
