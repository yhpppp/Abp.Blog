using Abp.Blog.BackgroundJobs.Jobs.Hangfire;
using Hangfire;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace Abp.Blog.BackgroundJobs
{
    public static class AbpBlogBackgroundJobsExtensions
    {
        public static void UseHangfireTest(this IServiceProvider service)
        {
            var job = service.GetService<HangfireTestJob>();

            RecurringJob.AddOrUpdate("定时任务测试", () => job.ExecuteAsync(), CronType.Minute());
        }
    }
}
