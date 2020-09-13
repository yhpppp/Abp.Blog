using System;
using Abp.Blog.Domain;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.MySQL;
using Volo.Abp.Modularity;

namespace Abp.Blog
{
    [DependsOn(typeof(AbpBlogDomainModule), typeof(AbpEntityFrameworkCoreModule),
        typeof(AbpEntityFrameworkCoreMySQLModule))]
    public class AbpBlogFrameworkCoreModule : AbpModule
    {


        public override void ConfigureServices(ServiceConfigurationContext context)
        {
        }
    }
}
