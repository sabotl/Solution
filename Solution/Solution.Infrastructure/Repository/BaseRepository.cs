using Microsoft.EntityFrameworkCore;

namespace Solution.Infrastructure.Repository
{
    public class BaseRepository<T, Tid> : Domain.Repository.IBaseRepository<T, Tid> where T : class
    {
        protected readonly Data.AppDbContext context;

        public BaseRepository(Data.AppDbContext appDbContext)
        {
            context = appDbContext;
        }
        public async Task AddAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Tid id)
        {
            var entity = await context.Set<T>().FindAsync(id);
            if (entity == null)
                throw new Exception("Entity is not found");
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIDAsync(Tid id)
        {
            var entity = await context.Set<T>().FindAsync(id);
            if (entity != null)
                return entity;
            return null;
        }

        public async Task UpdateAsync(Tid id, T entity)
        {
            var existingEntity = await GetByIDAsync(id);
            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"Entity with ID {id} not found.");
            }

            var entityType = context.Model.FindEntityType(typeof(T));
            var propertiesExceptKey = entityType.GetProperties().Where(p => !p.IsPrimaryKey() && !p.IsForeignKey());

            foreach (var property in propertiesExceptKey)
            {
                var propertyName = property.Name;
                var propertyValue = entityType.FindProperty(propertyName)?.GetGetter().GetClrValue(entity);
                if (propertyValue != null)
                {
                    context.Entry(existingEntity).Property(propertyName).CurrentValue = propertyValue;
                }
            }

            await context.SaveChangesAsync();
        }
    }
}
