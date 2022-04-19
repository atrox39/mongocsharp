using System;
using MongoDB.Driver;
using MongoDB.Bson;

namespace mongocsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            MongoClient dbClient = new MongoClient("mongodb://localhost/");
            IMongoDatabase database = dbClient.GetDatabase("mongocsharp");
            IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>("testCollection");
            BsonDocument document = new BsonDocument("message", "hello");
            collection.InsertOne(document);
            var firstDocument = collection.Find(new BsonDocument()).FirstOrDefault();
            Console.WriteLine(firstDocument.ToString());
        }
    }
}
