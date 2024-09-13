using Solution.Domain.Entity;

namespace Solution.Application.UseCase
{
    public class TagUseCase
    {
        private readonly Domain.Service.ITagService tagService;
        public TagUseCase(Domain.Service.ITagService tagService) 
        {
            this.tagService = tagService;
        }
        
        public async Task<IReadOnlyList<Tag>> GetAllAsync()
        {
            return await tagService.GetAllAsync();
        }
        public async Task<Tag> GetByIDAsync(int id)
        {
            return await tagService.GetByIDAsync(id);   
        }

        public async Task DeleteAsync(int id)
        {
            await tagService.DeleteAsync(id);
        }
        public async Task CreateAsync(Domain.Entity.Tag tag)
        {
            await tagService.AddAsync(tag);
        }
        public async Task UpdateAsync(Domain.Entity.Tag tag)
        {
            await tagService.UpdateAsync(tag.Id, tag);
        }
    }
}
