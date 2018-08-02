using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arshid.Configuration.Validation
{
    public class ArshidModelAttribute : ActionFilterAttribute
    {
        private string _contextMessage;

        public ArshidModelAttribute(string contextMessage)
        {
            _contextMessage = contextMessage;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new ValidationFailureResponse(context.ModelState, _contextMessage);
            }
        }
    }

    public class ValidationFailureResponse : ObjectResult
    {
        public ValidationFailureResponse(ModelStateDictionary ModelState, string defaultCode)
            : base(ModelErrorResponse.GetResponse(ModelState, defaultCode))
        {
        }
    }
}
