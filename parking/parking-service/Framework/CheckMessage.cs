using parking_service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace parking_service.Framework
{
    /// <summary>
    /// Checks every request
    /// </summary>
    public class CheckRequest : DelegatingHandler
    {


        public CheckRequest()
        {
        }

        
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            
            // Ignoring preflight (OPTIONS) call for token check. Returning HTTP200.
            if (request.Method == HttpMethod.Options)
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                var tsc = new TaskCompletionSource<HttpResponseMessage>();

                tsc.SetResult(response);
                return await tsc.Task;
            }

            //OTHER CHECKS TO BE DONE HERE - INCLUDING BAD MESSAGES

            HttpResponseMessage resp = await base.SendAsync(request, cancellationToken);
            return resp;
        }



    }
}