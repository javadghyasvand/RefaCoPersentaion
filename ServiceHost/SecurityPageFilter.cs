using Microsoft.AspNetCore.Mvc.Filters;
using My_Shop_Framework.Infrastructure;
using System.Reflection;
using My_Shop_Framework.Application;
using System.Linq;

namespace ServiceHost
{
    // public class SecurityPageFilter : IPageFilter
    // {
    //     private readonly IAuthHelper _authHelper;
    //
    //     public SecurityPageFilter(IAuthHelper authHelper)
    //     {
    //         _authHelper = authHelper;
    //     }
    //
    //     public void OnPageHandlerSelected(PageHandlerSelectedContext context)
    //     {
    //     }
    //
    //     public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
    //     {
    //         var handlerPermission =
    //             (NeedPermissionAttribute)context.HandlerMethod.MethodInfo.GetCustomAttribute(
    //                 typeof(NeedPermissionAttribute));
    //         if (handlerPermission == null)
    //             return;
    //         var accountPermission = _authHelper.GetPermissions();
    //         if (accountPermission.All(x => x != handlerPermission.Permission))
    //             context.HttpContext.Response.Redirect("/Account");
    //
    //
    //     }
    //
    //     public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
    //     {
    //
    //     }
    // }
}