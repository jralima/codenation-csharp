using AceleraDev.Classes.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AceleraDev.ConsoleApp
{
    class Program
    {
        static void TextoSwitch(int num)
        {
            switch (num)
            {
                case 1:
                    {
                        Console.WriteLine("Case: " + num.ToString());
                        break;
                    }
                default:
                    break;
            }
        }

        static void InicializarPrograma( Dictionary<int, Pessoa> dcPes)
        {
            var pessoa1 = new Pessoa();
            pessoa1.Nome = "Teste";
            var pessoa2 = new Pessoa
            {
                Nome = "Lacerda"
            };

            dcPes.Add(1, pessoa1);
            dcPes.Add(2, pessoa2);
        }

        static void ExecutarLoopForeach(Dictionary<int, Pessoa> dcPes)
        {
            foreach (var item in dcPes.Keys)
            {
                Console.WriteLine(dcPes[item].Nome);
            }

            Console.WriteLine("*************************");
        }

        static void ExecutarLoopFor(Dictionary<int, Pessoa> dcPes)
        {
            for (int i = 1; i <= dcPes.Values.Count; i++)
            {
                Console.WriteLine(dcPes[i].Nome);
            }
            Console.WriteLine("*************************");
        }

        static void ExecutarLoopWhile(Dictionary<int, Pessoa> dcPes)
        {
            var num = 0;
            while (num < 10)
            {
                Console.WriteLine(num.ToString());
                TextoSwitch(num);
                num++;
            }
            Console.WriteLine("*************************");
        }

        static void ExecutarPrograma()
        {
            var dcPessoas = new Dictionary<int, Pessoa>();
            InicializarPrograma(dcPessoas);

            ExecutarLoopForeach(dcPessoas);
            ExecutarLoopFor(dcPessoas);
            ExecutarLoopWhile(dcPessoas);

            MetodoDois();

            Console.WriteLine("Informe um nome:");
            var nome = Console.ReadLine();
            Console.WriteLine($"Nome informado: {nome}");

            Console.ReadKey();
        }

        static void ImprimirLista(IEnumerable<Pessoa> lista, string titulo)
        {
            foreach (var item in lista)
            {
                Console.WriteLine(titulo);
                Console.WriteLine("Nome:" + item.Nome);
            }
            Console.WriteLine("*************************");
        }

        static void Main(string[] args)
        {
            ExecutarPrograma();
            MetodoUm("teste metodoum");

        }
    
        static string MetodoUm(string nome)
        {
            var retorno = string.Empty;

            if (!string.IsNullOrEmpty(nome))
            {
                retorno = nome;
            }
            return retorno;
        }

        static void MetodoDois()
        {
            var pessoas = new List<Pessoa>
            {
                new Pessoa("Lacerda 2", 17),
                new Pessoa("Lacerda 3", 25),
                new Pessoa("Lacerda 4", 30)
            };

            var pessoasMaioresdeIdadeSelect = pessoas.Where(pessoa => pessoa.Idade >= 18).Select(p => new { p.Nome, p.Idade });
            Console.WriteLine("*************************");
            Console.WriteLine("Pessoas maiores de idade (Select):" + pessoasMaioresdeIdadeSelect.ToString());
            Console.WriteLine("*************************");
            var pessoasMaioresdeIdade = pessoas.Where(pessoa => pessoa.Idade >= 18);
            ImprimirLista(pessoasMaioresdeIdade, "Pessoas maiores de idade (Where):");

            var menorIdade = pessoasMaioresdeIdade.Min(p => p.Idade);
            Console.WriteLine("Pessoas menores de idade (Min):" + menorIdade.ToString());

            Console.WriteLine("*************************");
            var maiorIdade = pessoasMaioresdeIdade.Max(p => p.Idade);
            Console.WriteLine("Pessoas maiores de idade (Max):" + maiorIdade.ToString());

            var pessoaMenorIdade = pessoas.FirstOrDefault(p => p.Idade == pessoas.Min(p => p.Idade));

        }
    }
}
