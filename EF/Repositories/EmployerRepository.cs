using Domain.DTO;
using Infrastructure.Exceptions;
using Infrastructure.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Security.Claims;
using Task = System.Threading.Tasks.Task;

namespace EF.Repositories
{
    public sealed class EmployerRepository : IEmployerRepository
    {
        public readonly ProjectContext _context;
        public readonly DbSet<Employer> _dbSet;
        private readonly Guid _userId;

        public EmployerRepository(ProjectContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<Employer>();
            var email = httpContextAccessor.HttpContext.User.Claims.First(x => x.Type == ClaimTypes.Email).Value;
            _userId = context.Users.First(x => x.Email == email).Id;
        }

        public async Task<Guid> CreateAsync(Employer entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<IQueryable<Employer>> GetAllAsync()
        {
            var models = await System.Threading.Tasks.Task.FromResult(_dbSet.AsNoTracking());

            return models;
        }

        public async Task<IQueryable<Employer>> GetAsync(Expression<Func<Employer, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<Employer> GetByIdAsync(Guid id)
        {
            var existEntity = await _dbSet.FindAsync(id);

            if (existEntity == null)
            {
                throw new NotFoundException($"'{typeof(Employer)}' with id '{id}' not found.");
            }

            return existEntity;
        }

        public async Task<Employer> GetByParticipantIdAsync(Guid participantid)
        {
            var existEntity = await _dbSet.FirstOrDefaultAsync(e => e.ParticipantId == participantid);

            if (existEntity == null)
            {
                throw new NotFoundException($"'{typeof(Employer)}' with id '{participantid}' not found.");
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

        public async Task UpdateAsync(Employer entity, Guid id)
        {
            var existEntity = await _dbSet.FindAsync(id);

            if (existEntity == null)
            {
                throw new NotFoundException($"'{typeof(Employer)}' with id '{entity.Id}' not found.");
            }
            _context.Entry(existEntity).State = EntityState.Detached;

            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
