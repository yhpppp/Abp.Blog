using System;
using System.Collections.Generic;
using System.Text;

namespace Abp.Blog.ToolKits.Base.Paged
{
    /// <summary>
    /// 总数接口
    /// </summary>
    public interface IHasTotalCount
    {
        /// <summary>
        /// 总数
        /// </summary>
        int Total { get; set; }
    }
}
