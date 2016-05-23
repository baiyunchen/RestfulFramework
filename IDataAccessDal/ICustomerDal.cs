using System.Threading.Tasks;
using Models;

namespace IDataAccess
{
    public interface ICustomerDal
    {
        Task<bool> Login(string userName, string password);
        Task<Customer> GetCustomerByName(string name);
    }
}