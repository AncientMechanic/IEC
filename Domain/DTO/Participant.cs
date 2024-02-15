using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class Participant : DataEntity
    {

        /// <summary>
        /// Имя участника.
        /// </summary>
        [Required]
        [Column("firstname")]
        public string FirstName { get; set; } = "";

        /// <summary>
        /// Фамилия участника.
        /// </summary>
        [Required]
        [Column("lastname")]
        public string LastName { get; set; } = "";

        /// <summary>
        /// Отчество участника.
        /// </summary>
        [Required]
        [Column("patronymic")]
        public string Patronymic { get; set; } = "";

        /// <summary>
        /// Дата рождения участника.
        /// </summary>
        [Column("dateofbirth")]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Название университета, в котором учится участник.
        /// </summary>
        [Required]
        [Column("nameofuniversity")]
        public string NameOfUniversity { get; set; } = "";

        /// <summary>
        /// Курс, на котором учится участник.
        /// </summary>
        [Required]
        [Column("yearofstudy")]
        public int YearOfStudy { get; set; }

        /// <summary>
        /// Номер телефона участника.
        /// </summary>
        [Required]
        [Column("phonenumber")]
        public string PhoneNumber { get; set; } = "";

        /// <summary>
        /// Электронная почта участника.
        /// </summary>
        [Required]
        [Column("email")]
        public string Email { get; set; } = "";

        /// <summary>
        /// Статус оплаты взносов участника.
        /// </summary>
        [Required]
        [Column("paymentcomplete")]
        public bool PaymentComplete { get; set; }

        /// <summary>
        /// Статус одобрения визы участника.
        /// </summary>
        [Required]
        [Column("visaapproved")]
        public bool VisaApproved { get; set; }

        /// <summary>
        /// Дата отъезда участника.
        /// </summary>
        [Required]
        [Column("departuredate")]
        public DateTime DepartureDate { get; set; }

        /// <summary>
        /// Дата возвращения участника.
        /// </summary>
        [Required]
        [Column("returndate")]
        public DateTime ReturnDate { get; set; }


        /// <summary>
        /// UserId - идентификатор работника входящего в систему
        /// </summary>
        [ForeignKey("userid")]
        public Guid UserId { get; set; }
        /// <summary>
        /// Работодатель принимающий участника
        /// </summary>
        public Employer? Employer { get; set; }
        public User? User { get; set; }
    }
}
