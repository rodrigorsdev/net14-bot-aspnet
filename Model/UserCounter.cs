using MongoDB.Bson;

namespace SimpleBot.Model
{
    public class UserCounter
    {
        public UserCounter(string username)
        {
            Counter = 1;
            Username = username;
        }

        public ObjectId Id { get; private set; }
        public string Username { get; private set; }
        public int Counter { get; set; }
    }
}