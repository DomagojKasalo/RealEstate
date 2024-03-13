namespace domain.Models
{
    public class SendMailRequest
    {
        public string? Email { get; set; }
        public string? Subject { get; set; }
        public string? Message { get; set; }
    }
}
