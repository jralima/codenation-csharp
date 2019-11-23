using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AceleraDev.Application.ViewModels.Base;
using AceleraDev.CrossCutting.Validators;

namespace AceleraDev.Application.ViewModels
{
    /// <summary>
    /// Classe de Cliente View Model
    /// </summary>
    public class ClienteViewModel : ViewModelBase
    {
        [Required(ErrorMessage ="Campo com preenchimento obrigatório.")]
        [CPF]
        [MaxLength(11)]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Campo com preenchimento obrigatório.")]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo com preenchimento obrigatório.")]
        [MaxLength(100)]
        public string Sobrenome { get; set; }

        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DataNascimento { get; set; }

        //[RegularExpression(@"^[a-z0-9][-a-z0-9._]+@([-a-z0-9]+.)+[a-z]{2,5}$", ErrorMessage = "Email inválido.")]
        //public string Email { get; set; }

        public List<TelefoneViewModel> Telefones { get; set; }
        public List<EnderecoViewModel> Enderecos { get; set; }
    }
}