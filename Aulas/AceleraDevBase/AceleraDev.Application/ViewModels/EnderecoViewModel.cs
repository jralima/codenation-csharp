﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AceleraDev.Application.ViewModels
{
    public class EnderecoViewModel
    {
        public string Cep { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public Guid ClienteId { get; set; }
        public ClienteViewModel Cliente { get; set; }
    }
}
