﻿using AceleraDev.Application.Interfaces;
using AceleraDev.Application.Services;
using AceleraDev.Data.Repositories;
using AceleraDev.Domain.Interfaces.Repositories;
using AceleraDev.Domain.Interfaces.Services;
using AceleraDev.Domain.Repositories;
using AceleraDev.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AceleraDevBase.CrossCutting.IoC
{
    public class RegisterIoC
    {
        public static void Register(IServiceCollection serviceCollection)
        {
            // AppServices
            serviceCollection.AddScoped<IClienteAppService, ClienteAppService>();
            serviceCollection.AddScoped<IProdutoAppService, ProdutoAppService>();
            serviceCollection.AddScoped<IPedidoAppService, PedidoAppService>();
            serviceCollection.AddScoped<IUsuarioAppService, UsuarioAppService>();

            // Services
            serviceCollection.AddScoped<IClienteService, ClienteService>();
            serviceCollection.AddScoped<IProdutoService, ProdutoService>();
            serviceCollection.AddScoped<IPedidoService, PedidoService>();
            serviceCollection.AddScoped<IUsuarioService, UsuarioService>();

            // Repositories
            serviceCollection.AddScoped<IClienteRepository, ClienteRepository>();
            serviceCollection.AddScoped<IProdutoRepository, ProdutoRepository>();
            serviceCollection.AddScoped<IPedidoRepository, PedidoRepository>();
            serviceCollection.AddScoped<IUsuarioRepository, UsuarioRepository>();
        }
    }
}
