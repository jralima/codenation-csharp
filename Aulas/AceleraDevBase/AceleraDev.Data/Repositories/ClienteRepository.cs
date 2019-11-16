using AceleraDev.Domain.Models;
using AceleraDev.Data.Repositories.Base;
using System.Collections.Generic;
using AceleraDev.Domain.Repositories;
using AceleraDev.Data.Repositories.Context;
using System.Linq;
using Microsoft.Data.SqlClient;
using System;
using Dapper;

namespace AceleraDev.Data.Repositories
{
    /// <summary>
    /// Classe Cliente Repository
    /// </summary>
    public class ClienteRepository: RepositoryBase<Cliente>, IClienteRepository
    // IClienteRepository => não seria necessário pois a implementação já estaria no RepositoryBase
    // IClienteRepository => foi incluido pois definimos na interface um método que seria especifico desta classe
    {
        public ClienteRepository(AceleraDevContext context): base(context)
        {
            //base._mock = new List<Cliente>
            //{
            //    new Cliente
            //    {
            //        Nome = "Lacerda",
            //        Sobrenome = "Lima",
            //        Cpf = "084.045.687-58"
            //    }
            //};
        }

        public List<Cliente> BuscarTop10()
        {
            //return _context.Clientes.Take(10).ToList();
            // Executando a consulta com o Dapper

            //return base.GetWithDapper("select top 10 * from cliente");

            //using (var con = new SqlConnection(_context.GetConnectionString()))
            using var con = new SqlConnection(_context.GetConnectionString());
            try
            {
                var query = @"select * from cliente c 
                              join endereco e on c.id = e.ClienteId";
                object param = new object();

                con.Open();
                return con.Query<Cliente>(query, param).ToList();

                //return con.Query<Cliente, Endereco, Cliente>(query, 
                //    (cli, end) =>
                //    {
                //        cli.Enderecos = new List<Endereco> { end };
                //        return cli;
                //    }, splitOn:""
                //    ).ToList();
            }
            catch (Exception ex)
            {
                //throw ex;
                throw new Exception("Ocorreu um erro ao executar uma pesquisa com Dapper.", ex);
            }
            finally
            {
                con.Close();
            }

        }
    }
}
