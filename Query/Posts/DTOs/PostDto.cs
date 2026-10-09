using Common.Query;
using Common.Query.Filter;
using Domain.UserAgg.Enums;
using Query.Posts.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Query.Posts.DTOs;

public class PostDto : BaseDto
{
    public string Title { get;  set; }
    public string Text { get;  set; }
    public long WrittenBy { get;  set; }
    public string? AuthorName { get; set; }
    public int ViewCount { get;  set; }
}


public class PostFilterData : BaseDto
{
    public string Title { get; set; }
    public string Text { get;  set; }
    public long WrittenBy { get;  set; }
    public string? AuthorName { get; set; }
    public int ViewCount { get; set; }

}

public class PostFilterParams : BaseFilterParam
{
    public long? Id { get; set; }
    public string Title { get; set; }
    public string? Text { get; set; }
    public string? AuthorName { get; set; }

}
public class PostFilterResult : BaseFilter<PostFilterData, PostFilterParams>
{

}