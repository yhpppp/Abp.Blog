﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.EntityFrameworkCore;

namespace Abp.Blog
{
    public class AbpBlogMigrationsDbContext : AbpDbContext<AbpBlogMigrationsDbContext>
    {
        public AbpBlogMigrationsDbContext(DbContextOptions<AbpBlogMigrationsDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Configure();
        }
    }
}
