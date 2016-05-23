using System.Linq;
using System.Threading.Tasks;
using IDataAccess;
using Models;
using MongoDB.Driver;

namespace DataAccess
{
    public class CustomerDal : ICustomerDal
    {
        private readonly IMongoCollection<Customer> col = MongodbFactory.GetCollection<Customer>();
        public async Task<bool> Login(string userName, string password)
        {
            var query = new QueryDocument { { "Name", userName },{"Password",password} };
            var result = await col.CountAsync(query);
            return result > 0;
        }

        public async Task<Customer> GetCustomerByName(string name)
        {
            var filter = Builders<Customer>.Filter.Eq("Name", name);
            var result = await col.Find(filter).ToListAsync();
            return result.FirstOrDefault();
        }
    }
}
