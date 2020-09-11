
using Volo.Abp.Identity;
using Volo.Abp.Modularity;


namespace Abp.Blog
{
    [DependsOn(
        typeof(AbpIdentityHttpApiModule),
        typeof(AbpBlogApplicationModule)
        )]
    public class AbpBlogHttpApiModule : AbpModule
    {

    }
}
