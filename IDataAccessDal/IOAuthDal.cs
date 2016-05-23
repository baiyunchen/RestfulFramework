using System.Threading.Tasks;

namespace IDataAccess
{
    public interface IOAuthDal
    {
        Task<string> GenerateNewCode(string appid);
    }
}
