using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignMode.Mode.BehavioralDesignPattern
{
    public interface IChatMediator
    {
        void SendMessage(string message, Colleague colleague);
        void AddColleague(Colleague colleague);
    }
    public class ChatMediator : IChatMediator
    {
        private List<Colleague> _colleagues = new List<Colleague>();

        public void SendMessage(string message, Colleague colleague)
        {
            foreach (var c in _colleagues)
            {
                // 不发送给发送者本人
                if (c != colleague)
                {
                    c.ReceiveMessage(message);
                }
            }
        }
        public void AddColleague(Colleague colleague)
        {
            _colleagues.Add(colleague);
        }
    }

    public abstract class Colleague
    {
        protected IChatMediator _mediator;

        public Colleague(IChatMediator mediator)
        {
            _mediator = mediator;
        }

        public abstract void SendMessage(string message);
        public abstract void ReceiveMessage(string message);
    }

    public class User : Colleague
    {
        public string Name { get; }

        public User(string name, IChatMediator mediator) : base(mediator)
        {
            Name = name;
            mediator.AddColleague(this);
        }

        public override void SendMessage(string message)
        {
            System.Console.WriteLine($"{Name}发送消息: {message}");
            _mediator.SendMessage(message, this);
        }

        public override void ReceiveMessage(string message)
        {
            System.Console.WriteLine($"{Name}收到消息: {message}");
        }
    }
    public class MediatorMode
    {
        public void Create()
        {
            ChatMediator mediator = new ChatMediator();

            User user1 = new User("Alice", mediator);
            User user2 = new User("Bob", mediator);
            User user3 = new User("Charlie", mediator);

            user1.SendMessage("Hello, everyone!");
            user2.SendMessage("Hi Alice!");
            user3.SendMessage("Hey there!");
        }
    }
}
