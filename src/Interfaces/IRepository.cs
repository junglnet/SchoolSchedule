using SchoolSchedule.Entities;

namespace SchoolSchedule.Interfaces
{
    internal interface IRepository<T>
    {
        Task<IEnumerable<T>> GetByQueryAsync(Query query, CancellationToken token = default);

    }
}
