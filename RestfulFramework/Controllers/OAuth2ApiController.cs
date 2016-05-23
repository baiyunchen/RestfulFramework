using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using RestfulFramework.Models;

namespace RestfulFramework.Controllers
{
    [RoutePrefix("api/oauth2")]
    public class OAuth2ApiController : ApiController
    {
        //1.获取accessToken
        [Route("authorize"),HttpGet]
        public async Task<AccessTokenResponse> GetCode(AccessTokenRequest request)
        {
            AccessTokenResponse response = new AccessTokenResponse();
           /*
            * 1.验证code
            * 2.验证appid和appSecret
            * 3.生成AccessToken
            * 4.生成RefreshToken
            * 4.返回参数
            */

           return response;
        }
        
    }
}
