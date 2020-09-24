using Abp.Blog.Application.Contracts.Blog;
using Abp.Blog.Domain.Blog;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abp.Blog.Application
{
    public class AbpBlogAutoMapperProfile : Profile
    {
        public AbpBlogAutoMapperProfile()
        {
            CreateMap<Post, PostDto>();
            CreateMap<PostDto, Post>().ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}
