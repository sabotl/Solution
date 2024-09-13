using Solution.Application.Services;
using Solution.Domain.Entity;

namespace Solution.Application.UseCase
{
    public class PlaceUseCase
    {
        private readonly Domain.Service.IPlaceService service;

        public PlaceUseCase(Domain.Service.IPlaceService service)
        {
            this.service = service;
        }
        public async Task<IReadOnlyList<Place>> GetAllAsync()
        {
            return await service.GetAllAsync();
        }
        public async Task<Place> GetByIDAsync(Guid id)
        {
            return await service.GetByIDAsync(id);
        }

        public async Task DeleteAsync(Guid id)
        {
            await service.DeleteAsync(id);
        }
        public async Task CreateAsync(Domain.Entity.Place Place)
        {
            await service.AddAsync(Place);
        }
        public async Task UpdateAsync(Domain.Entity.Place Place)
        {
            await service.UpdateAsync(Place.Id, Place);
        }
    }
}
