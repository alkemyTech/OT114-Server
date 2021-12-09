using OngProject.Models;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Services
{
    public class MailService : IMailService
    {
        private readonly ISendGridClient _sendGridClient;

        public MailService(ISendGridClient sendGridClient)
        {
            _sendGridClient = sendGridClient;
        }
        public async Task SendEmail(User user)
        {
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("santidota2012@gmail.com", "API de ONG SOMOS MAS"),
                Subject = "Se ha registrado correctamente",
                PlainTextContent = $"Se ha creado el usuario con nombre {user.FirstName} de manera correcta."
            };
            msg.AddTo(new EmailAddress(user.Email, "Test User"));

            await _sendGridClient.SendEmailAsync(msg);
        }
    }
}
