
namespace Solution.Infrastructure.Repository
{
    public class PlaceRepository: BaseRepository<Domain.Entity.Place, Guid>, Domain.Repository.IPlaceRepository
    {
        public PlaceRepository(Data.AppDbContext appDbContext):base(appDbContext) 
        {
        
        }
    }
}
