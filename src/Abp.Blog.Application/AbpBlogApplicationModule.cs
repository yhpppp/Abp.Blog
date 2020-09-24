using Abp.Blog.Application;
using Abp.Blog.Application.Caching;
using Volo.Abp.AutoMapper;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;


namespace Abp.Blog
{
    [DependsOn(
        typeof(AbpIdentityApplicationModule),
        typeof(AbpBlogApplicationCachingModule),
        typeof(AbpAutoMapperModule)
        )]
    public class AbpBlogApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(option =>
            {
                option.AddMaps<AbpBlogApplicationModule>(validate: true);
                option.AddProfile<AbpBlogAutoMapperProfile>(validate: true);
            });
        }
    }
}
