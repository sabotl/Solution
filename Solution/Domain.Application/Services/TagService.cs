
using Solution.Domain.Entity;

namespace Solution.Application.Services
{
    public class TagService: BaseService<Tag, int>, Solution.Domain.Service.ITagService
    {
        private readonly Solution.Domain.Repository.ITagRepository _service;

        public TagService(Solution.Domain.Repository.ITagRepository service) : base(service)
        {

        }
    }
}
