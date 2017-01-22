using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Services
{
    /// <summary>
    /// Общее хранилище данных
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEntityRepository<T> where T:class
    {
        T Create();
        T Load(int Id);
        bool Delete(int Id);
        void Update(T operResult);
        IEnumerable<T> GetAll();
    }
}
