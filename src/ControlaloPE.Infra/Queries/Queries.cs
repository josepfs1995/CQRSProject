using System.Data;
using ControlaloPE.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace ControlaloPE.Infra.Queries
{
    public class Queries{
        protected readonly ControlaloPEContext _context;
        public Queries(ControlaloPEContext context)
        {
            _context = context;
        }
        protected IDbConnection ObtenerConexion(){
            return _context.Database.GetDbConnection();
        }
    }
}