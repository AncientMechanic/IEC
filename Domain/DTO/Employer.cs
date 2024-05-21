using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class Employer : DataEntity
    {
        /// <summary>
        /// Название компании.
        /// </summary>
        [Required]
        [Column("companyname")]
        public string CompanyName { get; set; } = "";

        /// <summary>
        /// Имя контактного лица.
        /// </summary>
        [Required]
        [Column("contactfirstname")]
        public string ContactFirstName { get; set; } = "";

        /// <summary>
        /// Фамилия контактного лица.
        /// </summary>
        [Required]
        [Column("contactlastname")]
        public string ContactLastName { get; set; } = "";

        /// <summary>
        /// Адрес компании.
        /// </summary>
        [Required]
        [Column("companyaddress")]
        public string CompanyAddress { get; set; } = "";

        /// <summary>
        /// Статус предоплаты участника.
        /// </summary>
        [Required]
        [Column("housingprovided")]
        public bool HousingProvided { get; set; } = false;

        /// <summary>
        /// Страна компании.
        /// </summary>
        [Required]
        [Column("country")]
        public string Country { get; set; } = "";

        /// <summary>
        /// Город Работы.
        /// </summary>
        [Required]
        [Column("city")]
        public string City { get; set; } = "";

        /// <summary>
        /// Номер телефона контактного лица.
        /// </summary>
        [Required]
        [Column("contactphone")]
        public string ContactPhone { get; set; } = "";

        /// <summary>
        /// Email контактного лица.
        /// </summary>
        [Required]
        [Column("contactemail")]
        public string ContactEmail { get; set; } = "";

        /// <summary>
        /// Рабочая позиция участника.
        /// </summary>
        [Required]
        [Column("position")]
        public string Position { get; set; } = "";

        /// <summary>
        /// Рабочая ставка участника.
        /// </summary>
        [Required]
        [Column("wage")]
        public string Wage { get; set; } = "";

        /// <summary>
        /// Статус оффера от работодателя(принят/отклонен).
        /// </summary>
        [Required]
        [Column("jobofferstatus")]
        public string JobOfferStatus { get; set; } = "";

        /// <summary>
        /// ListId - идентификатор списка, к которому относится задание
        /// </summary>
        [ForeignKey("participantid")]
        public Guid ParticipantId { get; set; }
    }
}
