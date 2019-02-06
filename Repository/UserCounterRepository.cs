using MongoDB.Driver;
using System.Configuration;

namespace SimpleBot.Repository
{
    public class UserCounterRepository
    {
        private MongoClient _client;
        private IMongoDatabase _db;
        private IMongoCollection<Model.UserCounter> _colletion;

        public UserCounterRepository()
        {
            _client = new MongoClient(ConfigurationManager.AppSettings["MongoDbUrl"]);
            _db = _client.GetDatabase(ConfigurationManager.AppSettings["MongoDbDatabase"]);
            _colletion = _db.GetCollection<Model.UserCounter>("userCounter");
        }

        public Model.UserCounter Get(string username)
        {
            var filter = Builders<Model.UserCounter>.Filter.Eq(a => a.Username, username);
            return _colletion.Find(filter).FirstOrDefault();
        }

        public void Save(Model.UserCounter model)
        {
            _colletion.InsertOne(model);
        }

        public void UpdateCounter(Model.UserCounter model)
        {
            var filter = Builders<Model.UserCounter>.Filter.Eq(a => a.Id, model.Id);
            var modelUpdated = Builders<Model.UserCounter>.Update.Set(a => a.Counter, model.Counter + 1);
            _colletion.UpdateOne(filter, modelUpdated);
        }
    }
}