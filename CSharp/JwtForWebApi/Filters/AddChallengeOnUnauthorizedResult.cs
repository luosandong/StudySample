using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ExOrg.Filters
{
    public class CheckUnauthorizedResult : IHttpActionResult
    {
        public AuthenticationHeaderValue _Challenge { get; }
        public IHttpActionResult _InnerResult { get; }
        public CheckUnauthorizedResult(AuthenticationHeaderValue challenge, IHttpActionResult innerResult)
        {
            _Challenge = challenge;
            _InnerResult = innerResult;
        }
        #region 接口方法
        public async Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            // 这里讲schemee也就是"Bearer"生成后的response返回给浏览器去做判断，如果浏览器请求的Authenticate中含有含有名为"Bearer"的scheme会返回200状态码否则返回401状态码
            HttpResponseMessage response = await _InnerResult.ExecuteAsync(cancellationToken);
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                HttpContent contet = new StringContent("Unauthorized");
                response.RequestMessage = new HttpRequestMessage() { Content = contet };
                if (response.Headers.WwwAuthenticate.All(h => h.Scheme != _Challenge.Scheme))
                {
                    response.Headers.WwwAuthenticate.Add(_Challenge);
                }
            }
            return response;
        }
        #endregion

    }
}