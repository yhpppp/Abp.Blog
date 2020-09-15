using Abp.Blog.Application.Contracts.Blog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Abp.Blog.Application.Blog
{
    public interface IBlogService
    {
        Task<bool> InsertPostAsync(PostDto dto);
        Task<bool> DeletePostAsync(int id);
        Task<bool> UpdatePostAsync(int id, PostDto dto);
        Task<PostDto> GetPostAsync(int id);
    }
}
