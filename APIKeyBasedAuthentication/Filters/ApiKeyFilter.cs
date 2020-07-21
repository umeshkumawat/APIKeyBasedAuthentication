using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIKeyBasedAuthentication.Filters
{
    public class ApiKeyFilterAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.HttpContext.Request.Headers.TryGetValue("ApiKey", out var apiKey))
            {
                var config = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
                var key = config.GetValue<string>("ApiKey");

                if (!key.Equals(apiKey))
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }
            }
            else
            {
                context.Result = new UnauthorizedResult();
                return;
            }


            await next();
        }
    }
}
