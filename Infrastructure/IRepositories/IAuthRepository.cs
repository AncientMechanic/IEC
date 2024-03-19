using Domain.Views;

namespace Infrastructure.IRepositories
{
    public interface IAuthRepository
    {
        Task<(string token, Guid userId)> CreateToken(AuthView view);
    }
}
