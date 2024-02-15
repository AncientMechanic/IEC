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
        [Column("address")]
        public string Address { get; set; } = "";

        /// <summary>
        /// Штат компании.
        /// </summary>
        [Required]
        [Column("state")]
        public string State { get; set; } = "";

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
        /// ListId - идентификатор списка, к которому относится задание
        /// </summary>
        [ForeignKey("participantId")]
        public Guid ParticipantId { get; set; }
    }
}
