using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSchedule.Interfaces
{
    internal interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync(CancellationToken token = default);
        Task<T> GetByIdAsync(string id, CancellationToken token = default);
        Task<IEnumerable<T>> GetByIdsAsync(string[] ids, CancellationToken token = default);

        Task<bool> IsExistById(string id, CancellationToken token = default);

    }
}
