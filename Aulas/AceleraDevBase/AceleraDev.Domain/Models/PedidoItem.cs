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
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorTotalItem
        {
            get
            {
                decimal valorRetorno = 0;
                if(Quantidade > 0) 
                { 
                    valorRetorno = Quantidade * Produto.Valor; 
                }
                return valorRetorno;
            }
        }
    }
}
