using Solution.Domain.Entity;
using Solution.Domain.Service;

namespace Solution.Application.Services
{
    public class PlaceCategoryService: BaseService<PlaceCategory, Guid>, IPlaceCategoryService
    {
        private readonly Domain.Repository.IPlaceCategoryRepository repository;

        public PlaceCategoryService(Domain.Repository.IPlaceCategoryRepository repository) : base(repository)
        {

        }
    }
}
