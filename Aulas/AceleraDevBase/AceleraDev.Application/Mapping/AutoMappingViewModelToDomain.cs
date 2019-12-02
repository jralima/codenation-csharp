using AceleraDev.Application.ViewModels;
using AceleraDev.Application.ViewModels.Autenticacao;
using AceleraDev.Domain.Models;
using AutoMapper;

namespace AceleraDev.Application.Mapping
{
    public class AutoMappingViewModelToDomain : Profile
    {
        public AutoMappingViewModelToDomain()
        {
            CreateMap<ClienteViewModel, Cliente>();
            CreateMap<ProdutoViewModel, Produto>();
            CreateMap<PedidoViewModel, Pedido>();
            CreateMap<EnderecoViewModel, Endereco>();
            CreateMap<TelefoneViewModel, Telefone>();
            CreateMap<UsuarioViewModel, Usuario>();
            CreateMap<LoginViewModel, Usuario>();
        }
    }
}