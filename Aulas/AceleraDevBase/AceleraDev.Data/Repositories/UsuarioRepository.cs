﻿using AceleraDev.Data.Context;
using AceleraDev.Data.Repositories.Base;
using AceleraDev.Domain.Interfaces.Repositories;
using AceleraDev.Domain.Models;

namespace AceleraDev.Data.Repositories
{
    /// <summary>
    /// Classe Usuário Repository
    /// </summary>
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(AceleraDevContext context) : base(context)
        {

        }
    }
}
