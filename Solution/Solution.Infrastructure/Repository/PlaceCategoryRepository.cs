using Solution.Domain.Entity;
using Solution.Domain.Repository;


namespace Solution.Infrastructure.Repository
{
    public class PlaceCategoryRepository: BaseRepository<PlaceCategory, Guid>, IPlaceCategoryRepository
    {
        public PlaceCategoryRepository(Data.AppDbContext appDbContext):base(appDbContext) { }
    }
}
