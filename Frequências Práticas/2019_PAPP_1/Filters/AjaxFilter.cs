using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace _2019_PAPP.Filters
{
    public class AjaxFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Request.Headers["x-requested-with"] == "XMLHttpRequest")
            {
                base.OnActionExecuting(context);
            }
            else
            {
                context.HttpContext.Response.StatusCode = 403;
				context.Result = new EmptyResult();
				//context.Result = new RedirectToRouteResult(
				//	new RouteValueDictionary(new
				//	{
				//		controller = "Home",
				//		action = "Index"
				//	})
				//  );
			}
        }
    }
}
