using Newsletter.Domain.Interfaces;
using System.Net;
using System.Net.Mail;

namespace Newsletter.Api.Services;

internal sealed class EmailService(ILogger<EmailService> logger) : IEmailService
{
    public Task SendWelcomeEmailAsync(string email)
    {
        logger.LogInformation("EmailService.SendWelcomeEmailAsync {Email}", email);

        using MailMessage msg = new();
        msg.Subject = "Welcome";
        msg.Body = "Welcome";
        msg.To.Add(new MailAddress(email));

        using SmtpClient client = GetClient();
        client.Send(msg);

        return Task.CompletedTask;
    }

    public Task SendFollowUpEmailAsync(string email)
    {
        logger.LogInformation("EmailService.SendFollowUpEmailAsync {Email}", email);

        using MailMessage msg = new();
        msg.Subject = "Follow";
        msg.Body = "Followers++";
        msg.To.Add(new MailAddress(email));

        using SmtpClient client = GetClient();
        client.Send(msg);

        return Task.CompletedTask;
    }

    private SmtpClient GetClient() => new()
    {
        Host = "host",
        Port = 587,
        UseDefaultCredentials = false,
        DeliveryMethod = SmtpDeliveryMethod.Network,
        Credentials = new NetworkCredential("test@test.test", "test@123"),
        TargetName = "STARTTLS/smtp.office365.com", // Set to avoid MustIssueStartTlsFirst exception
        EnableSsl = true,
    };
}
