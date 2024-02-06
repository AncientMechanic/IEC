using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IRepositories
{
    public interface ITaskRepository
    {
        Task<Domain.DTO.Task> GetByIdAsync(Guid id);
        Task<Guid> CreateAsync(Domain.DTO.Task entity);
        Task<IQueryable<Domain.DTO.Task>> GetAllAsync();
        System.Threading.Tasks.Task RemoveAsync(Guid id);
        System.Threading.Tasks.Task UpdateAsync(Domain.DTO.Task entity);
        Task<IQueryable<Domain.DTO.Task>> GetAsync(Expression<Func<Domain.DTO.Task, bool>> predicate);
    }
}
