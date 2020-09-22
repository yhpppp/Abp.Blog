using System;
using Abp.Blog.Domain;
using Abp.Blog.Domain.Configurations;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Redis;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Caching;
using Volo.Abp.Modularity;

namespace Abp.Blog.Application.Caching
{
    [DependsOn(typeof(AbpCachingModule), typeof(AbpBlogDomainModule))]
    public class AbpBlogApplicationCachingModule : AbpModule
    {
        //public AbpBlogApplicationCachingModule(ServiceConfigurationContext context)
        //{
        //    base.ConfigureServices(context);
        //}

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddStackExchangeRedisCache(options =>
            {
                // 连接字符串
                options.Configuration = AppSettings.Caching.RedisConnectionString;
                // 实例名称
                //options.InstanceName
                // 配置属性
                //options.ConfigurationOptions
            });

            var csredis = new CSRedis.CSRedisClient(AppSettings.Caching.RedisConnectionString);
            RedisHelper.Initialization(csredis);

            context.Services.AddSingleton<IDistributedCache>(new CSRedisCache(RedisHelper.Instance));
        }
    }
}
