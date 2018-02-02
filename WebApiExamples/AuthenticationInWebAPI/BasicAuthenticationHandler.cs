using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace AuthenticationInWebAPI
{
    public class BasicAuthenticationHandler : DelegatingHandler
    {
        private readonly IAuthenticationService _service;
        public BasicAuthenticationHandler(IAuthenticationService service)
        {
            _service = service;
        }
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //When a request arrives to the handler, it analyzes the header by searching for the Authentication value.
            AuthenticationHeaderValue authHeader = request.Headers.Authorization;
            if (authHeader == null || authHeader.Scheme != "Basic")
            {
                return Unauthorized(request);
            }

            //If the Authentication header is present, it decodes its value from Base64 and extracts the value of the username and password
            string encodedCredentials = authHeader.Parameter;
            byte[] credentialBytes = Convert.FromBase64String(encodedCredentials);
            string[] credentials = Encoding.ASCII.GetString(credentialBytes).Split(':');

            //Now in credentials we have the two strings, username and password. We can now use a service(something that uses a database or other storage) to verify if the credentials are correct
            if (!_service.Authenticate(credentials[0], credentials[1]))
            {
                return Unauthorized(request);
            }

            //The last part of the method is meant to build the Principal and Identity information that needs to be used in conjunction with the ASP.NET membership.
            string[] roles = null; // TODO
            IIdentity identity = new GenericIdentity(credentials[0], "Basic");
            IPrincipal user = new GenericPrincipal(identity, roles);
            HttpContext.Current.User = user;

            return base.SendAsync(request, cancellationToken);
        }
        private Task<HttpResponseMessage> Unauthorized(HttpRequestMessage request)
        {
            var response = request.CreateResponse(HttpStatusCode.Unauthorized);
            response.Headers.Add("WWW-Authenticate", "Basic");
            TaskCompletionSource<HttpResponseMessage> task = new TaskCompletionSource<HttpResponseMessage>();
            task.SetResult(response);
            return task.Task;
        }
    }
    public class AuthenticationService : IAuthenticationService
    {
        public bool Authenticate(string user, string password)
        {
            //Do database calls and check if
            //the user and password matches.
            return true;
        }
    }
}