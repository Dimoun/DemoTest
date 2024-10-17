using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignMode.Mode.BehavioralDesignPattern.Strategy
{
    public interface IStrategy
    {
        int Execute(int a, int b);
    }
    public class ConcreteStrategyAdd : IStrategy
    {
        public int Execute(int a,int b)
        {
            return a + b;
        }
    }
    public class ConcreteStrategySubtract : IStrategy
    {
        public int Execute(int a, int b)
        {
            return a - b;
        }
    }
    public class Context
    {
        private IStrategy _strategy;

        public void SetStrategy(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public int ExecuteStrategy(int a, int b)
        {
            return _strategy.Execute(a, b);
        }
    }

    public class StrategyMode
    {
        public void Create()
        {
            Context context = new Context();
            context.SetStrategy(new ConcreteStrategyAdd());
            var addRes = context.ExecuteStrategy(5, 10);

            context.SetStrategy(new ConcreteStrategySubtract());
            var subRes = context.ExecuteStrategy(5, 10);

        }
    }

}
