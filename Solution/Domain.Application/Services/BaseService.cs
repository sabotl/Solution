using Solution.Domain.Service;

namespace Solution.Application.Services
{
    public abstract class BaseService<T, Tid> : Domain.Service.IBaseService<T, Tid> where T : class
    {
        protected readonly Solution.Domain.Repository.IBaseRepository<T, Tid> _repository;

        public BaseService(Domain.Repository.IBaseRepository<T, Tid> repository)
        {
            _repository = repository;
        }
        public async Task AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
        }

        public async Task DeleteAsync(Tid id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<T> GetByIDAsync(Tid id)
        {
            return await _repository.GetByIDAsync(id);
        }

        public async Task UpdateAsync(Tid id, T entity)
        {
            await _repository.UpdateAsync(id, entity);
        }

    }
}
