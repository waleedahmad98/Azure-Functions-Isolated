using System.Collections.Generic;
using System.Net;
using IsolatedFunctionApp.Data;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace IsolatedFunctionApp
{
    public class getNewsFunction
    {
        private readonly ILogger _logger;
        private readonly IData _Data;

        public getNewsFunction(ILoggerFactory loggerFactory, IData Data)
        {
            _logger = loggerFactory.CreateLogger<getNewsFunction>();
            _Data = Data;
        }

        [Function("getNewsFunction")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.WriteAsJsonAsync(_Data.getNewsList());

            return response;
        }
    }
}
