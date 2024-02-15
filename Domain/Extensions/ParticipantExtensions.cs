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
                Patronymic = entity.Patronymic,
                NameOfUniversity = entity.NameOfUniversity,
                Email = entity.Email,
                PhoneNumber = entity.PhoneNumber,

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
                NameOfUniversity = view.NameOfUniversity,
                Email = view.Email,
                PhoneNumber = view.PhoneNumber,
            };
        }
        public static Participant ConvertToEntity(this UpdateParticipantView view)
        {
            return new Participant()
            {
                UserId = view.UserId,
                Id = view.Id,
            };
        }
    }
}
