using Template.Infrastructure.Interfaces;
using Newtonsoft.Json;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Infrastructure.Services
{
    public class SendGridService : ISendGridService
    {
        private readonly IConfiguration _configuration;

        public SendGridService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task WelcomeEmail(string email, string name, string password, string url)
        {
            var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage();
            var projectImage = "http://cdn.mcauto-images-production.sendgrid.net/390c46c817bff90f/ad6b85d0-1e1a-49d4-ad2a-9d1ab0b9c793/1000x200.png";
            msg.SetFrom(new EmailAddress("noreply@ixulabs.com", "Ixulabs"));

            var recipients = new List<EmailAddress>
            {
                new EmailAddress(email, name),
            };
            msg.AddTos(recipients);

            msg.SetSubject("Correo de bienvenida");
            msg.SetTemplateId("d-c63e3f5a6d3443f093ac753f5097a906");
            var dynamicTemplateData = new TemplateData
            {
                Name = name,
                Url = url,
                Password = password,
                Email = email,
                ProjectImage = projectImage
            };

            msg.SetTemplateData(dynamicTemplateData);
            //msg.AddContent(MimeType.Text, content);
            //msg.AddContent(MimeType.Html, content);
            var response2 = await client.SendEmailAsync(msg);

            Console.WriteLine(response2.StatusCode);
        }
 
        public async Task ConfirmationEmail(string email, string name, string password, string url, string projectName, string projectImage)
        {
            var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage();
            msg.SetFrom(new EmailAddress("noreply@ixulabs.com", projectName));

            var recipients = new List<EmailAddress>
            {
                new EmailAddress(email, name),
            };
            msg.AddTos(recipients);

            msg.SetSubject("Confirmación Correo");
            msg.SetTemplateId("d-938fa32672ac44feb15152da0422598b");
            var dynamicTemplateData = new TemplateData
            {
                Name = name,
                Url = url,
                Password = password,
                Email = email,
                ProjectImage = projectImage,
                ProjectName = projectName,
            };

            msg.SetTemplateData(dynamicTemplateData);
            //msg.AddContent(MimeType.Text, content);
            //msg.AddContent(MimeType.Html, content);
            var response2 = await client.SendEmailAsync(msg);

            Console.WriteLine(response2.StatusCode);
        }
        public async Task ConfirmationEmailJiro(string email, string name, string password, string url, string projectName, string projectImage)
        {
            var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage();

            msg.SetFrom(new EmailAddress("noreply@movi.digital", projectName));

            var recipients = new List<EmailAddress>
            {
                new EmailAddress(email, name),
            };
            msg.AddTos(recipients);

            msg.SetSubject("Confirmación Correo");
            msg.SetTemplateId("d-18af6dd415494186909b40d24a900343");
            var dynamicTemplateData = new TemplateData
            {
                Name = name,
                Url = url,
                Password = password,
                Email = email,
                ProjectImage = projectImage,
                ProjectName = projectName,
            };

            msg.SetTemplateData(dynamicTemplateData);
            //msg.AddContent(MimeType.Text, content);
            //msg.AddContent(MimeType.Html, content);
            var response2 = await client.SendEmailAsync(msg);

            Console.WriteLine(response2.StatusCode);
        }
        public async Task RecoverPassword(string email, string name, string url, string projectName, string projectImage)
        {
            var apiKey = _configuration.GetSection("SENDGRID_API_KEY").Value;
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage();

            msg.SetFrom(new EmailAddress("noreply@ixulabs.com", projectName));

            var recipients = new List<EmailAddress>
            {
                new EmailAddress(email, name),
            };
            msg.AddTos(recipients);

            msg.SetSubject("Restablece tu contraseña");
            msg.SetTemplateId("d-99dc0b455f4d4e69bc1098b7050af1fb");

            var dynamicTemplateData = new TemplateData
            {
                Name = name,
                Url = url,
                ProjectImage = projectImage,
                ProjectName = projectName,
            };

            msg.SetTemplateData(dynamicTemplateData);
            //msg.AddContent(MimeType.Text, content);
            //msg.AddContent(MimeType.Html, content);
            var response2 = await client.SendEmailAsync(msg);

            Console.WriteLine(response2.StatusCode);
        }
    }

    public class TemplateData
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("project_name")]
        public string ProjectName { get; set; }

        [JsonProperty("project_image")]
        public string ProjectImage { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }
}