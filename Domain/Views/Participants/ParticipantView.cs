using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Views.Participants
{
    public class ParticipantView
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Patronymic { get; set; } = null!;
        public int Season { get; set; }
        public string Address { get; set; } = null!;
        public string Passport { get; set; } = null!;
        public string NameOfUniversity { get; set; } = null!;
        public int YearOfStudy { get; set; }
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public bool HasEmployer { get; set; }
        public string ServicePlan { get; set; } = null!;
        public string Program { get; set; } = null!;
        public bool VisaApproved { get; set; } = false;
        public bool PrePayment { get; set; } = false;
        public bool PaymentComplete { get; set; } = false;
        public DateTime DateOfBirth { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public byte[]? Photo { get; set; }
        public string FormOfStudy { get; set; } = null!;
        public bool ContractSigned { get; set; } = false;
        public string VisaNumber { get; set; } = null!;
        public DateTime VisaIssued { get; set; }
        public DateTime VisaExpires { get; set; }
        public DateTime PassportExpires { get; set; }

    }
}
