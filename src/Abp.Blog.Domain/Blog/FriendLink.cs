﻿using System;
using Volo.Abp.Domain.Entities;

namespace Abp.Blog.Domain.Blog
{
    /// <summary>
    /// FriendLink
    /// </summary>
    public class FriendLink: Entity<int>
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 链接
        /// </summary>
        public string LinkUrl { get; set; }
    }
}
