using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoInject.Interfaces;
using ControlaloPE.Application.Interfaces;
using ControlaloPE.Application.ViewModels;
using ControlaloPE.BuildingBlocks.Core;
using ControlaloPE.Domain.Commands.EmpresaCommands;
using ControlaloPE.Domain.Interfaces.Queries;
using FluentValidation.Results;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace ControlaloPE.Application.Services
{
    public class EmpresaAppService:IEmpresaAppService,IAutoDI{
        private readonly IEmpresaQueries _empresaQueries;
        private readonly IMediator _mediator;
        private readonly IUserManager _userManager;
        private readonly IHostingEnvironment _host;
        public EmpresaAppService(IEmpresaQueries empresaQueries, IMediator mediator, IUserManager userManager, IHostingEnvironment host)
        {
            _empresaQueries = empresaQueries;
            _mediator = mediator;
            _userManager = userManager;
            _host = host;
        }
        public async Task<ValidationResult> Crear(CrearEmpresaViewModel model)
        {
            var empresaCommand = new CrearEmpresaCommand(_userManager.Id, model.Nombre, model.Ruc);
            empresaCommand.AgregarLogo(await GuardarArchivo(empresaCommand.Id_Empresa, model.LogoFile));
            var response = await _mediator.Send(empresaCommand);
            return response;
        }

        public  async Task<ValidationResult> Editar(EditarEmpresaViewModel model)
        {
            var empresaCommand = new EditarEmpresaCommand(model.Id_Empresa, _userManager.Id, model.Nombre, model.Ruc);
            empresaCommand.AgregarLogo(await GuardarArchivo(empresaCommand.Id_Empresa, model.LogoFile));
            var response = await _mediator.Send(empresaCommand);
            return response;
        }
        public  async Task<ValidationResult> Eliminar(Guid id)
        {
            var empresaCommand = new EliminarEmpresaCommand(id, _userManager.Id);
            var response = await _mediator.Send(empresaCommand);
            return response;
        }
        public async Task<IEnumerable<EmpresaViewModel>> Obtener()
        {
            var response = await _empresaQueries.ObtenerPorPersona(_userManager.Id);
            return response.Adapt<IEnumerable<EmpresaViewModel>>();
        }
        public async Task<EditarEmpresaViewModel> Obtener(Guid id)
        {
            var response = await _empresaQueries.Obtener(id, _userManager.Id);
            return response.Adapt<EditarEmpresaViewModel>();
        }
        private async Task<string> GuardarArchivo(Guid carpeta, IFormFile archivo){
            if(archivo == null) return string.Empty;
            var extension = Path.GetExtension(archivo.FileName);
            var path = Path.Combine(_host.WebRootPath, "Empresas", carpeta.ToString());
            if(!Directory.Exists(path)) Directory.CreateDirectory(path);
            var nombreArchivo = $"{Guid.NewGuid()}{extension}";
            using(var stream = new MemoryStream()){
                await archivo.CopyToAsync(stream);
                await File.WriteAllBytesAsync($"{path}/{nombreArchivo}", stream.GetBuffer());
            }
            return nombreArchivo;
        }
    }
}