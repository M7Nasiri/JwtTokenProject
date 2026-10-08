using Application.Posts.Create;
using Common.Application;
using Query.Posts.DTOs;
using Query.Users.DTOs;
using Shop.Application.Roles.Create;
using Shop.Application.Roles.Edit;
using Shop.Query.Roles.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentation.Facade.Posts
{
    public interface IPostFacade
    {
        Task<OperationResult> CreatePost(CreatePostCommand command);
        Task<OperationResult> EditPost(EditPostCommand command);

        Task<PostDto?> GetPostById(long postId);
        Task<PostFilterResult> GetPostByFilter(PostFilterParams filterParams);
    }
}
