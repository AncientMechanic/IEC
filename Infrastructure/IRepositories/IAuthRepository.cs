using Domain.Views;

namespace Infrastructure.IRepositories
{
    public interface IAuthRepository
    {
        Task<string> CreateToken(AuthView view);
    }
}
