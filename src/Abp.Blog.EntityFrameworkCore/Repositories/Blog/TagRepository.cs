﻿using Abp.Blog.Domain.Blog;
using Abp.Blog.Domain.Blog.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Abp.Blog.EntityFrameworkCore.Repositories.Blog
{
    /// <summary>
    /// TagRepository
    /// </summary>
    public class TagRepository:EfCoreRepository<AbpBlogDbContext, Tag, int>, ITagRepository
    {
        public TagRepository(IDbContextProvider<AbpBlogDbContext> dbContextProvider):base(dbContextProvider) { }

        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="tags"></param>
        /// <returns></returns>
        public async Task BulkInsertAsync(IEnumerable<Tag> tags)
        {
            await DbContext.Set<Tag>().AddRangeAsync(tags);
            await DbContext.SaveChangesAsync();
        }
    }
}
