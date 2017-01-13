using parking_service.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Security;

using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Filters;
using System.Threading;
using System.Threading.Tasks;

namespace parking_service.Framework
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {

        public override void OnException(HttpActionExecutedContext context)
        {
            ExceptionDetails ed = new ExceptionDetails();

            if (context.Exception is SecurityException)
            {
                ed.err_code = "SECURE_AREA";
                ed.message = "not enough privileges to access this resource.";
                ed.err_type = "Authorization Failed";

                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden)
                {
                    Content = new StringContent(ed.SerializeObject()),
                    ReasonPhrase = "Security Exception"
                });
            }
            else if (context.Exception is NotSupportedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotImplemented)
                {
                    Content = new StringContent("The action you are trying to perform is not supported/implemented."),
                    ReasonPhrase = "Not supported or implemented."
                });
            }
            else
            {
                ed.err_code = "ACTION_FAILURE";
                ed.message = context.Exception.Message;
                ed.err_type = "Application";

                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(ed.SerializeObject()),
                    ReasonPhrase = "Application Exception:" + context.Exception.Message,
                });

            }
        }

    }


}