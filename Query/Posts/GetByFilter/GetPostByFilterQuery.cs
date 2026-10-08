using Common.Query;
using Query.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using Query.Posts.DTOs;

namespace Query.Posts.GetByFilter;

public class GetPostByFilterQuery : QueryFilter<PostFilterResult, PostFilterParams>
{
    public GetPostByFilterQuery(PostFilterParams filterParams) : base(filterParams)
    {
    }
}
