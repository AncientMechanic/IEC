using Domain.DTO;
using Domain.Views.Employers;
namespace Domain.Extensions
{
    public static class EmployerExtensions
    {
        public static EmployerView ConvertToView (this DTO.Employer entity)
        {
            return new EmployerView()
            {
                Id = entity.Id,
                ParticipantId = entity.ParticipantId,
                CompanyName = entity.CompanyName,
                ContactFirstName = entity.ContactFirstName,
                ContactLastName = entity.ContactLastName,
                ContactEmail = entity.ContactEmail,
                ContactPhone = entity.ContactPhone,
                Position = entity.Position,
            };
        }
        public static DTO.Employer ConvertToEntity (this CreateEmployerView view)
        {
            return new DTO.Employer()
            {
                ParticipantId = view.ParticipantId,
                CompanyName = view.CompanyName,
                ContactFirstName = view.ContactFirstName,
                ContactLastName = view.ContactLastName,
                ContactEmail = view.ContactEmail,
                ContactPhone = view.ContactPhone,
                Position = view.Position,
            };
        }
        public static DTO.Employer ConvertToEntity(this UpdateEmployerView view)
        {
            return new DTO.Employer()
            {
                ParticipantId = view.ParticipantId,
                Id = view.Id,
            };
        }
    }
}

