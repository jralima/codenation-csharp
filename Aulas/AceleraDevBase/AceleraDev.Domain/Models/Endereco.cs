﻿using AceleraDev.Domain.Models.Base;
using System;

namespace AceleraDev.Domain.Models
{
    /// <summary>
    /// Classe de endereço do cliente
    /// </summary>
    public class Endereco : ModelBase
    {
        public string Cep { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public Guid ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}