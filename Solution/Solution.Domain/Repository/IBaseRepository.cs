namespace Solution.Domain.Repository
{
    public interface IBaseRepository<T, Tid> where T : class
    {
        Task<T> GetByIDAsync(Tid id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(Tid id, T entity);
        Task DeleteAsync(Tid id);
    }
}
