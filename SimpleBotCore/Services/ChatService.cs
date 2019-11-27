using MongoDB.Driver;
using SimpleBotCore.Interface;
using SimpleBotCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBotCore.Services
{

    public class ChatService
    {

        private readonly IMongoCollection<Chat> _chatsmongo;

        public ChatService(IDatabaseSettings settings)
        {
            var cliente = new MongoClient(settings.ConnectionString);
            var database = cliente.GetDatabase(settings.DatabaseName);

            _chatsmongo = database.GetCollection<Chat>("col01");
        }

        public Chat Insert(Chat chat)
        {
            _chatsmongo.InsertOne(chat);
            return chat;
        }
    }
    
            

    
}
