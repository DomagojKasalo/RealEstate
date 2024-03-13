using domain.Models;

namespace domain.Interfaces.ICRUDservices.cpm
{
    public interface IEmailServices
    {
        Task SendMail(SendMailRequest request);
        Task SendMail2(SendReservationOrPurchaseEmailRequest request);
    }
}
