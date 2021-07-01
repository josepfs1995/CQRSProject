namespace ControlaloPE.Domain.Interfaces{
    public interface IWrite<T> where T : class{
        public IUnitOfWork UoW { get; }
        void Crear(T model);
        void Editar(T model);
        void Eliminar(T model);
    }
}