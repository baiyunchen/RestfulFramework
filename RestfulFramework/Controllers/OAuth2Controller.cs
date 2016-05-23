using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Mvc;
using DataAccess;
using DataAccessFactory;
using IDataAccess;
using Models;
using RestfulFramework.Models;

namespace RestfulFramework.Controllers
{
    public class OAuth2Controller : Controller
    {
        private IApplicationDal applicationDal = DALFactory.ApplicationDal();
        private ICustomerDal customerDal = DALFactory.CustomerDal();
        private IOAuthDal oAuthDal = DALFactory.OAuthDal();
        // GET: OAuth2
        public async Task<ActionResult> Authorize(CodeRequest request)
        {
            var validateResult = await ValidateAppSetting(request);
            if (validateResult.Success)
                return View();
            return Error(validateResult.Description);
        }
        [HttpPost, ActionName("Authorize")]
        public async Task<ActionResult> AuthorizePost(CodeRequest request)
        {
            /*
             *1.判断granttype是否正确，验证APPID是否存在
             *2.验证redirecturl是否是正确
             *3.验证用户名密码是否正确
             *4.生成code,存入db
             *5.跳转到用户页面
             */
            var validateResult = await ValidateAppSetting(request);
            if (!validateResult.Success)
                return Error(validateResult.Description);
            var userValidateResult = await customerDal.Login(request.username, request.password);
            if (!userValidateResult)
            {
                ModelState.AddModelError("","用户名或密码错误");
                return View();
            }
            var code = await oAuthDal.GenerateNewCode(request.appid);
            return Redirect(string.Format(request.redirecturl + "?code={0}&state={1}",code,request.state));
        }

        public async Task<ReturnMessage<string>> ValidateAppSetting(CodeRequest request)
        {
            var application = await Task.Run(() =>
            {
                var app = applicationDal.GetApplicationByAppId(request.appid);
                return app;
            });
            if (application == null)
            {
                return ReturnMessage<string>.ErrorMsg("不合法的AppID");
            }
            if (HttpContext.Request.UrlReferrer == null || string.IsNullOrEmpty(HttpContext.Request.UrlReferrer.Host))
            {
                return ReturnMessage<string>.ErrorMsg("非法的请求");
            }
            var host = HttpContext.Request.UrlReferrer.Host.ToString();
            var regex = "^(\\w+(\\.)){0,9}" + application.Host + "$";
            var hostValidate = Regex.IsMatch(host, regex);
            if (!hostValidate)
                return ReturnMessage<string>.ErrorMsg("请在APP设置的域名内使用OAuth");
            var redircturlValidate = Regex.IsMatch(request.redirecturl, regex);
            if (!redircturlValidate)
                return ReturnMessage<string>.ErrorMsg("redirect url不合法");
            return ReturnMessage<string>.SuccessMsg("");
        }
        public ActionResult Error(string msg)
        {
            ViewData["msg"] = msg;
            return View("Erron");
        }
    }
}