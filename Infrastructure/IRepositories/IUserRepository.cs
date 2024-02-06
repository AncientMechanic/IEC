using Domain.DTO;
using System.Linq.Expressions;

namespace Infrastructure.IRepositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(Guid id);
        Task<Guid> CreateAsync(User entity);
        Task<IQueryable<User>> GetAllAsync();
        System.Threading.Tasks.Task RemoveAsync(Guid id);
        System.Threading.Tasks.Task UpdateAsync(User entity);
        Task<IQueryable<User>> GetAsync(Expression<Func<User, bool>> predicate);
    }
}
