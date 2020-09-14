using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Abp.Blog
{
    //使用Code-First命令
    public class AbpBlogMigrationsDbContextFactory : IDesignTimeDbContextFactory<AbpBlogMigrationsDbContext>
    {
        public AbpBlogMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<AbpBlogMigrationsDbContext>()
                .UseMySql(configuration.GetConnectionString("Default"));

            return new AbpBlogMigrationsDbContext(builder.Options);
        }

        private IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            return builder.Build();
        }
    }
}
