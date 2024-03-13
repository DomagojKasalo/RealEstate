using domain.Entities.email;
using domain.Interfaces.ICRUDservices.cpm;
using Microsoft.Extensions.Options;
using System.Net.Mail;
using System.Net;
using domain.Models;

namespace application.CRUDservices.crm
{
    public class EmailService : IEmailServices
    {
        private readonly SmtpSettings _smtpSettings;
        private readonly SmtpClient _smtpClient;

        public EmailService(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;
            _smtpClient = new SmtpClient(_smtpSettings.Server)
            {
                Port = _smtpSettings.Port,
                Credentials = new NetworkCredential(_smtpSettings.SenderEmail, _smtpSettings.Password),
                EnableSsl = true,
            };
        }

        public async Task SendMail(SendMailRequest request)
        {
            var message = new MailMessage(_smtpSettings.SenderEmail, request.Email)
            {
                Subject = request.Subject,
                Body = request.Message
            };

            await _smtpClient.SendMailAsync(message);
        }

        public async Task SendMail2(SendReservationOrPurchaseEmailRequest request)
        {
            string actionVerb = request.Action == CatalogItemAction.Reserved ? "has shown interest in" : "wants to buy";
            var message = new MailMessage(_smtpSettings.SenderEmail, request.Email)
            {
                Subject = "Reservation/Purchase Notification",
                Body = $"Hello,\nUser {request.User.FirstName} {request.User.LastName} {actionVerb} CatalogItem by the name {request.CatalogItem.Name}.\nThis is his contact information: {request.User.Email}, {request.User.PhoneNumber}.\nThank you for using our services!\nAll best wishes!"
            };

            await _smtpClient.SendMailAsync(message);
        }
    }


}
