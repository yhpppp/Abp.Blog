using System;
using Abp.Blog.Domain.Blog;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Abp.Blog
{
    [ConnectionStringName("MySql")]
    public class AbpBlogDbContext : AbpDbContext<AbpBlogDbContext>
    {
        public AbpBlogDbContext(DbContextOptions<AbpBlogDbContext> options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<FriendLink> FriendLinks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configure();
        }
    }
}
