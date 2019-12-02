using AceleraDev.Application.Interfaces;
using AceleraDev.Application.ViewModels;
using AceleraDev.CrossCutting.Constants;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AceleraDevBase.Api.Controllers.Base
{
    public class BaseController : ControllerBase
    {
        private readonly IUsuarioAppService usuarioAppService;

        public BaseController(IUsuarioAppService usuarioAppService)
        {
            this.usuarioAppService = usuarioAppService;
        }

        protected UsuarioViewModel UsuarioLogado()
        {
            ClaimsPrincipal currentUser = User;

            //var usuario = currentUser.Claims.Where(c => c.Type == "usuario").Select(c => c.Value).SingleOrDefault();
            //return JsonConvert.DeserializeObject<UsuarioViewModel>(usuario);
            var idUsuario = currentUser.Claims.Where(c => c.Type == "id").Select(c => c.Value).SingleOrDefault();
            return usuarioAppService.GetById(new Guid(idUsuario));
        }

        //protected bool UsuarioTemPerfilAdmin()
        //{
        //    ClaimsPrincipal currentUser = User;
        //    var perfil = currentUser.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).SingleOrDefault();

        //    return perfil == Constants.PERFIL_ADMIN;
        //}

        //protected bool UsuarioTemPerfilAdmin => UsuarioLogado().Perfil == Constants.PERFIL_ADMIN;
        protected bool UsuarioTemPerfilAdmin => GetRoleFromJWT() == Constants.PERFIL_ADMIN;
        protected bool UsuarioTemPerfilVendedor => GetRoleFromJWT() == Constants.PERFIL_VENDEDOR;

        protected string UsuarioId => GetUserIdFromJWT();

        private string GetUserIdFromJWT()
        {
            return User.Claims.Where(c => c.Type == "id").Select(c => c.Value).SingleOrDefault();
        }

        private string GetRoleFromJWT()
        {
            return User.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).SingleOrDefault();
        }
    }
}
