using Common.Application;

namespace Application.Users.RemoveToken;

public record RemoveUserTokenCommand(long UserId,long TokenId) : IBaseCommand<string>;