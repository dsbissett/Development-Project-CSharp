namespace Sparcpoint.Service.Abstractions;

public interface IService<T> where T : class
{
    Task<T> GetAsync(int id);

    Task<IEnumerable<T>> GetAllAsync();

    Task<T> UpdateAsync(T entity);
}