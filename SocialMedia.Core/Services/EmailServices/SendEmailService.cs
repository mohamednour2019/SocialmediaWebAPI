
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using SocialMedia.Core.ServicesInterfaces.EmailInterfaces;
namespace SocialMedia.Core.Services.EmailServices
{
    public class SendEmailService : ISendEmailService
    {
        private IConfiguration _config;
        private IHttpClientFactory _httpClient;
        public SendEmailService(IConfiguration configuration
            , IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
            _config = configuration;
        }
        async void ISendEmailService.SendEmail(string otp, string userEmail)
        {
            string senderEmail = _config["EmailCridential:senderEmail"];
            var apiKey = _config["EmailCridential:key"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(senderEmail, "MYSocial");
            var subject = "MYSocial Verify Account";
            var to = new EmailAddress(userEmail);
            var plainTextContent = $"This is your OTP to verify your account on MYSocial:\n{otp}";
            var htmlContent = $"This is your OTP to verify your account on MYSocial:\n{otp}";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
