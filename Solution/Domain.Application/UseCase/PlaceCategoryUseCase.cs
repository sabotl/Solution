

using Solution.Domain.Entity;

namespace Solution.Application.UseCase
{
    public class PlaceCategoryUseCase
    {
        private readonly Domain.Service.IPlaceCategoryService service;

        public PlaceCategoryUseCase(Domain.Service.IPlaceCategoryService service) { this.service = service; }

        public async Task<IReadOnlyList<PlaceCategory>> GetAllAsync()
        {
            return await service.GetAllAsync();
        }
        public async Task<PlaceCategory> GetByIDAsync(Guid id)
        {
            return await service.GetByIDAsync(id);
        }

        public async Task DeleteAsync(Guid id)
        {
            await service.DeleteAsync(id);
        }
        public async Task CreateAsync(Domain.Entity.PlaceCategory Place)
        {
            await service.AddAsync(Place);
        }
        public async Task UpdateAsync(Domain.Entity.PlaceCategory Place)
        {
            await service.UpdateAsync(Place.Id, Place);
        }
    }
}
