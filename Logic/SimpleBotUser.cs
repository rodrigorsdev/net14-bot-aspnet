using SimpleBot.Repository;

namespace SimpleBot.Logic
{
    public class SimpleBotUser
    {
        private readonly MessageRepository _messageRepository;
        private readonly UserCounterRepository _userCounterRepository;

        public SimpleBotUser()
        {
            _messageRepository = new MessageRepository();
            _userCounterRepository = new UserCounterRepository();
        }

        public string Reply(SimpleMessage message)
        {
            _messageRepository.Save(new Model.Message(message.User, message.Text));

            var userCounter = _userCounterRepository.Get(message.User);

            if (userCounter == null)
                _userCounterRepository.Save(new Model.UserCounter(message.User));
            else
                _userCounterRepository.UpdateCounter(userCounter);

            return $"{message.User} disse '{message.Text}";
        }

    }
}