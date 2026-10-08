using Domain.PostAgg;
using Domain.PostAgg.Repository;
using Domain.UserAgg;
using Infrastructure._Utilities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Infrastructure.Persistent.EF.PostAgg
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {

        private readonly DbCtx _context;

        public PostRepository(DbCtx context) : base(context)
        {
            _context = context;
        }
       
    }
}
