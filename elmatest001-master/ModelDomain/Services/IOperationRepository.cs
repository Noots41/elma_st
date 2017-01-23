using Models;

namespace Services
{
    /// <summary>
    /// Хранилище операций на базе общего хранилища
    /// </summary>
    public interface IOperationRepository : IEntityRepository<Operations>
    {
    }
}
