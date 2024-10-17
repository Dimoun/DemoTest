using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignMode.Mode.BehavioralDesignPattern
{
    // 状态接口
    public interface IState
    {
        void Handle(Context context);
    }

    // 上下文类
    public class Context
    {
        private IState _state;

        public Context(IState state)
        {
            TransitionTo(state); // 初始状态
        }

        public void TransitionTo(IState state)
        {
            Console.WriteLine($"Transition to {state.GetType().Name}");
            _state = state;
            _state.Handle(this); // 处理当前状态
        }

        public void Request()
        {
            _state.Handle(this);
        }
    }

    // 具体状态A
    public class ConcreteStateA : IState
    {
        public void Handle(Context context)
        {
            Console.WriteLine("Handling in State A");
            //context.TransitionTo(new ConcreteStateB()); // 转换到状态B
        }
    }

    // 具体状态B
    public class ConcreteStateB : IState
    {
        public void Handle(Context context)
        {
            Console.WriteLine("Handling in State B");
            //context.TransitionTo(new ConcreteStateA()); // 转换到状态A
        }
    }

    public class StateMode
    {
        public void Create()
        {
            Context context = new Context(new ConcreteStateA());

            context.Request();
        }
    }
}
