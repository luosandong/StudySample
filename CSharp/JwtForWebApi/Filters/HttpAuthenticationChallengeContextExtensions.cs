using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http.Filters;

namespace ExOrg.Filters
{
    /// <summary>
    /// 身份验证Challenge上下文扩展方法类
    /// </summary>
    public static class HttpAuthenticationChallengeContextExtensions
    {
        public static void ChallengeWith(this HttpAuthenticationChallengeContext context, string scheme)
        {
            ChallengeWith(context, new AuthenticationHeaderValue(scheme));
        }
        public static void ChallengeWith(this HttpAuthenticationChallengeContext context, string scheme, string parameter)
        {
            // 第二个参数的作用是根据传进来的scheme也就是"Bearer"和parameter这里为null，创建一个验证头，和前端传过来的token是一样的
            ChallengeWith(context, new AuthenticationHeaderValue(scheme, parameter));
        }
        private static void ChallengeWith(HttpAuthenticationChallengeContext context, AuthenticationHeaderValue challenge)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            context.Result = new CheckUnauthorizedResult(challenge, context.Result);
        }
       
    }
}