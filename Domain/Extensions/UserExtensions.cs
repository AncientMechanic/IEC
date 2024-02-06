using Domain.DTO;
using Domain.Views.Users;
namespace Domain.Extensions
{
    public static class UserExtensions
    {
        public static UserView ConvertToView(this User entity)
        {
            return new UserView()
            {
                Id = entity.Id,
                Email = entity.Email,
                CreatedOn = entity.CreatedOn,
                ModifiedOn = entity.ModifiedOn
            };
        }
        public static User ConvertToEntity(this CreateUserView view)
        {
            return new User()
            {
                Email = view.Email,
                Password = view.Password,
            };
        }
        public static User ConvertToEntity(this UpdateUserView view)
        {
            return new User()
            {
            };
        }
    }
}

