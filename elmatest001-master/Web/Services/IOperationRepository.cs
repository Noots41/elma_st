using Web.Models;

namespace Web.Services
{
    /// <summary>
    /// Хранилище операций на базе общего хранилища
    /// </summary>
    public interface IOperationRepository : IEntityRepository<Operations>
    {
    }
}
