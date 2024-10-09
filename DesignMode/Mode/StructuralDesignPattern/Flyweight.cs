using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignMode.Mode.StructuralDesignPattern
{
    public interface Flyweight
    {
        public void Operation(int extrinsicState);
    }
    public class ConcreteFlyweight : Flyweight
    {
        private string intrinsicState;
        public ConcreteFlyweight(string intrinsicState)
        {
            this.intrinsicState = intrinsicState;
        }

        public void Operation(int extrinsicState)
        {
            Console.WriteLine("IntrinsicState: " + intrinsicState);
            Console.WriteLine("ExtrinsicState: " + extrinsicState);
        }
    }
    public class FlyweightFactory
    {
        private Dictionary<string, Flyweight> _flyweightList = new Dictionary<string, Flyweight>();

        public Flyweight GetFlyweight(string key)
        {
            if (!_flyweightList.ContainsKey(key))
            {
                _flyweightList.Add(key,new ConcreteFlyweight(key));
            }
            return _flyweightList[key];
        }
    }

    public class FlyweightMode : Mode
    {
        public void Create()
        {
            Flyweight flyweight1 = new ConcreteFlyweight("A");
            Flyweight flyweight2 = new ConcreteFlyweight("A");
            Flyweight flyweight3 = new ConcreteFlyweight("C");

            flyweight1.Operation(10);
            flyweight2.Operation(20);
            flyweight3.Operation(30);

        }
    }
    
}
