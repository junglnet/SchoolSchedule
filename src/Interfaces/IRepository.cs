using SchoolSchedule.Entities;

namespace SchoolSchedule.Interfaces
{
    internal interface IRepository<TEntity, TFilter>
    {
        Task<IEnumerable<TEntity>> GetByQueryAsync(TFilter filter, CancellationToken token = default);

    }
}
