using AceleraDev.CrossCutting.Utils;
using AceleraDev.Domain.Interfaces.Repositories;
using AceleraDev.Domain.Interfaces.Services;
using AceleraDev.Domain.Models;
using AceleraDev.Domain.Repositories.Base;
using System.Linq;

namespace AceleraDev.Domain.Services
{
    public class UsuarioService : ServiceBase<Usuario>, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
            : base(usuarioRepository)
        {
            this._usuarioRepository = usuarioRepository;
        }

        public Usuario Login(Usuario obj)
        {
            var usuario = _usuarioRepository.Find(p => p.Email == obj.Email && p.Senha == obj.Senha.ToHashMD5()).FirstOrDefault();

            if (usuario == default)
                return null;

            return usuario;

        }
    }
}
