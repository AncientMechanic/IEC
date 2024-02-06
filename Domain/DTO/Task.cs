using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class Task : DataEntity
    {

        /// <summary>
        /// Title - имя задания
        /// </summary>
        [Required]
        [Column("title")]
        public string? Title { get; set; }
        /// <summary>
        /// Description - описание задания - то, что будет указано пользователю в списке
        /// </summary>
        [Required]
        [Column("description")]
        public string? Description { get; set; }
        /// <summary>
        /// Active - статус активности задания
        /// </summary>
        [Required]
        [Column("active")]
        public bool Active { get; set; }
        /// <summary>
        /// Cancel - статус отмены задания
        /// </summary>
        [Required]
        [Column("cancel")]
        public bool Cancel { get; set; }
        /// <summary>
        /// Complete - статус выполнения задания
        /// </summary>
        [Required]
        [Column("complete")]
        public bool Complete { get; set; }
        /// <summary>
        /// SubTasks - кол-во подзаданий
        /// </summary>
        [Required]
        [Column("subTasks")]
        public int SubTasks { get; set; }
        /// <summary>
        /// Place - номер задания в очереди на выполнение в списке
        /// </summary>
        [Required]
        [Column("place")]
        public int Place { get; set; }
        /// <summary>
        /// ListId - идентификатор списка, к которому относится задание
        /// </summary>
        [ForeignKey("listId")]
        public Guid ListId { get; set; }
    }
}
