using System.Net;
using System.Net.Mail;

namespace sultan.Web;

public class Mail
{
    private const string Body = @"вы взяли книгу";

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