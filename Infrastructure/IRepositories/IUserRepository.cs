using Domain.DTO;
using System.Linq.Expressions;

namespace Infrastructure.IRepositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(Guid id);
        Task<Guid> CreateAsync(User entity);
        Task<IQueryable<User>> GetAllAsync();
        Task RemoveAsync(Guid id);
        Task UpdateAsync(User entity);
        Task<IQueryable<User>> GetAsync(Expression<Func<User, bool>> predicate);
    }
}
