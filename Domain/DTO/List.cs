using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class List : DataEntity
    {

        /// <summary>
        /// Name - имя списка
        /// </summary>
        [Required]
        [Column("name")]
        public string Name { get; set; } = "";
        /// <summary>
        /// Description - описание списка
        /// </summary>
        
        [Column("description")]
        public string Description { get; set; } = "";
        /// <summary>
        /// AmountOfTasks - кол-во заданий
        /// </summary>
        [Required]
        [Column("amountoftasks")]
        public int AmountOfTasks { get; set; }
        /// <summary>
        /// CompletedTasks - кол-во завершенных заданий
        /// </summary>
        [Required]
        [Column("completedtasks")]
        public int CompletedTasks { get; set; }
        /// <summary>
        /// Complete - cтатус завершения списка
        /// </summary>
        [Required]
        [Column("complete")]
        public bool Complete { get; set; }
        /// <summary>
        /// Date - дата/даты, к которой приурочен список
        /// </summary>
        [Required]
        [Column("date")]
        public DateTime Date { get; set; }
        /// <summary>
        /// Id - идентификатор списка
        /// </summary>
        [Required]
        [Column("category")]
        public string Category { get; set; } = "";
        /// <summary>
        /// UserId - идентификатор пользователя, к которому относится список
        /// </summary>
        [ForeignKey("userid")]
        public Guid UserId { get; set; }
        /// <summary>
        /// Tasks - перечень заданий, входящих в данный список
        /// </summary>
        public List<Task>? Tasks { get; set; } = new List<Task> ();
        public User User { get; set; }
    }
}
