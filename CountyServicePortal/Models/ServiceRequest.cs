namespace CountyServicePortal.Models
{
    public class ServiceRequest
    {
        public int RequestId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Status { get; set; }
        public DateTime DateSubmitted { get; set; }

    }
}