using System;
using MongoDB.Driver;
using MongoDB.Bson;

namespace ConsoleAppMongo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var cliente = new MongoClient("mongodb://localhost:27017");
            var db = cliente.GetDatabase("net16");
            var col = db.GetCollection<BsonDocument>("col01");

            var doc = new BsonDocument();
            col.InsertOne(doc);


            var filtro = new BsonDocument()
            {
                {"id",1 },
                {"nome","al" }
            };

            var doc2 = new BsonDocument
            {
                {"nome","alan" },
                {"idade",30M },
                {"empresas", new BsonArray()
                    {
                        "MS","FIAP"
                    }
                }
            };


            var doc3 = BsonDocument.Parse("{id:1}");




            col.Find(filtro);


        }
    }
}
