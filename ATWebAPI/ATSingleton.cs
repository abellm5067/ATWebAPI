using EFRepository;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using EFRepository.Models;

namespace ATWebAPI
{
    public sealed class ATSingleton
    {
        private ATSingleton()
        {

        }
        public const string MY_VARIABLE_NAME = "MY_VARIABLE_NAME";
        private static ATSingleton _instance = null;
        private static readonly object _myObect = new object();

        public static ATSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_myObect)
                    {
                        if (_instance == null)
                        {
                            _instance = new ATSingleton();
                        }
                    }
                }
                return _instance;
            }
        }
        public string ComputeHash(string password, string salt, int iteration)
        {
            if (iteration <= 0) return password;

            using var sha256 = SHA256.Create();
            var passwordSaltPepper = $"{password}{salt}{MY_VARIABLE_NAME}";
            var byteValue = Encoding.UTF8.GetBytes(passwordSaltPepper);
            var byteHash = sha256.ComputeHash(byteValue);
            var hash = Convert.ToBase64String(byteHash);
            return ComputeHash(hash, salt, iteration - 1);
        }

        public string GenerateSalt()
        {
            using var rng = RandomNumberGenerator.Create();
            var byteSalt = new byte[16];
            rng.GetBytes(byteSalt);
            var salt = Convert.ToBase64String(byteSalt);
            return salt;
        }
        public void SendEmail(List<string> toEmail, string subject, string body)
        {
            string smtpHost = "smtp.gmail.com";
            int smtpPort = 587;
            string smtpUsername = Environment.GetEnvironmentVariable("My_Anil_Email") ?? "";
            string smtpPassword = Environment.GetEnvironmentVariable("My_Pwd") ?? "";
            MailMessage message = new MailMessage();
            message.From = new MailAddress(smtpUsername);
            foreach (string toAddress in toEmail)
            {
                message.To.Add(toAddress); 
            }
            message.Subject = subject;
            string emailTemplate= File.ReadAllText("wwwroot/EmailTemplate.html", System.Text.Encoding.UTF8);
            message.Body = emailTemplate.Replace("{{body}}",body);
            message.IsBodyHtml = true;
            SmtpClient smtpClient = new SmtpClient(smtpHost, smtpPort);
            smtpClient.UseDefaultCredentials = false;
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
            smtpClient.Send(message);
            Console.WriteLine("Email sent successfully.");
        }
        public string CreatePassword(int length=8)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }
    }
}
