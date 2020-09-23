using Abp.Blog.Domain.Configurations;
using Abp.Blog.Domain.Shared;
using Hangfire;
using Hangfire.Dashboard.BasicAuthorization;
using Hangfire.MySql.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp;
using Volo.Abp.BackgroundJobs.Hangfire;
using Volo.Abp.Modularity;

namespace Abp.Blog.BackgroundJobs
{
    [DependsOn(typeof(AbpBackgroundJobsHangfireModule))]
    public class AbpBlogBackgroundJobsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHangfire(config =>
            {
                config.UseStorage(
                    new MySqlStorage(AppSettings.ConnectionStrings,
                    new MySqlStorageOptions
                    {
                        TablePrefix = AbpBlogConsts.DbTablePrefix + "hangfire"
                    }));
            });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();

            app.UseHangfireServer();
            app.UseHangfireDashboard(options: new DashboardOptions
            {
                Authorization = new[]
    {
        new BasicAuthAuthorizationFilter(new BasicAuthAuthorizationFilterOptions
        {
            RequireSsl = false,
            SslRedirect = false,
            LoginCaseSensitive = true,
            Users = new []
            {
                new BasicAuthAuthorizationUser
                {
                    Login = AppSettings.Hangfire.Login,
                    PasswordClear =  AppSettings.Hangfire.Password
                }
            }
        })
    },
                DashboardTitle = "任务调度中心"
            });
            var service = context.ServiceProvider;

            service.UseHangfireTest();
        }
    }
}
