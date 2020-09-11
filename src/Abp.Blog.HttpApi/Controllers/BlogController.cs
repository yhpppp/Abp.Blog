using Abp.Blog.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Abp.Blog.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class BlogController : AbpController
    {
        protected BlogController()
        {
            LocalizationResource = typeof(BlogResource);
        }
    }
}