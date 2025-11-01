using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;

namespace RegistroDeTickets.Service
{
    public interface IEmailService
    {
        Task EnviarEmail(string emailReceptor, string tema, string cuerpo);
    }

    public class EmailService : IEmailService
    {
        private readonly IConfiguration configuration;

        public EmailService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task EnviarEmail(string emailReceptor, string tema, string cuerpo)
        {
            var emailEmisor = configuration.GetValue<string>("Email_EMAIL");
            var password = configuration.GetValue<string>("Email_PASSWORD");
            var host = configuration.GetValue<string>("Email_HOST");
            var puerto = configuration.GetValue<int>("Email_PUERTO");



            var smtpCliente = new SmtpClient(host, puerto);
            smtpCliente.EnableSsl = true;
            smtpCliente.UseDefaultCredentials = false;

            smtpCliente.Credentials = new NetworkCredential(emailEmisor, password);
            var mensaje = new MailMessage(emailEmisor!, emailReceptor, tema, cuerpo);
            await smtpCliente.SendMailAsync(mensaje);
        }
    }
}