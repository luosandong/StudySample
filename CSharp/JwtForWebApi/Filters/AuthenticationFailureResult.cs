using ExOrg.Models.ViewModels;
using ExOrg.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ExOrg.Filters
{
    public class AuthenticationFailureResult : IHttpActionResult
    {
        public string _FailureReason { get; }
        public HttpRequestMessage _Request { get; }
        public AuthenticationFailureResult(string FailureReason, HttpRequestMessage request)
        {
            _FailureReason = FailureReason;
            _Request = request;
        }
        HttpResponseMessage HandleResponseMessage()
        {
            HttpResponseMessage response = new ResultMessage {  StatusCode =  Models.MessageCodeEnum.AuthenticationFailure,  Data = "",  Info = "234" }.ToJson().ToResponseJson();
            response.StatusCode = HttpStatusCode.Unauthorized;
            response.RequestMessage = _Request;
            response.ReasonPhrase = _FailureReason;
            return response;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(HandleResponseMessage());
        }
    }
}