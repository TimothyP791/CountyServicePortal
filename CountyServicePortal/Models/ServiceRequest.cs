
using System.ComponentModel.DataAnnotations;

namespace CountyServicePortal.Models
{
    public class ServiceRequest
    {
        [Key] // Primary key for the ServiceRequest entity
        public int RequestId { get; set; }

        [Required] // Attributes used to help EF Core creat proper database Schema and to validate the model data
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(1000)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string Category { get; set; } = string.Empty;

        public string Status { get; set; } = "Submitted"; // Default status for new service requests 

        public DateTime DateSubmitted { get; set; }
    }
}