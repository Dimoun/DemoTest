using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignMode.Mode.BehavioralDesignPattern
{
    public interface IIterator<T>
    {
        bool HasNext();
        T Next();
    }
    public interface IAggregate<T>
    {
        public IIterator<T> CreateIterator();
    }
    public class ConcreteIterator<T> : IIterator<T>
    {
        private readonly ConcreteAggregate<T> _aggregate;
        private int _current = 0;
        public ConcreteIterator(ConcreteAggregate<T> aggregate)
        {
            _aggregate = aggregate;
        }
        public bool HasNext()
        {
            return _current < _aggregate.Count;
        }
        public T Next()
        {
            return _aggregate[_current++];
        }
    }
    public class ConcreteAggregate<T> : IAggregate<T>
    {
        private readonly List<T> _items = new List<T>();
        public void Add(T item)
        {
            _items.Add(item);
        }
        public int Count => _items.Count;
        public T this[int index] => _items[index];
        public IIterator<T> CreateIterator()
        { 
            return new ConcreteIterator<T>(this);
        }
    }
    public class IteratorMode
    {
        public void Create()
        {
            ConcreteAggregate<string> aggregate = new ConcreteAggregate<string>();
            
            aggregate.Add("A");
            aggregate.Add("B");
            aggregate.Add("C");

            IIterator<string> iterator = aggregate.CreateIterator();

            while(iterator.HasNext())
            {
                Console.WriteLine(iterator.Next());
            }
        }
    }
}
