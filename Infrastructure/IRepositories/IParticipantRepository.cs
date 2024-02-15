using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IRepositories
{
    public interface IParticipantRepository
    {

        Task<Participant> GetByIdAsync(Guid id);
        Task<Guid> CreateAsync(Participant entity);
        Task<IQueryable<Participant>> GetAllAsync();
        System.Threading.Tasks.Task RemoveAsync(Guid id);
        System.Threading.Tasks.Task UpdateAsync(Participant entity);
        Task<IQueryable<Participant>> GetAsync(Expression<Func<Participant, bool>> predicate);

    }
}
