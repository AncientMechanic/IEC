using Domain.DTO;
using Infrastructure.Exceptions;
using Infrastructure.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Task = System.Threading.Tasks.Task;

namespace EF.Repositories
{
    public sealed class ListRepository : IListRepository
    {
        public readonly ProjectContext _context;
        public readonly DbSet<List> _dbSet;

        public ListRepository(ProjectContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<List>();
        }

        public async Task<Guid> CreateAsync(List entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<IQueryable<List>> GetAllAsync()
        {
            var models = await System.Threading.Tasks.Task.FromResult(_dbSet.AsNoTracking());

            return models;
        }

        public async Task<IQueryable<List>> GetAsync(Expression<Func<List, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<List> GetByIdAsync(Guid id)
        {
            var existEntity = await _dbSet.FindAsync(id);

            if (existEntity == null)
            {
                throw new NotFoundException($"'{typeof(List)}' with id '{id}' not found.");
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

        public async Task UpdateAsync(List entity)
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
