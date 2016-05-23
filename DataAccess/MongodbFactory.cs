using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace DataAccess
{
    public static class MongodbFactory
    {
        public static string GetConnectionStr()
        {
            return "mongodb://jax:1q2w3e4R@192.168.231.128:27017/APIFreamWork";
        }

        public static MongoClient GetMongoClient(string connection)
        {
            return new MongoClient(connection);
        }

        public static MongoClient GetMongoClient()
        {
            return GetMongoClient(GetConnectionStr());
        }

        public static IMongoDatabase GetMongoDatabase(string dbname = "APIFreamWork")
        {
            return GetMongoClient().GetDatabase(dbname);
        }

        public static IMongoCollection<T> GetCollection<T>()
        {
            return GetMongoDatabase().GetCollection<T>(typeof(T).Name);
        }
    }
}
