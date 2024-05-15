using System.Net;
using System.Net.Mail;

namespace sultan.Web;

/// <summary>
/// Класс для отправки электронной почты.
/// </summary>
public class Mail
{
    /// <summary>
    /// Текст сообщения электронной почты.
    /// </summary>
    private const string Body = @"Вы взяли книгу";

    /// <summary>
    /// Отправляет сообщение на электронную почту.
    /// </summary>
    public static async Task SendMail()
    {
        var client = new SmtpClient("live.smtp.mailtrap.io", 587)
        {
            Credentials = new NetworkCredential("api", "b8f98e7a0c709705015c7527a28ecca6"),
            EnableSsl = true
        };
        client.Send("mailtrap@demomailtrap.com", "skurmanov12@gmail.com", "Библиотека", Body);
    }
}
