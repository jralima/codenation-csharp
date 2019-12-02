using AceleraDev.Domain.Interfaces.Base;
using AceleraDev.Domain.Models;

namespace AceleraDev.Domain.Interfaces.Services
{
    /// <summary>
    /// Interface Usuário Repository
    /// </summary>
    public interface IUsuarioService : IServiceBase<Usuario>
    {
        Usuario Login(Usuario obj);
    }
}
