using System.Threading;
using System.Threading.Tasks;
using ControlaloPE.Domain.Commands.EmpresaCommands;
using ControlaloPE.Domain.Interfaces.Queries;
using ControlaloPE.Domain.Interfaces.Repository;
using ControlaloPE.Domain.Models;
using FluentValidation.Results;
using Mapster;
using MediatR;

namespace ControlaloPE.Infra.Commands{
    public class EmpresaCommandHandler : CommandHandler, IRequestHandler<CrearEmpresaCommand, ValidationResult>,
                                        IRequestHandler<EditarEmpresaCommand, ValidationResult>,
                                        IRequestHandler<EliminarEmpresaCommand, ValidationResult>
    {
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IEmpresaQueries _empresaQueries;
        public EmpresaCommandHandler(IEmpresaRepository empresaRepository, IEmpresaQueries empresaQueries)
        {
            _empresaRepository = empresaRepository;
            _empresaQueries = empresaQueries;
        }
        public async Task<ValidationResult> Handle(CrearEmpresaCommand request, CancellationToken cancellationToken)
        {
            if(!request.IsValid()) return request.ValidationResult;

            var empresa = request.Adapt<Empresa>();
            _empresaRepository.Crear(empresa);
            await _empresaRepository.UoW.GuardarCambios();

            return request.ValidationResult;
        }
        public async Task<ValidationResult> Handle(EditarEmpresaCommand request, CancellationToken cancellationToken)
        {
            if(!request.IsValid()) return request.ValidationResult;

            var empresa = await _empresaQueries.Obtener(request.Id_Empresa, request.Id_Persona);
            if(empresa == null) {
                request.ValidationResult.Errors.Add(new ValidationFailure(string.Empty, "La empresa no existe"));
                return request.ValidationResult;
            }

            empresa.Logo = string.IsNullOrEmpty(request.Logo) ? empresa.Logo : request.Logo;
            empresa.Nombre = request.Nombre;
            empresa.Ruc = request.Ruc;

            _empresaRepository.Editar(empresa); 
            await _empresaRepository.UoW.GuardarCambios();

            return request.ValidationResult;
        }

        public async Task<ValidationResult> Handle(EliminarEmpresaCommand request, CancellationToken cancellationToken)
        {
            if(!request.IsValid()) return request.ValidationResult;

            var empresa = await _empresaQueries.Obtener(request.Id_Empresa, request.Id_Persona);
            if(empresa == null) {
                request.ValidationResult.Errors.Add(new ValidationFailure(string.Empty, "La empresa no existe"));
                return request.ValidationResult;
            }

            _empresaRepository.Eliminar(empresa); 
            await _empresaRepository.UoW.GuardarCambios();

            return request.ValidationResult;
        }
    }
}