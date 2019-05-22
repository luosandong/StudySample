using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;

namespace ExOrg.Filters
{
    public class ApiAuthenticationAttribute : Attribute, IAuthenticationFilter
    {
        public bool AllowMultiple => false;
        public string Realm { get; set; }

        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            var request = context.Request;
            /*
                var accessToken = request.Headers.FirstOrDefault(h => h.Key.ToLower().Equals("accesstoken"));
                if (accessToken.Key==null)
                {
                    context.ErrorResult = new AuthenticationFailureResult("Missing  AccessToken Header", request);
                    return;
                }
                if (string.IsNullOrWhiteSpace(accessToken.Value.FirstOrDefault()))
                {
                    context.ErrorResult = new AuthenticationFailureResult("Missing Jwt Token", request);
                    return;
                }
                var token = accessToken.Value.First();
            */
            var authorization = request.Headers.Authorization; // 获取请求的token对象
            if (authorization == null || authorization.Scheme != "Bearer")
            {
                context.ErrorResult = new AuthenticationFailureResult("Unkonw Authorization Scheme", request);
                return;
            }
            if (string.IsNullOrEmpty(authorization.Parameter))
            {
                // 给ErrorResult赋值需要一个类实现了IHttpActionResult接口
                // 此类声明在AuthenticationFailureResult.cs文件中，此文件用来处理错误信息。
                context.ErrorResult = new AuthenticationFailureResult("Missing Jwt Token", request);
                return;
            }
            var token = authorization.Parameter; // 获取token字符串
            
            var principal = await AuthenticateJwtToken(token); // 调用此方法，根据token生成对应的"身份证持有人"
            if (principal == null)
            {
                context.ErrorResult = new AuthenticationFailureResult("Invalid token", request);
            }
            else
            {
                context.Principal = principal; // 设置身份验证的主体
            }
            // 此法调用完毕后，会调用ChallengeAsync方法，从而来完成WWW-Authenticate验证
        }
        private Task<IPrincipal> AuthenticateJwtToken(string token)
        {
            string userName;
            if (ValidateToken(token, out userName))
            {
                // 这里就是验证成功后要做的逻辑，也就是处理WWW-Authenticate验证
                var info = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "lsd")
                }; 
                var infos = new ClaimsIdentity(info, "Jwt");
                // 将上面的身份证放在ClaimsPrincipal里面，相当于把身份证给持有人
                IPrincipal user = new ClaimsPrincipal(infos);
                return Task.FromResult(user);
            }
            return Task.FromResult<IPrincipal>(null);
        }
        private bool ValidateToken(string token, out string userName)
        {
            userName = null;
            var simplePrinciple = TokenHelper.GetPrincipal(token); // 调用自定义的GetPrincipal获取Token的信息对象
            var identity = simplePrinciple?.Identity as ClaimsIdentity; // 获取主声明标识
            if (identity == null) return false;
            if (!identity.IsAuthenticated) return false;
            var userNameClaim = identity.FindFirst(ClaimTypes.Name); // 获取声明类型是ClaimTypes.Name的第一个声明
            userName = userNameClaim?.Value; // 获取声明的名字，也就是用户名
            if (string.IsNullOrEmpty(userName)) return false;
            return true;
          
        }
        #region IAuthenticationFilter 接口方法
        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            //此方法在AuthenticateAsync方法调用完成之后自动调用
            string parameter = null;
            if (!string.IsNullOrEmpty(Realm))
            {
                parameter = "realm=\"" + Realm + "\"";
            }
            context.ChallengeWith("Bearer", parameter); // 验证token的Schema是不是Bearer 
            return Task.FromResult("");
        }
     
        #endregion




    }
}