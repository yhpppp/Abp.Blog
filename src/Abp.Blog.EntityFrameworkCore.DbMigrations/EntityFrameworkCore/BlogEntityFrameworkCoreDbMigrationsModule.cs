﻿using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Abp.Blog.EntityFrameworkCore
{
    [DependsOn(
        typeof(BlogEntityFrameworkCoreModule)
        )]
    public class BlogEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<BlogMigrationsDbContext>();
        }
    }
}
