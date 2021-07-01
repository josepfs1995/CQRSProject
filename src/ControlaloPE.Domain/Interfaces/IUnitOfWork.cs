using System.Threading.Tasks;

namespace ControlaloPE.Domain.Interfaces{
    public interface IUnitOfWork{
        Task<bool> GuardarCambios();
    }
}