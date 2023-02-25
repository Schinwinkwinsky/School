using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.OData.Query;
using School.Application.Results;

namespace School.WebAPI.Attributes
{
    public class EnableQueryPaginatedResultAttribute : EnableQueryAttribute
    {
        private ODataQueryOptions? _oDataQueryOptions = null;

        public override IQueryable ApplyQuery(IQueryable queryable, ODataQueryOptions queryOptions)
        {
            _oDataQueryOptions = queryOptions;

            return base.ApplyQuery(queryable, queryOptions);
        }

        public override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception != null) return;

            base.OnActionExecuted(actionExecutedContext);

            var skip = _oDataQueryOptions?.Skip?.Value;
            var top = _oDataQueryOptions?.Top?.Value;

            if (actionExecutedContext.Result is ObjectResult obj && obj.Value is IQueryable<object> queryable)
                actionExecutedContext.Result = new ObjectResult(PaginatedResult<object>.Success(queryable, queryable.Count(), skip, top));
        }
    }
}
