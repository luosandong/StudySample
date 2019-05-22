namespace JwtAuthSample
{
    public class JwtSettings
    {
        //token 颁发者
        public string Issuer{get;set;}
        //token可给哪个客户端使用
        public string Audience{get;set;}
        //安全密钥
        public string SecretKey{get;set;}
    }
}