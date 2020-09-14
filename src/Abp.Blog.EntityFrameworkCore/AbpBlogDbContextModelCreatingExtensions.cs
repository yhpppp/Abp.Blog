using System;
using Abp.Blog.Domain.Blog;
using Abp.Blog.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using static Abp.Blog.Domain.Shared.AbpBlogDbConsts;

namespace Abp.Blog
{
    public static class AbpBlogDbContextModelCreatingExtensions
    {
        public static void Configure(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            //配置表模型，包括表名、字段类型和长度等信息
            builder.Entity<Post>(b =>
            {
                b.ToTable(AbpBlogConsts.DbTablePrefix + DbTableName.Posts);
                b.HasKey(x => x.Id);
                b.Property(x => x.Title).HasMaxLength(200).IsRequired();
                b.Property(x => x.Author).HasMaxLength(10);
                b.Property(x => x.Url).HasMaxLength(100).IsRequired();
                b.Property(x => x.Html).HasColumnType("longtext").IsRequired();
                b.Property(x => x.Markdown).HasColumnType("longtext").IsRequired();
                b.Property(x => x.CategoryId).HasColumnType("int");
                b.Property(x => x.CreationTime).HasColumnType("datetime");
            });

            builder.Entity<Category>(b =>
            {
                b.ToTable(AbpBlogConsts.DbTablePrefix + DbTableName.Categories);
                b.HasKey(x => x.Id);
                b.Property(x => x.CategoryName).HasMaxLength(50).IsRequired();
                b.Property(x => x.DisplayName).HasMaxLength(50).IsRequired();
            });

            builder.Entity<Tag>(b =>
            {
                b.ToTable(AbpBlogConsts.DbTablePrefix + DbTableName.Tags);
                b.HasKey(x => x.Id);
                b.Property(x => x.TagName).HasMaxLength(50).IsRequired();
                b.Property(x => x.DisplayName).HasMaxLength(50).IsRequired();
            });

            builder.Entity<PostTag>(b =>
            {
                b.ToTable(AbpBlogConsts.DbTablePrefix + DbTableName.PostTags);
                b.HasKey(x => x.Id);
                b.Property(x => x.PostId).HasColumnType("int").IsRequired();
                b.Property(x => x.TagId).HasColumnType("int").IsRequired();
            });

            builder.Entity<FriendLink>(b =>
            {
                b.ToTable(AbpBlogConsts.DbTablePrefix + DbTableName.Friendlinks);
                b.HasKey(x => x.Id);
                b.Property(x => x.Title).HasMaxLength(20).IsRequired();
                b.Property(x => x.LinkUrl).HasMaxLength(100).IsRequired();
            });
        }
    }
}
