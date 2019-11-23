using System;

namespace AceleraDev.Application.ViewModels.Base
{
    /// <summary>
    /// Classe ViewModelBase
    /// </summary>
    public class ViewModelBase
    {
        public Guid Id { get; set; }
        public DateTime? CriadoEm { get; set; }
        public DateTime? AtualizadoEm { get; set; }
        public bool Ativo { get; set; }

        public ViewModelBase()
        {
            Id = Guid.NewGuid();
            // Atribuindo o valor as duas variáveis ao mesmo tempo
            CriadoEm = AtualizadoEm = DateTime.Now;
            Ativo = true;
        }

    }
}
