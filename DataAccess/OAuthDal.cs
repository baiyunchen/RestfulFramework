using System;
using System.Threading.Tasks;
using IDataAccess;
using Models;
using MongoDB.Bson;
using MongoDB.Driver;
namespace DataAccess
{
    public class OAuthDal : IOAuthDal
    {
        private readonly IMongoCollection<CodeModel> codeCol = MongodbFactory.GetCollection<CodeModel>();

        public async Task<string> GenerateNewCode(string appId)
        {
            int expressSeconds = 5 * 60;
            CodeModel model = new CodeModel
            {
                Code = ObjectId.GenerateNewId().ToString(),
                ExpiresIn = expressSeconds,
                Appid = appId,
                Id = Guid.NewGuid()
            };
            await codeCol.Indexes.CreateOneAsync(new BsonDocumentIndexKeysDefinition<CodeModel>(model.ToBsonDocument()),
                new CreateIndexOptions { ExpireAfter = TimeSpan.FromSeconds(expressSeconds) });
            return model.Code;
        }

        public async Task<bool> CodeExist(string code, string appid)
        {
            var query = new QueryDocument { { "Appid", appid }, { "code", code } };
            var result = await codeCol.CountAsync(query);
            return result > 0;
        }

    }
}
