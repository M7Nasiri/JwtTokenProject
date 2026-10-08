using Application.Posts.Create;
using Common.Application;
using Domain.PostAgg;
using Domain.UserAgg;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Query.Posts.DTOs;
using Query.Posts.GetByFilter;
using Query.Posts.GetById;
using Query.Users.GetById;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentation.Facade.Posts
{
    public class PostFacade : IPostFacade
    {
        private readonly IMediator _mediator;
        public PostFacade(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<OperationResult> CreatePost(CreatePostCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> EditPost(EditPostCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<PostDto?> GetPostById(long postId)
        {
            return await _mediator.Send(new GetPostrByIdQuery(postId));
        }

        public async Task<PostFilterResult> GetPostByFilter(PostFilterParams filterParams)
        {
            return await _mediator.Send(new GetPostByFilterQuery(filterParams));
        }
    }
}
