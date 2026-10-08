using System.ComponentModel.DataAnnotations;

namespace CountyServicePortal.Models
{
    public class Civilian
    {
        [Key] // Primary key for the Users entity
        public int UserId { get; set; }

        [Required] // Attributes used to help EF Core create proper database Schema and to validate the model data
        [StringLength(50)]
        public string Username { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Password { get; set; } = string.Empty;
    }
}
