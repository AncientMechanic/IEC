using Domain.DTO;
using Infrastructure.Exceptions;
using Infrastructure.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Security.Claims;

namespace EF.Repositories
{
    public sealed class ParticipantRepository : IParticipantRepository
    {
        public readonly ProjectContext _context;
        public readonly DbSet<Participant> _dbSet;
        private readonly Guid _userId;

        public ParticipantRepository(ProjectContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<Participant>();
            var email = httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == ClaimTypes.Email).Value;
            _userId = context.Users.First(x => x.Email == email).Id;
        }

        public async Task<Guid> CreateAsync(Participant entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<IQueryable<Participant>> GetAllAsync()
        {
            var models = await System.Threading.Tasks.Task.FromResult(_dbSet.AsNoTracking());

            return models;
        }

        public async Task<IQueryable<Participant>> GetAsync(Expression<Func<Participant, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<Participant> GetByIdAsync(Guid id)
        {
            var existEntity = await _dbSet.FindAsync(id);

            if (existEntity == null)
            {
                throw new NotFoundException($"'{typeof(Participant)}' with id '{id}' not found.");
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

        public async Task UpdateAsync(Participant entity, Guid id)
        {
            var existEntity = await _dbSet.FindAsync(id);

            if (existEntity == null)
            {
                throw new NotFoundException($"'{typeof(Participant)}' with id '{id}' not found.");
            }
            _context.Entry(existEntity).State = EntityState.Detached;

            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
