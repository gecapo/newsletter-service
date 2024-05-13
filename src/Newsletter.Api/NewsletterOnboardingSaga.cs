using MassTransit;
using Newsletter.Api.Contracts;
using Newsletter.Domain.Entities;

namespace Newsletter.Api;

public class NewsletterOnboardingSaga : MassTransitStateMachine<NewsletterOnboardingSagaData>
{
    public State Welcoming { get; set; }
    public State FollowingUp { get; set; }
    public State Onboarding { get; set; }

    public Event<SubscriberCreated> SubscriberCreated { get; set; }
    public Event<WelcomeEmailSent> WelcomeEmailSent { get; set; }
    public Event<FollowUpEmailSent> FollowUpEmailSent { get; set; }

    public NewsletterOnboardingSaga()
    {
        InstanceState(x => x.CurrentState);

        Event(() => SubscriberCreated, e => e.CorrelateById(m => m.Message.SubscriberId));
        Event(() => WelcomeEmailSent, e => e.CorrelateById(m => m.Message.SubscriberId));
        Event(() => FollowUpEmailSent, e => e.CorrelateById(m => m.Message.SubscriberId));

        Initially(
            When(SubscriberCreated)
                .Then(context =>
                {
                    context.Saga.SubscriberId = context.Message.SubscriberId;
                    context.Saga.Email = context.Message.Email;
                })
                .TransitionTo(Welcoming)
                .Publish(context => new SendWelcomeEmailCommand(context.Message.SubscriberId, context.Message.Email)));

        During(Welcoming,
            When(WelcomeEmailSent)
                .Then(context => context.Saga.WelcomeEmailSent = true)
                .TransitionTo(FollowingUp)
                .Publish(context => new SendFollowUpEmailCommand(context.Message.SubscriberId, context.Message.Email)));

        During(FollowingUp,
            When(FollowUpEmailSent)
                .Then(context =>
                {
                    context.Saga.FollowUpEmailSent = true;
                    context.Saga.OnboardingCompleted = true;
                })
                .TransitionTo(Onboarding)
                .Publish(context => new OnboardingCompleted(context.Message.SubscriberId, context.Message.Email))
                .Finalize());
    }
}
