namespace Newsletter.Domain.Interfaces;

public interface IEmailService
{
    Task SendWelcomeEmailAsync(string email);

    Task SendFollowUpEmailAsync(string email);
}
