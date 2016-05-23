namespace RestfulFramework.Models
{
    public class AccessTokenRequest
    {
        public string Appid { get; set; }
        public string Secret { get; set; }
        public string Code { get; set; }
        public string GrantType { get; set; }
    }
    public class RefreshTokenRequest
    {
        public string Appid { get; set; }
        public string RefreshToken { get; set; }
        public string GrantType { get; set; }
    }
    public class AccessTokenResponse
    {
        public string AccessToken { get; set; }
        public string ExpiresIn { get; set; }
        public string RefreshToken { get; set; }
        public string OpenId { get; set; }
    }
}