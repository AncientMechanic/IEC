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
                Name = entity.Name,
                PhoneNumber = entity.PhoneNumber,
                Photo = entity.Photo,
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
                Name = view.Name,
                PhoneNumber = view.PhoneNumber,
                Photo = view.Photo,
            };
        }
        public static User ConvertToEntity(this UpdateUserView view)
        {
            return new User()
            {
                Photo = view.Photo,
            };
        }
    }
}

