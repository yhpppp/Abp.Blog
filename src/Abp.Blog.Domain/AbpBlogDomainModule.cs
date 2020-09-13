using System;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace Abp.Blog.Domain
{
    [DependsOn(typeof(AbpIdentityDomainModule))]
    public class AbpBlogDomainModule : AbpModule
    {
     
    }
}
