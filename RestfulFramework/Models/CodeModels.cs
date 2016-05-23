namespace RestfulFramework.Models
{
    public class CodeRequest
    {
        public string response_type { get; set; }
        public string redirecturl { get; set; }
        public string state { get; set; }
        /// <summary>
        /// base 64加密int类型的id后返回
        /// </summary>
        public string appid { get; set; }
        /// <summary>
        /// 固定填写code
        /// </summary>
        public string grantType { get;set;}
        public string username { get; set; }
        public string password { get; set; }
    }

    public class CodeResponse
    {
        public string code { get; set; }
        public string state { get;set;}
    }
}