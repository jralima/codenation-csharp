using System;

namespace AceleraDev.Domain.Models.Base
{
    /// <summary>
    /// Classe Base
    /// </summary>
    public class ModelBase
    {
        public Guid Id { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }
        public bool Ativo { get; set; }

        public ModelBase()
        {
            Id = Guid.NewGuid();
            // Atribuindo o valor as duas variáveis ao mesmo tempo
            CriadoEm = AtualizadoEm = DateTime.Now;
            Ativo = true;
        }
    }
}
