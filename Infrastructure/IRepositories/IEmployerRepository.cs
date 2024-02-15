using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IRepositories
{
    public interface IEmployerRepository
    {
        Task<Domain.DTO.Employer> GetByIdAsync(Guid id);
        Task<Guid> CreateAsync(Domain.DTO.Employer entity);
        Task<IQueryable<Domain.DTO.Employer>> GetAllAsync();
        System.Threading.Tasks.Task RemoveAsync(Guid id);
        System.Threading.Tasks.Task UpdateAsync(Domain.DTO.Employer entity);
        Task<IQueryable<Domain.DTO.Employer>> GetAsync(Expression<Func<Domain.DTO.Employer, bool>> predicate);
    }
}
