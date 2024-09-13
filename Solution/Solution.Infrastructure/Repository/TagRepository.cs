using Solution.Domain.Entity;
using Solution.Domain.Repository;


namespace Solution.Infrastructure.Repository
{
    public class TagRepository: BaseRepository<Tag, int>, ITagRepository
    {
        public TagRepository(Data.AppDbContext _context) : base(_context) { }
    }
}
