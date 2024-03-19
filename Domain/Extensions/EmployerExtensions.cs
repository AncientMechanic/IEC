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
                CompanyAddress = entity.CompanyAddress,
                Country = entity.Country,
                City = entity.City,
                Wage = entity.Wage,
                JobOfferStatus = entity.JobOfferStatus,
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
                Country = view.Country,
                City = view.City,
                CompanyAddress = view.CompanyAddress,
                Position = view.Position,
                Wage = view.Wage,
                JobOfferStatus = view.JobOfferStatus,
            };
        }
        public static DTO.Employer ConvertToEntity(this UpdateEmployerView view, Employer entity)
        {
            return new DTO.Employer()
            {
                ParticipantId = entity.ParticipantId,
                Id = entity.Id,
                CompanyName = view.CompanyName,
                ContactFirstName = view.ContactFirstName,
                ContactLastName = view.ContactLastName,
                ContactEmail = view.ContactEmail,
                ContactPhone = view.ContactPhone,
                Country = view.Country,
                City = view.City,
                CompanyAddress = view.CompanyAddress,
                Position = view.Position,
                Wage = view.Wage,
                JobOfferStatus = view.JobOfferStatus,
            };
        }
    }
}

