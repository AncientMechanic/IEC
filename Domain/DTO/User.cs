using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DTO
{
    public class User : DataEntity
    {
        [Required]
        [Column("email")]
        public string? Email { get; set; }

        [Required]
        [Column("password")]
        public string? Password { get; set; }

        [Required]
        [Column("isdeleted")]
        public bool IsDeleted { get; set; } = false;

        public List<Participant>? Participants { get; set; } = new List<Participant>();
    }
}
