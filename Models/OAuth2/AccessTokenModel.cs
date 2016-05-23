using System;

namespace Models
{
    public class AccessTokenModel
    {
        public Guid Id { get;set;}
        public DateTime ExpiresIn { get;set;}
        public int Appid { get; set; }
        public int Userid { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get;set;}
    }
}
