using System;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Abp.Blog
{
    [ConnectionStringName("MySql")]
    public class AbpBlogDbContext:AbpDbContext<AbpBlogDbContext>
    {
        public AbpBlogDbContext(DbContextOptions<AbpBlogDbContext> options):base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configure();
        }
    }
}
