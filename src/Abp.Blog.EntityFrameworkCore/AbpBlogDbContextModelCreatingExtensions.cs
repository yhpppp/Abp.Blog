using System;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace Abp.Blog
{
    public static class AbpBlogDbContextModelCreatingExtensions
    {
        public static void Configure(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));
        }
    }
}
