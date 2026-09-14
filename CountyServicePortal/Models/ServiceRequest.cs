
using System.ComponentModel.DataAnnotations;

namespace CountyServicePortal.Models
{
    public class ServiceRequest
    {
        [Key] // Primary key for the ServiceRequest entity
        public int RequestId { get; set; }

        [Required] // Attributes used to help EF Core creat proper database Schema and to validate the model data
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        public string Category { get; set; }

        public string Status { get; set; }

        public DateTime DateSubmitted { get; set; }
    }
}