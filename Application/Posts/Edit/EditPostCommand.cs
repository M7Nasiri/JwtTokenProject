using Common.Application;
using Domain.RoleAgg.Enums;


namespace Application.Posts.Create;

public record EditPostCommand(long Id,string Title,string Text) : IBaseCommand;