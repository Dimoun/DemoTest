using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignMode.Mode.BehavioralDesignPattern
{
    public interface ICommand
    {
        public void Execute();
    }
    public class ConcreteCommandA : ICommand
    {
        private Receiver _receiver;

        public ConcreteCommandA(Receiver receiver)
        {
            _receiver = receiver;
        }
        public void Execute()
        {
            _receiver.Action();
        }
    }
    public class ConcreteCommandB : ICommand
    {
        private Receiver _receiver;

        public ConcreteCommandB(Receiver receiver)
        {
            _receiver = receiver;
        }
        public void Execute()
        {
            _receiver.Action();
        }
    }
    public class Receiver
    {
        public void Action()
        {

        }
    }
    public class Invoker
    {
       private ICommand _command;
       public void SetCommand(ICommand command)
        {
            _command = command;
        }
        public void ExecuteCommand()
        {
            _command.Execute();
        }
    }
    public class CommandMode
    {
        public void Create()
        {
            ICommand commandA = new ConcreteCommandA(new Receiver());
            ICommand commandB = new ConcreteCommandA(new Receiver());

            Invoker invoker = new Invoker();
            invoker.SetCommand(commandA);
            invoker.ExecuteCommand();
        }
    }
}
