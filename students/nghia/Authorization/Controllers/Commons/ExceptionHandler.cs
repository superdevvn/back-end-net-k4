using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace Controllers
{
    public class ExceptionHandler : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            while (context.Exception.InnerException != null) context.Exception = context.Exception.InnerException;
        }
    }
}
