using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlaloPE.Domain.Interfaces{
    public interface IRead<T> where T : class{
        Task<T> Obtener(Guid id);
        Task<IEnumerable<T>> Listar();
    }
}