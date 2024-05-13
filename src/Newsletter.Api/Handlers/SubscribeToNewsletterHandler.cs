using MassTransit;
using Newsletter.Api.Contracts;
using Newsletter.Domain;
using Newsletter.Domain.Entities;

namespace Newsletter.Api.Handlers;

public class SubscribeToNewsletterHandler(AppDbContext dbContext) : IConsumer<SubscribeToNewsletterCommand>
{
    public async Task Consume(ConsumeContext<SubscribeToNewsletterCommand> context)
    {
        var subscriber = dbContext.Subscribers.Add(new Subscriber
        {
            Id = Guid.NewGuid(),
            Email = context.Message.Email,
            SubscribedOnUtc = DateTime.UtcNow
        });

        await dbContext.SaveChangesAsync();

        await context.Publish(new SubscriberCreated(subscriber.Entity.Id, context.Message.Email));
    }
}
