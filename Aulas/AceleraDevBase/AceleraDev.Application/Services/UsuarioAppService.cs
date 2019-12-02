using System;
using System.Collections.Generic;
using AceleraDev.Application.Interfaces;
using AceleraDev.Application.ViewModels;
using AceleraDev.Application.ViewModels.Autenticacao;
using AceleraDev.CrossCutting.Helpers;
using AceleraDev.Domain.Interfaces.Services;
using AceleraDev.Domain.Models;
using AutoMapper;

namespace AceleraDev.Application.Services
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public UsuarioAppService(IUsuarioService usuarioService, IMapper mapper)
        {
            this._usuarioService = usuarioService;
            this._mapper = mapper;
        }

        public UsuarioViewModel Add(UsuarioViewModel obj)
        {
            var modelUsuario = _mapper.Map<Usuario>(obj);
            var usuario = _usuarioService.Add(modelUsuario);
            return _mapper.Map<UsuarioViewModel>(usuario);
        }

        public IList<UsuarioViewModel> Find(Func<Usuario, bool> predicate)
        {
            var modelUsuario = _usuarioService.Find(predicate);
            return _mapper.Map<IList<UsuarioViewModel>>(modelUsuario);
        }

        public IList<UsuarioViewModel> GetAll()
        {
            var modelUsuario = _usuarioService.GetAll();
            return _mapper.Map<IList<UsuarioViewModel>>(modelUsuario);
        }

        public UsuarioViewModel GetById(Guid id)
        {
            var modelUsuario = _usuarioService.GetById(id);
            return _mapper.Map<UsuarioViewModel>(modelUsuario);
        }

        public UsuarioViewModel Login(LoginViewModel obj)
        {
            //var modelUsuario = _mapper.Map<Usuario>(obj);
            //var usuario = _usuarioService.Login(modelUsuario);
            var usuario = _usuarioService.Login(new Usuario { Email = obj.Login, Senha = obj.Password });
            return _mapper.Map<UsuarioViewModel>(usuario);
        }

        public void Remove(Guid id)
        {
            _usuarioService.Remove(id);
        }

        public void Update(UsuarioViewModel obj)
        {
            var modelUsuario = _mapper.Map<Usuario>(obj);
            _usuarioService.Update(modelUsuario);
        }
    }
}
