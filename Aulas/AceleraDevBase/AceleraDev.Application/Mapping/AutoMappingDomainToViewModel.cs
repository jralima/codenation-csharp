using AceleraDev.Application.ViewModels;
using AceleraDev.Domain.Models;
using AutoMapper;

namespace AceleraDev.Application.Mapping
{
    public class AutoMappingDomainToViewModel : Profile
    {
        public AutoMappingDomainToViewModel()
        {
            CreateMap<Cliente, ClienteViewModel>();
            CreateMap<Produto, ProdutoViewModel>();
            CreateMap<Pedido, PedidoViewModel>();
            CreateMap<Endereco, EnderecoViewModel>();
            CreateMap<Telefone, TelefoneViewModel>();
            //CreateMap<PedidoItem, PedidoItemViewModel>();
        }
    }
}