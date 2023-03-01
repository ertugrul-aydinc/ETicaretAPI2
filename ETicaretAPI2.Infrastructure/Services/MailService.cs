using ETicaretAPI2.Application.Abstractions.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI2.Infrastructure.Services
{
	public class MailService : IMailService
	{
		readonly IConfiguration _configuration;

		public MailService(IConfiguration configuration)
		{
			_configuration = configuration;
		}



        public async Task SendMailAsync(string to, string subject, string body, bool isBodyHtml = true)
		{
			await SendMailAsync(new[] {to},subject, body, isBodyHtml);
		}

		public async Task SendMailAsync(string[] tos, string subject, string body, bool isBodyHtml = true)
		{
			MailMessage mail = new();
			mail.IsBodyHtml = isBodyHtml;
			foreach (var item in tos)
			{
				mail.To.Add(item);
			}
			mail.Subject = subject;
			mail.Body = body;
			mail.From = new(_configuration["Mail:Username"],"Ertugrul E-Ticaret",Encoding.UTF8);

			SmtpClient smtp = new();
			smtp.Credentials = new NetworkCredential(_configuration["Mail:Username"], _configuration["Mail:Password"]);
			smtp.Port = 587;
			smtp.EnableSsl = true;
			smtp.Host = _configuration["Mail:Host"];
			await smtp.SendMailAsync(mail);
		}

		public async Task SendPasswordResetMailAsync(string to, string userId, string resetToken)
		{
			StringBuilder mail = new();
			mail.AppendLine("Merhaba<br>Eğer yeni şifre talebinde bulunduysanız aşağıdaki linkten şifrenizi yenileyebilirsiniz.<br><b><a target=\"_blank\" href=\"");

			mail.AppendLine(_configuration["AngularClientUrl"]);
			mail.AppendLine("/update-password/");
			mail.AppendLine(userId);
			mail.AppendLine("/");
			mail.AppendLine(resetToken);
			mail.AppendLine("\">Yeni şifre talebi için tıklayınız.</a></b><br><br>Saygılarımızla...<br><br><br>Aydinç E-Ticaret");


			string deneme = $"<a target=\"_blank\" href=\"{_configuration["AngularClientUrl"]}/update-password/{userId}/{resetToken}\"> Yeni şifre için tıklayın.</a>\"";

			await SendMailAsync(to, "Şifre Yenileme Talebi", deneme);
		}
        public async Task SendCompletedOrderMailAsync(string to, string orderCode, DateTime orderDate, string userName)
		{
			var mail = $"Sayın {userName} Merhaba<br>" +
				$"{orderDate} tarihinde vermiş olduğunuz {orderCode} sipariş kodlu" +
				$"siparişiniz tamamlanmış ve kargoya verilmiştir.<br>Güle güle kullanın...";

			await SendMailAsync(to, $"{orderCode} Sipariş Kodlu Siparişiniz Tamamlandı", mail);
        }
    }
}
