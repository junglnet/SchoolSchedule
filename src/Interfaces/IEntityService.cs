using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSchedule.Interfaces
{
    internal interface IEntityService<TEntity>
    {
        Task<TEntity> GetOneAsync(string id, CancellationToken token = new CancellationToken());
        Task<IEnumerable<TEntity>> GetManyAsync(string[] ids, CancellationToken token = default);
        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken token = default);
    }
}
