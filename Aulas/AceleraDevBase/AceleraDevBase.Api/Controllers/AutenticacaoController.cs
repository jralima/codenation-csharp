using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AceleraDev.Application.Interfaces;
using AceleraDev.Application.ViewModels;
using AceleraDev.Application.ViewModels.Autenticacao;
using AceleraDev.CrossCutting.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AceleraDevBase.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AutenticacaoController : ControllerBase
    {
        private readonly IUsuarioAppService _usuarioAppService;
        private readonly AppSettings _appSettings;

        public AutenticacaoController(IUsuarioAppService usuarioAppService, IOptions<AppSettings> appSettings)
        {
            this._usuarioAppService = usuarioAppService;
            this._appSettings = appSettings.Value;
        }

        [HttpPost()]
        public ActionResult Login([FromBody()] LoginViewModel usuario)
        {
            try
            {
                //var user = _usuarioAppService.Find(p => p.Email == usuario.Login && p.Senha == usuario.Senha.ToHashMD5()).FirstOrDefault();

                var usuarioLocal = _usuarioAppService.Login(usuario);

                if (usuarioLocal == default)
                    return BadRequest("Usuário ou senha não conferem");

                if(!usuarioLocal.Ativo)
                    return BadRequest("Usuário inativo.");

                usuarioLocal.AccessToken = GerarJWT(usuarioLocal);
                usuarioLocal.Senha = null;

                if (usuarioLocal.AccessToken != string.Empty)
                    return Ok(usuarioLocal);

                //return StatusCode((int)HttpStatusCode.OK);

                return new UnauthorizedResult();
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Message = $"Ocorreu um erro ao efetuar login do usuário: {usuario.Login}." +
                    $"\nErro: {ex.Message}"
                });
            }
        }

        private string GerarJWT(UsuarioViewModel usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.SecretKeyJWT);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.Nome),
                    new Claim(ClaimTypes.Email, usuario.Email),
                    new Claim(ClaimTypes.Role, usuario.Perfil),
                    new Claim("id", usuario.Id.ToString()),
                }),

                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}