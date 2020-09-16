using System;
using System.Collections.Generic;
using System.Text;

namespace Abp.Blog.ToolKits.Base.Paged
{
    /// <summary>
    /// 返回结果列表接口
    /// </summary>
    public interface IListResult<T>
    {
        /// <summary>
        /// 返回结果
        /// </summary>
        IReadOnlyList<T> Item { get; set; }
    }
}
