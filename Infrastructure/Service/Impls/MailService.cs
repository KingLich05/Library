using sultan.Web;
using System.Net;
using System.Net.Mail;

namespace sultan.Service.Impls;

/// <summary>
/// Сервис для работы с отправкой писем на почту.
/// </summary>
public class MailService : IMailService
{
    /// <summary>
    /// Текст сообщения электронной почты.
    /// </summary>
    private const string Body = @"Вы взяли книгу";

    /// <summary>
    /// Отправляет сообщение на электронную почту.
    /// </summary>
    public async Task SendMail()
    {
        var client = new SmtpClient("live.smtp.mailtrap.io", 587)
        {
            Credentials = new NetworkCredential("api", "b8f98e7a0c709705015c7527a28ecca6"),
            EnableSsl = true
        };
        client.Send("mailtrap@demomailtrap.com", "skurmanov12@gmail.com", "Библиотека", Body);
    }
    
}