using Domain.DTO;
using Infrastructure.Exceptions;
using Infrastructure.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Task = System.Threading.Tasks.Task;

namespace EF.Repositories
{
    public sealed class TaskRepository : ITaskRepository
    {
        public readonly ProjectContext _context;
        public readonly DbSet<Domain.DTO.Task> _dbSet;

        public TaskRepository(ProjectContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<Domain.DTO.Task>();
        }

        public async Task<Guid> CreateAsync(Domain.DTO.Task entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<IQueryable<Domain.DTO.Task>> GetAllAsync()
        {
            var models = await System.Threading.Tasks.Task.FromResult(_dbSet.AsNoTracking());

            return models;
        }

        public async Task<IQueryable<Domain.DTO.Task>> GetAsync(Expression<Func<Domain.DTO.Task, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<Domain.DTO.Task> GetByIdAsync(Guid id)
        {
            var existEntity = await _dbSet.FindAsync(id);

            if (existEntity == null)
            {
                throw new NotFoundException($"'{typeof(Domain.DTO.Task)}' with id '{id}' not found.");
            }

            return existEntity;
        }

        public async Task RemoveAsync(Guid id)
        {
            var existEntity = await _dbSet.FindAsync(id);

            if (existEntity == null)
            {
                return;
            }

            _dbSet.Remove(existEntity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Domain.DTO.Task entity)
        {
            var existEntity = await _dbSet.FindAsync(entity.Id);

            if (existEntity == null)
            {
                throw new NotFoundException($"'{typeof(Domain.DTO.Task)}' with id '{entity.Id}' not found.");
            }
            _context.Entry(existEntity).State = EntityState.Detached;

            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
