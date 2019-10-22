
using System;
using System.Collections.Generic;
using System.Linq;

namespace AceleraDev.Classes.Models
{
    public class Pessoa
    {
        public Pessoa()
        {
            Coisas = new List<int>();
        }
        public Pessoa(string nome, int idade) : this() // fazendo referência ao construtor básico
        {
            Nome = nome;
            Idade = idade;
        }
        
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime? Nascimento { get; set; }
        public double Peso { get; set; }
        public int Idade { get; set; }
        public bool Ativo { get; set; }
        public List<int> Coisas { get; set; }
        public int TotalCoisas { 
            get 
            { 
                return Coisas.Count(); 
            } 
        }

    }
}
