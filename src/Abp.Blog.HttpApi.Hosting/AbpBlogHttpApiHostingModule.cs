﻿using Abp.Blog.BackgroundJobs;
using Abp.Blog.BackgroundJobs.Jobs;
using Abp.Blog.Domain.Configurations;
using Abp.Blog.HttpApi.Hosting.Filters;
using Abp.Blog.HttpApi.Hosting.Middleware;
using Abp.Blog.Swagger;
using Abp.Blog.ToolKits.Base;
using Abp.Blog.ToolKits.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Linq;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.ExceptionHandling;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Abp.Blog.HttpApi.Hosting
{
    [DependsOn(
       typeof(AbpAspNetCoreMvcModule),
       typeof(AbpAutofacModule),
       typeof(AbpBlogHttpApiModule),
        typeof(AbpBlogFrameworkCoreModule),
        typeof(AbpBlogSwaggerModule)
    //typeof(AbpBlogBackgroundJobsModule)
    )]
    public class AbpBlogHttpApiHostingModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            //base.ConfigureServices(context);

            Configure<MvcOptions>(options =>
            {
                var filterMetadata = options.Filters.FirstOrDefault(x => x is ServiceFilterAttribute attribute && attribute.ServiceType.Equals(typeof(AbpExceptionFilter)));

                // 移除 AbpExceptionFilter
                options.Filters.Remove(filterMetadata);

                // 添加自己实现的 MeowvBlogExceptionFilter
                options.Filters.Add(typeof(AbpBlogExceptionFilter));
            });

            // 身份验证
            context.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                   .AddJwtBearer(options =>
                   {
                       options.TokenValidationParameters = new TokenValidationParameters
                       {
                           //是否验证颁发者
                           ValidateIssuer = true,
                           //是否验证访问群体
                           ValidateAudience = true,
                           //是否验证生存期
                           ValidateLifetime = true,
                           //验证Token的时间偏移量
                           ClockSkew = TimeSpan.FromSeconds(30),
                           //是否验证安全密钥
                           ValidateIssuerSigningKey = true,
                           //访问群体
                           ValidAudience = AppSettings.JWT.Domain,
                           //颁发者
                           ValidIssuer = AppSettings.JWT.Domain,
                           //安全密钥
                           IssuerSigningKey = new SymmetricSecurityKey(AppSettings.JWT.SecurityKey.GetBytes())
                       };
                       //应用程序提供的对象，用于处理承载引发的事件，身份验证处理程序
                       //options.Events = new JwtBearerEvents
                       //{
                       //    OnChallenge = async context =>
                       //    {
                       //        // 跳过默认的处理逻辑，返回下面的模型数据
                       //        context.HandleResponse();

                       //        context.Response.ContentType = "application/json;charset=utf-8";
                       //        context.Response.StatusCode = StatusCodes.Status200OK;

                       //        var result = new ServiceResult();
                       //        result.IsFailed("UnAuthorized");

                       //        await context.Response.WriteAsync(result.ToJson());
                       //    }
                       //};
                   });

            // 认证授权
            context.Services.AddAuthorization();

            // Http请求
            context.Services.AddHttpClient();

            // 定时任务
            //context.Services.AddTransient<IHostedService, HelloWorldJob>();

            context.Services.AddRouting(options =>
            {
                // 设置URL为小写
                options.LowercaseUrls = true;
                // 在生成的URL后面添加斜杠
                options.AppendTrailingSlash = true;

            });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            // 环境变量，开发环境
            if (env.IsDevelopment())
            {
                // 生成异常页面
                app.UseDeveloperExceptionPage();
            }
            // 使用HSTS的中间件，该中间件添加了严格传输安全头
            app.UseHsts();

            // 转发将标头代理到当前请求，配合 Nginx 使用，获取用户真实IP
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            // 路由
            app.UseRouting();

            // 跨域
            app.UseCors();

            // 异常处理中间件
            app.UseMiddleware<ExceptionHandlerMiddleware>();

            // 身份验证
            app.UseAuthentication();

            // 认证授权
            app.UseAuthorization();

            // HTTP => HTTPS
            app.UseHttpsRedirection();

            // 路由映射
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}