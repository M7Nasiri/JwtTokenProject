using Common.Application;
using Domain.RoleAgg.Enums;


namespace Application.Posts.Create;

public record EditPostCommand(long Id,long UserId,string Title,string Text) : IBaseCommand;