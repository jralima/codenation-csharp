using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AceleraDev.Application.ViewModels
{
    public class TelefoneViewModel
    {
        public string DDI { get; set; }
        [Required]
        public string DDD { get; set; }
        [Required]
        public string Numero { get; set; }
        public string Contato { get; set; }
        public Guid ClienteId { get; set; }
        public ClienteViewModel Cliente { get; set; }
    }
}
