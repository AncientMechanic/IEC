using Domain.DTO;
using Infrastructure.Exceptions;
using Infrastructure.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EF.Repositories
{
    public sealed class UserRepository : IUserRepository
    {
        public readonly ProjectContext _context;
        public readonly DbSet<User> _dbSet;

        public UserRepository(ProjectContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<User>();
        }

        public async Task<Guid> CreateAsync(User entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<IQueryable<User>> GetAllAsync()
        {
            var models = await Task.FromResult(_dbSet.AsNoTracking());

            return models;
        }

        public async Task<IQueryable<User>> GetAsync(Expression<Func<User, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            var existEntity = await _dbSet.FindAsync(id);

            if (existEntity == null)
            {
                throw new NotFoundException($"'{typeof(User)}' with id '{id}' not found.");
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

        public async Task UpdateAsync(User entity)
        {
            var existEntity = await _dbSet.FindAsync(entity.Id);

            if (existEntity == null)
            {
                throw new NotFoundException($"'{typeof(User)}' with id '{entity.Id}' not found.");
            }
            _context.Entry(existEntity).State = EntityState.Detached;

            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
