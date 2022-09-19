using API.Gateways.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;

namespace API.Gateways.Attributes
{
    public class CheckOwnerAttribute : TypeFilterAttribute
    {
        public CheckOwnerAttribute() : base(typeof(CheckOwnerActionFilter))
        {
        }
    }
    public class CheckOwnerActionFilter : IAsyncActionFilter
    {
        private readonly ICRMService _crmService;
        public CheckOwnerActionFilter(ICRMService crmService)
        {
            _crmService = crmService;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            string taskId = context.HttpContext.Request.Query["AccountId"];
            string accountId = context.HttpContext.Request.Query["AccountId"];
            if (!await _crmService.CheckTaskOwner(Guid.Parse(taskId), Guid.Parse(accountId)))
            {
                context.Result = new UnauthorizedResult();
            }
            await next();
        }
    }
}