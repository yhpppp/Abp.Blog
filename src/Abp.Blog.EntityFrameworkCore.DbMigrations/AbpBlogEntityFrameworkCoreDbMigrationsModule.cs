using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Modularity;

namespace Abp.Blog
{
    [DependsOn(typeof(AbpBlogFrameworkCoreModule))]
    public class AbpBlogEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<AbpBlogMigrationsDbContext>();
        }
    }
}
