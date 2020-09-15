using Abp.Blog.Domain.Blog;
using Abp.Blog.Domain.Blog.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Abp.Blog.EntityFrameworkCore.Repositories.Blog
{
    public class PostRepository : EfCoreRepository<AbpBlogDbContext, Post, int>, IPostRepository
    {
        public PostRepository(IDbContextProvider<AbpBlogDbContext> dbContextProvider): base(dbContextProvider)
        {

        }
    }
}
