using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace WEBAPIMVC.ErrorLog
{
    public class LogCustomExceptionFilterAPI : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            string exceptionMessage = string.Empty;
            if (actionExecutedContext.Exception.InnerException == null)
            {
                exceptionMessage = actionExecutedContext.Exception.Message;
            }
            else
            {
                exceptionMessage = actionExecutedContext.Exception.InnerException.Message;
            }
            //We can log this exception message to the file or database.  
            var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent("An unhandled exception was thrown by service."),  
                    ReasonPhrase = "Internal Server Error.Please Contact your Administrator."
            };

            string Message = "Date :" + DateTime.Now.ToString() + 
                                 " , Error Message : " + exceptionMessage;

            //You can also save this in a dabase
            File.AppendAllText(HttpContext.Current.Server.MapPath("~/ErrorLog/LogApi.txt"), Message);
            File.AppendAllText(HttpContext.Current.Server.MapPath("~/ErrorLog/LogApi.txt"), Environment.NewLine);

            actionExecutedContext.Response = response;
          
        }
    }
}