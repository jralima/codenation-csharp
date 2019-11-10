using AceleraDev.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AceleraDev.Domain.Models
{
    /// <summary>
    /// Classe de Pedido Item
    /// </summary>
    public class PedidoItem
    {
        public Guid PedidoId { get; set; }
        public Guid ProdutoId { get; set; }
        public virtual Pedido Pedido { get; set; }
        public virtual Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorItem { get; set; }
        public decimal ValorTotalItem
        {
            get
            {
                decimal valorRetorno = 0;
                if (Quantidade == 0)
                    return valorRetorno;

                valorRetorno = Quantidade * ValorItem;
                return valorRetorno;
            }
        }
    }
}
