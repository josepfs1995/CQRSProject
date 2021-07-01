using System.Threading;
using System.Threading.Tasks;
using ControlaloPE.Domain.Commands.PersonaCommands;
using ControlaloPE.Domain.Interfaces.Repository;
using ControlaloPE.Domain.Models;
using FluentValidation.Results;
using Mapster;
using MediatR;

namespace ControlaloPE.Infra.Commands{
    public class PersonaCommandHandler : CommandHandler, IRequestHandler<CrearPersonaCommand, ValidationResult>
    {
        private readonly IPersonaRepository _personaRepository;
        public PersonaCommandHandler(IPersonaRepository personaRepository)
        {
            _personaRepository = personaRepository;
        }
        public async Task<ValidationResult> Handle(CrearPersonaCommand request, CancellationToken cancellationToken)
        {
            if(!request.IsValid()) return request.ValidationResult;

            var persona = request.Adapt<Persona>();
            _personaRepository.Crear(persona);
            await _personaRepository.UoW.GuardarCambios();

            return request.ValidationResult;
        }
    }
}