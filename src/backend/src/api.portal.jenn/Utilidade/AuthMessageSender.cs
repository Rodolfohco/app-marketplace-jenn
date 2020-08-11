using api.portal.jenn.ViewModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace api.portal.jenn.Utilidade
{
    public class AuthMessageSender : IEmailSender
    {
        public readonly IConfiguration configuration;

      
        public AuthMessageSender(IOptions<EmailSettings> emailSettings, IConfiguration _configuration)
        {
            _emailSettings = emailSettings.Value;
            this.configuration = _configuration;
        }

        public EmailSettings _emailSettings { get; }

        public Task SendEmailAsync(string email, string subject, string message, string NomeReceptor, string NomeEmpresa)
        {
            try
            {
                Execute(email, subject, message, NomeReceptor, NomeEmpresa).Wait();
                return Task.FromResult(0);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Execute(string email, string subject, string message, string NomeReceptor, string NomeEmpresa)
        {
            try
            {
                string toEmail =   _emailSettings.ToEmail ;

                MailMessage mail = new MailMessage()
                {
                    From = new MailAddress(_emailSettings.UsernameEmail, NomeReceptor)
                };

                mail.To.Add(new MailAddress(toEmail));
                mail.CC.Add(new MailAddress(_emailSettings.CcEmail));

                mail.Subject =  $"{NomeEmpresa} - { subject}";
                mail.Body = message;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                //outras opções
                //mail.Attachments.Add(new Attachment(arquivo));
                //

                using (SmtpClient smtp = new SmtpClient(_emailSettings.PrimaryDomain, _emailSettings.PrimaryPort))
                {
                    smtp.Credentials = new NetworkCredential(_emailSettings.UsernameEmail, _emailSettings.UsernamePassword);
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(mail);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
