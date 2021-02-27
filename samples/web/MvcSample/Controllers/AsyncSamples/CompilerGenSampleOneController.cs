// ReSharper disable All
namespace MvcAndWebApiDotNetFive.Controllers.AsyncSamples
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    using MvcAndWebApiDotNetFive.Models;

    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Net.Http;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;

    public class CompilerGenSampleOneController : Controller
    {
        [CompilerGenerated]
        private sealed class CompilerGenerated_GetDataAsync : IAsyncStateMachine
        {
            public int currentState;

            public AsyncTaskMethodBuilder<ActionResult> taskBuilder;

            public CompilerGenSampleOneController sampleOneControllerInstance;

            private HttpClient httpClient;

            private HttpRequestMessage httpRequestMessage;

            private HttpResponseMessage responseMessage;

            private CompilerGenerated_ResponseModel responseModel;

            private HttpResponseMessage httpResponseMessage_2;

            private CompilerGenerated_ResponseModel responseModel_2;

            private string resultValue;

            private TaskAwaiter<HttpResponseMessage> theTaskAwaiter;

            private TaskAwaiter<string> stringTaskAwaiter;

            private void MoveNext()
            {
                int num = currentState;
                ActionResult result;
                try
                {
                    TaskAwaiter<string> awaiter;
                    TaskAwaiter<HttpResponseMessage> awaiter2;
                    if (num != 0)
                    {
                        if (num == 1)
                        {
                            awaiter = stringTaskAwaiter;
                            stringTaskAwaiter = default(TaskAwaiter<string>);
                            num = (currentState = -1);
                            goto IL_0157;
                        }
                        httpClient = new HttpClient();
                        httpRequestMessage = sampleOneControllerInstance.GetHttpRequestMessage_GitHubApi();
                        awaiter2 = httpClient.SendAsync(httpRequestMessage).GetAwaiter();
                        if (!awaiter2.IsCompleted)
                        {
                            num = (currentState = 0);
                            theTaskAwaiter = awaiter2;
                            CompilerGenerated_GetDataAsync stateMachine = this;
                            taskBuilder.AwaitUnsafeOnCompleted(ref awaiter2, ref stateMachine);
                            return;
                        }
                    }
                    else
                    {
                        awaiter2 = theTaskAwaiter;
                        theTaskAwaiter = default(TaskAwaiter<HttpResponseMessage>);
                        num = (currentState = -1);
                    }
                    httpResponseMessage_2 = awaiter2.GetResult();
                    responseMessage = httpResponseMessage_2;
                    httpResponseMessage_2 = null;
                    responseModel = new CompilerGenerated_ResponseModel();
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        responseModel.Success = true;
                        responseModel_2 = responseModel;
                        awaiter = responseMessage.Content.ReadAsStringAsync().GetAwaiter();
                        if (!awaiter.IsCompleted)
                        {
                            num = (currentState = 1);
                            stringTaskAwaiter = awaiter;
                            CompilerGenerated_GetDataAsync stateMachine = this;
                            taskBuilder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
                            return;
                        }
                        goto IL_0157;
                    }
                    responseModel.Message = "Failed to load data from API";
                    goto IL_019a;
                    IL_0157:
                    resultValue = awaiter.GetResult();
                    responseModel_2.Message = resultValue;
                    responseModel_2 = null;
                    resultValue = null;
                    goto IL_019a;
                    IL_019a:
                    result = (ActionResult)this.sampleOneControllerInstance.Json((object)this.responseModel);
                }
                catch (Exception exception)
                {
                    currentState = -2;
                    httpClient = null;
                    httpRequestMessage = null;
                    responseMessage = null;
                    responseModel = null;
                    taskBuilder.SetException(exception);
                    return;
                }
                currentState = -2;
                httpClient = null;
                httpRequestMessage = null;
                responseMessage = null;
                responseModel = null;
                taskBuilder.SetResult(result);
            }

            void IAsyncStateMachine.MoveNext()
            {
                //ILSpy generated this explicit interface implementation from .override directive in MoveNext
                this.MoveNext();
            }

            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine)
            {
            }

            void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
            {
                //ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
                this.SetStateMachine(stateMachine);
            }
        }

        private const string GitHubApiHostUrl = "https://api.github.com/";

        //[AsyncStateMachine(typeof(CompilerGenerated_GetDataAsync))]
        //[DebuggerStepThrough]

        [Route("CompilerGenSampleOne/GetDataAsync")]
        public Task<ActionResult> GetDataAsync()
        {
            CompilerGenerated_GetDataAsync stateMachine = new CompilerGenerated_GetDataAsync();
            stateMachine.taskBuilder = AsyncTaskMethodBuilder<ActionResult>.Create();
            stateMachine.sampleOneControllerInstance = this;
            stateMachine.currentState = -1;
            stateMachine.taskBuilder.Start(ref stateMachine);
            return stateMachine.taskBuilder.Task;
        }

        private HttpRequestMessage GetHttpRequestMessage_GitHubApi()
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "https://api.github.com/");
            httpRequestMessage.Headers.Add("Accept", "application/json");
            httpRequestMessage.Headers.Add("User-Agent", "HttpClientFactory-Sample");
            return httpRequestMessage;
        }
    }

    public class CompilerGenerated_ResponseModel
    {
        [CompilerGenerated]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool _success_k__BackingField;

        [CompilerGenerated]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _message_k__BackingField;

        [CompilerGenerated]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private IList<string> _messages_k__BackingField;

        public bool Success
        {
            [CompilerGenerated]
            get
            {
                return _success_k__BackingField;
            }
            [CompilerGenerated]
            set
            {
                _success_k__BackingField = value;
            }
        }

        public string Message
        {
            [CompilerGenerated]
            get
            {
                return _message_k__BackingField;
            }
            [CompilerGenerated]
            set
            {
                _message_k__BackingField = value;
            }
        }

        public IList<string> Messages
        {
            [CompilerGenerated]
            get
            {
                return _messages_k__BackingField;
            }
            [CompilerGenerated]
            set
            {
                _messages_k__BackingField = value;
            }
        }
    }

}
