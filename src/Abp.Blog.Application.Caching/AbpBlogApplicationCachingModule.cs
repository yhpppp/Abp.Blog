using System;
using Abp.Blog.Domain;
using Volo.Abp.Caching;
using Volo.Abp.Modularity;
namespace Abp.Blog.Application.Caching
{
    [DependsOn(typeof(AbpCachingModule), typeof(AbpBlogDomainModule))]
    public class AbpBlogApplicationCachingModule : AbpModule
    {
        public AbpBlogApplicationCachingModule(ServiceConfigurationContext context)
        {
            base.ConfigureServices(context);
        }
    }
}
