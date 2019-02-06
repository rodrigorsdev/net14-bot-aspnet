using MongoDB.Bson;
using System;

namespace SimpleBot.Model
{
    public class Message
    {
        public Message(
            string user,
            string text)
        {
            User = user;
            Text = text;
            Date = DateTime.Now.ToString("D");
        }

        public ObjectId Id { get; private set; }
        public string Date { get; private set; }
        public string User { get; private set; }
        public string Text { get; private set; }
    }
}