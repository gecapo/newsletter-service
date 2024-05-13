namespace Newsletter.Api.Contracts;

/// <summary>
/// 
/// </summary>
/// <param name="SubscriberId"></param>
/// <param name="Email"></param>
public record SendWelcomeEmailCommand(Guid SubscriberId, string Email);

/// <summary>
/// 
/// </summary>
/// <param name="SubscriberId"></param>
/// <param name="Email"></param>
public record SendFollowUpEmailCommand(Guid SubscriberId, string Email);

/// <summary>
/// 
/// </summary>
/// <param name="Email"></param>
public record SubscribeToNewsletterCommand(string Email);
