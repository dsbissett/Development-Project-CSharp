using Sparcpoint.Inventory.Abstractions;

namespace Sparcpoint.Service.Abstractions;

public abstract class BaseService<T> : IService<T> where T : class
{
    private readonly IRepository<T> repo;

    protected BaseService(IRepository<T> repo)
    {
        this.repo = repo;
    }

    public virtual async Task<T> GetAsync(int id) => await repo.GetAsync(id);

    public virtual async Task<IEnumerable<T>> GetAllAsync() => await repo.GetAllAsync();

    public virtual async Task<T> UpdateAsync(T entity) => await repo.UpdateAsync(entity);
}