using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using System.Reflection;

namespace _10._Disposal_and_Garbage_collection
{
    public class EmailService : IDisposable
    {
        private bool _disposedValue;

        public SmtpClient Client { get; init; }

        public string Username { get; init; }

        public EmailService()
        {
            //Creating configuration, retrieving uname and pass for using SMTP gmail server.

            IConfiguration config = new ConfigurationBuilder()
                .AddUserSecrets(Assembly.GetExecutingAssembly(), true)
                .Build();

            Username = config.GetSection("credentials")["username"] ?? "";

            var pass = config.GetSection("credentials")["pass"];

            Client = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(Username, pass),
                EnableSsl = true,
            };
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    Client.Dispose();
                }

                _disposedValue = true;
            }
        }
    }
}
