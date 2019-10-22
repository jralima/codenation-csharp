using AceleraDev.CrossCutting.Exceptions;
using AceleraDev.Domain.Models;
using AceleraDev.Domain.Services;
using System;

namespace AceleraDev.ConsoleApp
{
    class Program
    {
        private static void TesteValidacaoCliente()
        {
            try
            {
                var cliente = new Cliente();
                cliente.Valido();
            }
            catch (ModelValidationException ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
            catch (Exception)
            {
                Console.WriteLine($"Erro desconhedico ;(");
            }

        }
        static void Main(string[] args)
        {
            var clienteService = new ClienteService();
            clienteService.Add(new Cliente { Nome = "Anastacio" });
            
            var data = clienteService.GetAll();

            // Console.WriteLine(string.Join("|", data));

            TesteValidacaoCliente();

            Console.ReadLine();
        }
    }
}
