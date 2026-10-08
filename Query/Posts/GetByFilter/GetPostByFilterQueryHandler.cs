using Common.Query;
using Infrastructure;
using Query.Users.DTOs;
using Query.Users.GetByFilter;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Query.Posts.DTOs;
using Query.Users;

namespace Query.Posts.GetByFilter;
internal class GetPostByFilterQueryHandler : IQueryHandler<GetPostByFilterQuery, PostFilterResult>
{
    private readonly DbCtx _context;

    public GetPostByFilterQueryHandler(DbCtx context)
    {
        _context = context;
    }


    public async Task<PostFilterResult> Handle(GetPostByFilterQuery request, CancellationToken cancellationToken)
    {
        var @params = request.FilterParams;
        var result = _context.Posts.OrderByDescending(d => d.Id).AsQueryable();

        var authorId =  _context.Users.Where(u => u.Name == @params.AuthorName)
            .Select(u => u.Id).FirstOrDefault();

        if (!string.IsNullOrWhiteSpace(@params.Text))
            result = result.Where(r => r.Text.Contains(@params.Text));

        if (!string.IsNullOrWhiteSpace(@params.AuthorName))
        {
            var authorIds = _context.Users
                .Where(u => u.Name.Contains(@params.AuthorName) || u.Family.Contains(@params.AuthorName))
                .Select(u => u.Id);

            result = result.Where(r => authorIds.Contains(r.WrittenBy));
        }

        if (!string.IsNullOrWhiteSpace(@params.Title))
            result = result.Where(r => r.Title.Contains(@params.Title));



        var skip = (@params.PageId - 1) * @params.Take;
        var data = await result
            .OrderByDescending(d => d.Id)
            .Skip(skip)
            .Take(@params.Take)
            .Select(p => new PostFilterData
            {
                Id = p.Id,
                CreationDate = p.CreationDate,
                Text = p.Text,
                Title = p.Title,
                WrittenBy = p.WrittenBy,
                ViewCount = p.ViewCount,
                AuthorName = _context.Users
                    .Where(u => u.Id == p.WrittenBy)
                    .Select(u => u.Name + " " + u.Family)
                    .FirstOrDefault() ?? "نامشخص"
            })
            .ToListAsync(cancellationToken);
        var model = new PostFilterResult()
        {
            Data =data,
            FilterParams = @params
        };

        model.GeneratePaging(result, @params.Take, @params.PageId);
        return model;
    }
}