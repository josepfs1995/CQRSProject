using FluentValidation.Results;
using MediatR;
namespace ControlaloPE.Domain.Commands{
    public abstract class Command:IRequest<ValidationResult>{
        public abstract bool IsValid();
        public ValidationResult ValidationResult { get; set; }
    }
}