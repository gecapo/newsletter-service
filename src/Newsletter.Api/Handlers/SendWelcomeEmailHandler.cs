using MassTransit;
using Newsletter.Api.Contracts;
using Newsletter.Domain.Interfaces;

namespace Newsletter.Api.Handlers;

public class SendWelcomeEmailHandler(IEmailService emailService) : IConsumer<SendWelcomeEmailCommand>
{
    public async Task Consume(ConsumeContext<SendWelcomeEmailCommand> context)
    {
        await emailService.SendWelcomeEmailAsync(context.Message.Email);

        await context.Publish(new WelcomeEmailSent(context.Message.SubscriberId, context.Message.Email));
    }
}
