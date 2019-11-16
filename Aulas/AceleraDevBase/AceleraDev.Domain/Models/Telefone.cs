using AceleraDev.Domain.Models.Base;
using System;

namespace AceleraDev.Domain.Models
{
    /// <summary>
    /// Classe de telefone
    /// </summary>
    public class Telefone : ModelBase
    {
        public string DDI { get; set; }
        public string DDD { get; set; }
        public string Numero { get; set; }
        public string Contato { get; set; }
        public Guid ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
