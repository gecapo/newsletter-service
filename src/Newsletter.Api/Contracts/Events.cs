namespace Newsletter.Api.Contracts;

/// <summary>
/// 
/// </summary>
/// <param name="SubscriberId"></param>
/// <param name="Email"></param>
public record SubscriberCreated(Guid SubscriberId, string Email);

/// <summary>
/// 
/// </summary>
/// <param name="SubscriberId"></param>
/// <param name="Email"></param>
public record WelcomeEmailSent(Guid SubscriberId, string Email);

/// <summary>
/// 
/// </summary>
/// <param name="SubscriberId"></param>
/// <param name="Email"></param>
public record FollowUpEmailSent(Guid SubscriberId, string Email);

/// <summary>
/// 
/// </summary>
/// <param name="SubscriberId"></param>
/// <param name="Email"></param>
public record OnboardingCompleted(Guid SubscriberId, string Email);
