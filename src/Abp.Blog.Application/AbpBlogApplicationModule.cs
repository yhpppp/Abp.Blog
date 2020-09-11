using Volo.Abp.Identity;
using Volo.Abp.Modularity;


namespace Abp.Blog
{
    [DependsOn(
        typeof(AbpIdentityApplicationModule)
        )]
    public class AbpBlogApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
        }
    }
}
