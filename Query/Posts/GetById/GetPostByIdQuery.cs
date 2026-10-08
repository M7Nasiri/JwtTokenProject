using Common.Query;
using Query.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using Query.Posts.DTOs;

namespace Query.Posts.GetById;
public class GetPostrByIdQuery : IQuery<PostDto?>
{
    public GetPostrByIdQuery(long postId)
    {
        PostId = postId;
    }

    public long PostId { get; private set; }
}