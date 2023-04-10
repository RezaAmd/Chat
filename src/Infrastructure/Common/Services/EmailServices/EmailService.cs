using Chat.Infrastructure.Common.Interfaces;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Chat.Infrastructure.Common.Services.EmailServices
{
    public class EmailService : IEmailService
    {
        #region Constructor
        private readonly EmailSettings emailSettings;
        private readonly ILogger<EmailService> logger;

        public EmailService(IOptions<EmailSettings> _emailSettings,
            ILogger<EmailService> _logger)
        {
            emailSettings = _emailSettings.Value;
            logger = _logger;
        }
        #endregion

        public async Task<EmailResult> SendAsync(string reciever, string subject, string body, string from,
            string recieverName = default)
        {
            // sender email
            var SenderEmail = emailSettings.Emails.Where(e => e.from == from).FirstOrDefault();
            if (SenderEmail != null)
            {
                // message info. (from, to, subject, content)
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(SenderEmail.name, SenderEmail.username));
                message.To.Add(new MailboxAddress(recieverName, reciever));
                message.Subject = subject;
                message.Body = new TextPart("html") { Text = body };

                // client info for send. (host, port, authorize)
                var client = new SmtpClient();
                try
                {
                    client.Connect(emailSettings.host, emailSettings.port, emailSettings.useSsl);
                    client.Authenticate(SenderEmail.username, SenderEmail.password);
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                    return EmailResult.Success;
                }
                catch (Exception ex)
                {
                    logger.LogError("Exception caught in EmailService.SendAsync(): {0}", ex.ToString());
                }
            }
            else
                logger.LogWarning("Sender email not found!");
            return EmailResult.Failed();
        }
    }
}