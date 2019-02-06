using MongoDB.Driver;
using System.Configuration;

namespace SimpleBot.Repository
{
    public class MessageRepository
    {
        private MongoClient _client;
        private IMongoDatabase _db;
        private IMongoCollection<Model.Message> _colletion;

        public MessageRepository( )
        {
            _client = new MongoClient(ConfigurationManager.AppSettings["MongoDbUrl"]);
            _db = _client.GetDatabase(ConfigurationManager.AppSettings["MongoDbDatabase"]);
            _colletion = _db.GetCollection<Model.Message>("message");
        }

        public void Save(Model.Message message)
        {
            _colletion.InsertOne(message);
        }
    }
}