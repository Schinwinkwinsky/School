using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.OData.Query;
using School.Application.Results;

namespace School.WebAPI.Attributes;

public class EnableQueryResultAttribute : EnableQueryAttribute
{
    public override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
    {
        if (actionExecutedContext.Exception != null) return;

        base.OnActionExecuted(actionExecutedContext);

        if (actionExecutedContext.Result is ObjectResult obj && obj.Value is not null)
            actionExecutedContext.Result = new ObjectResult(Result<object>.Success(obj.Value!));
    }
}
