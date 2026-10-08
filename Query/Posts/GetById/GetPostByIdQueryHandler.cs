using Common.Query;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Query.Posts.DTOs;

namespace Query.Posts.GetById;
public class GetPostByIdQueryHandler : IQueryHandler<GetPostrByIdQuery, PostDto?>
{
    private readonly DbCtx _context;

    public GetPostByIdQueryHandler(DbCtx context)
    {
        _context = context;
    }


    public async Task<PostDto?> Handle(GetPostrByIdQuery request, CancellationToken cancellationToken)
    {
        var post = await _context.Posts
            .FirstOrDefaultAsync(f => f.Id == request.PostId, cancellationToken);
        if (post == null)
            return null;
        return await post.Map(_context);
    }
}