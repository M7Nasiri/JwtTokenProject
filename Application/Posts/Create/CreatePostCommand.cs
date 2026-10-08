using Common.Application;
using Domain.RoleAgg.Enums;


namespace Application.Posts.Create;

public record CreatePostCommand(long UserId,string Title,string Text) : IBaseCommand;