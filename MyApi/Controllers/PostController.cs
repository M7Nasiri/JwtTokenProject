using Application.Posts.Create;
using Common.AspNetCore;
using Domain.RoleAgg.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Presentation.Facade.Posts;
using Query.Posts.DTOs;
using Shop.Api.Infrastructure.Security;
using Shop.Presentation.Facade.Users;

namespace MyApi.Controllers
{
    [PermissionChecker(Permission.PostManagement)]
    public class PostController : ApiController
    {
        private readonly IPostFacade _postFacade;
        private readonly IConfiguration _configuration;
        public PostController(IPostFacade postFacade, IConfiguration configuration)
        {
            _postFacade = postFacade;
            _configuration = configuration;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ApiResult<PostFilterResult>> GetAll([FromQuery]PostFilterParams param)
        {
            return QueryResult(await _postFacade.GetPostByFilter(param));
        }

        [HttpGet("{Id}")]
        [AllowAnonymous]
        public async Task<ApiResult<PostDto?>> GetById(long Id)
        {
            return QueryResult(await _postFacade.GetPostById(Id));
        }

        [HttpPost]
        public async Task<ApiResult> CreatePost([FromBody] CreatePostCommand command)
        {
            var result = await _postFacade.CreatePost(command);
            return CommandResult(result);
        }
        [HttpPut]
        public async Task<ApiResult> EditPost([FromBody] EditPostCommand command)
        {
            var result = await _postFacade.EditPost(command);
            return CommandResult(result);
        }

    }
}
