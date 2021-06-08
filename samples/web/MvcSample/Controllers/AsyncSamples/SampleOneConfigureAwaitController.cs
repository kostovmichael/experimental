

namespace MvcAndWebApiDotNetFive.Controllers.AsyncSamples
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    using MvcAndWebApiDotNetFive.Models;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;


    public class SampleOneConfigureAwaitController : Controller
    {
        private const string GitHubApiHostUrl = "https://api.github.com/";

        private readonly ILogger<SampleOneController> _logger;

        private readonly IHttpClientFactory _clientFactory;
        public SampleOneConfigureAwaitController(IHttpClientFactory clientFactory, ILogger<SampleOneController> logger)
        {
            this._clientFactory = clientFactory;
            this._logger = logger;
        }


        [Route("SampleConfigureAwaitController/GetDataAsyncWithConfigureAwaitFalse")]
        public async Task<ActionResult> GetDataAsyncWithConfigureAwaitFalse()
        {

            var client = _clientFactory.CreateClient();
            var request = GetHttpRequestMessage_GitHubApi();
            HttpResponseMessage response = await client.SendAsync(request)
                .ConfigureAwait(false);

            var responseModel = new ResponseModel();

            if (response.IsSuccessStatusCode)
            {
                responseModel.Success = true;
                responseModel.Message = await response.Content.ReadAsStringAsync()
                .ConfigureAwait(false);

            }
            else
            {
                responseModel.Message = "Failed to load data from API";
            }

            return Json(responseModel);

        }

        /// <summary>
        /// This is used solely for demo purposes
        /// </summary>
        /// <returns></returns>
        private HttpRequestMessage GetHttpRequestMessage_GitHubApi()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, GitHubApiHostUrl);
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("User-Agent", "HttpClientFactory-Sample");
            return request;

        }


    }
}
