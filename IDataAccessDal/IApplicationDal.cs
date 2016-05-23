using System.Threading.Tasks;
using Models;

namespace IDataAccess
{
    public interface IApplicationDal
    {
        Task<bool> Exist(string appId);
        Task<Application> GetApplicationByAppId(string appid);
    }
}
