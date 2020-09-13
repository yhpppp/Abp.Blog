using System;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace Abp.Blog.Domain.Shared
{
    [DependsOn(typeof(AbpIdentityDomainModule))]
    public class AngBlogDomainSharedModule
    {
        public AngBlogDomainSharedModule()
        {
        }
    }
}
