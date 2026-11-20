namespace CountyServicePortal.Models
{
    public class AccountDetails
    {
        public int UserID { get; set; }

        public string Username { get; set; } = string.Empty;

        public DateTime AccountCreatedAt { get; set; }

        public int RequestsMade { get; set; } = 0;

        public int RequestsAltered { get; set; } = 0;

    }
}
