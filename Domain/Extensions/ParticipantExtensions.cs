using Domain.DTO;
using Domain.Views.Participants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Extensions
{
    public static class ParticipantExtensions
    {
        public static ParticipantView ConvertToView(this Participant entity)
        {
            return new ParticipantView()
            {
                Id = entity.Id,
                UserId = entity.UserId,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                DateOfBirth = entity.DateOfBirth,
                Patronymic = entity.Patronymic,
                Season = entity.Season,
                Address = entity.Address,
                Passport = entity.Passport,
                NameOfUniversity = entity.NameOfUniversity,
                YearOfStudy = entity.YearOfStudy,
                Email = entity.Email,
                PhoneNumber = entity.PhoneNumber,
                Program = entity.Program,
                ServicePlan = entity.ServicePlan,
                HasEmployer = entity.HasEmployer,
                PrePayment = entity.PrePayment,
                PaymentComplete = entity.PaymentComplete,
                VisaApproved = entity.VisaApproved,
                DepartureDate = entity.DepartureDate,
                ReturnDate = entity.ReturnDate,

            };
        }
        public static Participant ConvertToEntity(this CreateParticipantView view)
        {
            return new Participant()
            {
                UserId = view.UserId,
                FirstName = view.FirstName,
                LastName = view.LastName,
                Patronymic = view.Patronymic,
                DateOfBirth = view.DateOfBirth,
                Season = view.Season,
                Address = view.Address,
                Passport = view.Passport,
                NameOfUniversity = view.NameOfUniversity,
                YearOfStudy = view.YearOfStudy,
                Email = view.Email,
                PhoneNumber = view.PhoneNumber,
                Program = view.Program,
               
            };
        }
        public static Participant ConvertToEntity(this UpdateParticipantView view, Participant entity)
        {
            return new Participant()
            {
                Id = entity.Id,
                UserId = entity.UserId,
                FirstName = view.FirstName,
                LastName = view.LastName,
                Patronymic = view.Patronymic,
                DateOfBirth = view.DateOfBirth,
                Season = view.Season,
                Address = view.Address,
                Passport = view.Passport,
                NameOfUniversity = view.NameOfUniversity,
                YearOfStudy = view.YearOfStudy,
                Email = view.Email,
                PhoneNumber = view.PhoneNumber,
                Program = view.Program,
                ServicePlan = view.ServicePlan,
                HasEmployer = view.HasEmployer,
                PrePayment = view.PrePayment,
                PaymentComplete = view.PaymentComplete,
                VisaApproved = view.VisaApproved,
                DepartureDate = view.DepartureDate,
                ReturnDate = view.ReturnDate,
            };
        }
    }
}
