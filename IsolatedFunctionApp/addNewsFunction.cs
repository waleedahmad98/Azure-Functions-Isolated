using System.Collections.Generic;
using System.Net;
using IsolatedFunctionApp.Data;
using IsolatedFunctionApp.Model;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace IsolatedFunctionApp
{
    public class addNewsFunction
    {
        private readonly ILogger _logger;
        private readonly IData _Data;

        public addNewsFunction(ILoggerFactory loggerFactory, IData data)
        {
            _logger = loggerFactory.CreateLogger<addNewsFunction>();
            _Data = data;
        }

        [Function("addNewsFunction")]
        public async Task<HttpResponseData> RunAsync([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            var request = await req.ReadFromJsonAsync<NewsModel>(); // raw json

            //var request = new StreamReader(req.Body).ReadToEndAsync();
            _Data.addNews(request.title, request.content);
            return response;
        }
    }
}
