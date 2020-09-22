using Abp.Blog.Application.Caching;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;


namespace Abp.Blog
{
    [DependsOn(
        typeof(AbpIdentityApplicationModule),
        typeof(AbpBlogApplicationCachingModule)
        )]
    public class AbpBlogApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
        }
    }
}
