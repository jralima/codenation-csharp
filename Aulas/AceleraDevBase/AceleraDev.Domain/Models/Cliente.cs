using AceleraDev.CrossCutting.Exceptions;
using AceleraDev.Domain.Models.Base;
using System;
using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

namespace AceleraDev.Domain.Models
{
    /// <summary>
    /// Classe de cliente
    /// </summary>
    //[Table("cliente")]
    public class Cliente : ModelBase
    {
        //[MaxLength(11)]
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public List<Telefone> Telefones { get; set; }
        public List<Endereco> Enderecos { get; set; }

        public bool Valido()
        {
            if(string.IsNullOrWhiteSpace(Nome))
            {
                throw new ModelValidationException("O campo Nome é obrigatório");
            }

            return true;
        }

        public Cliente()
        {
            //Telefones = new List<string>();
            Enderecos = new List<Endereco>();
        }


    }
}
