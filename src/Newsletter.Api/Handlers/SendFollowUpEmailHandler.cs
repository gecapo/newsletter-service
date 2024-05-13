using MassTransit;
using Newsletter.Api.Contracts;
using Newsletter.Domain.Interfaces;

namespace Newsletter.Api.Handlers;

public class SendFollowUpEmailHandler(IEmailService emailService) : IConsumer<SendFollowUpEmailCommand>
{
    public async Task Consume(ConsumeContext<SendFollowUpEmailCommand> context)
    {
        await emailService.SendFollowUpEmailAsync(context.Message.Email);

        await context.Publish(new FollowUpEmailSent(context.Message.SubscriberId, context.Message.Email));
    }
}
