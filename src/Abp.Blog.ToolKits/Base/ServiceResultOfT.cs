using Abp.Blog.ToolKits.Base.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abp.Blog.ToolKits.Base
{
    /// <summary>
    /// 服务层响应实体(泛型)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ServiceResult<T> : ServiceResult where T : class
    {
        /// <summary>
        /// 返回结果
        /// </summary>
        public T Result { get; set; }

        public void IsSuccess(T result = null, string message = "")
        {
            Message = message;
            Code = ServiceResultCode.Succeed;
            Result = result;
        }
    }
}
