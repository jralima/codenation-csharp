using System;
using System.Collections.Generic;
using AceleraDev.Application.ViewModels.Base;

namespace AceleraDev.Application.ViewModels
{
    /// <summary>
    /// Classe de Cliente View Model
    /// </summary>
    public class ClienteViewModel : ViewModelBase
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public List<string> Telefones { get; set; }
    }
}