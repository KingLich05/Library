namespace sultan.Service;

public interface IMailService
{
    /// <summary>
    /// Отправка письма на почту пользователя.
    /// </summary>
    Task SendMail();
}