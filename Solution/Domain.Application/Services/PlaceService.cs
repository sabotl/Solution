using Solution.Domain.Entity;
using Solution.Domain.Service;

namespace Solution.Application.Services
{
    public class PlaceService: BaseService<Place, Guid>, IPlaceService
    {
        private readonly Solution.Domain.Repository.IPlaceRepository _service;

        public PlaceService(Solution.Domain.Repository.IPlaceRepository placeRepository): base(placeRepository) 
        { 
        
        }
    }
}
