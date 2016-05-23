using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using IDataAccess;
using Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace DataAccess
{
    public class ApplicationDal : IApplicationDal
    {
        private readonly IMongoCollection<Application> col = MongodbFactory.GetCollection<Application>();
        public async Task<bool> Exist(string appId)
        {
            var query = new QueryDocument { { "AppId", appId } };
            var result =await col.CountAsync(query);
            return result > 0;
        }

        public async Task<Application> GetApplicationByAppId(string appid)
        {
            var filter = Builders<Application>.Filter.Eq("AppId", appid);
            var result = await col.Find(filter).ToListAsync();
            return result.FirstOrDefault();
        }
    }
}
