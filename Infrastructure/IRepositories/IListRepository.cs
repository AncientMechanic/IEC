using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IRepositories
{
    public interface IListRepository
    {

        Task<List> GetByIdAsync(Guid id);
        Task<Guid> CreateAsync(List entity);
        Task<IQueryable<List>> GetAllAsync();
        System.Threading.Tasks.Task RemoveAsync(Guid id);
        System.Threading.Tasks.Task UpdateAsync(List entity);
        Task<IQueryable<List>> GetAsync(Expression<Func<List, bool>> predicate);

    }
}
