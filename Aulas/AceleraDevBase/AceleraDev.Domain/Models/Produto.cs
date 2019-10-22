using AceleraDev.Domain.Models.Base;

namespace AceleraDev.Domain.Models
{
    /// <summary>
    /// Classe de produto
    /// </summary>
    public class Produto: ModelBase
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
    }
}
