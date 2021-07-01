using System.Data;

namespace ControlaloPE.Domain.Repository{
    public interface IRepository{
        IDbConnection Conexion {get;}
    }
}