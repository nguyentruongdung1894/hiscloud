using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Nencer.Helpers;

namespace Nencer.Extensions
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            LogHelper.Exception(context.Exception.Message, context.Exception);
        }
    }
}
