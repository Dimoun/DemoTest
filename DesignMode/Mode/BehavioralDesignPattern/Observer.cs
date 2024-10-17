using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignMode.Mode.BehavioralDesignPattern
{
    public interface IObserver
    {
        void Update(string message);
    }
    public class ObserverA : IObserver
    {
        public void Update(string message)
        {
            Console.WriteLine("Observer A received message: " + message);
        }

    }
    public class ObserverB : IObserver
    {
        public void Update(string message)
        {
            Console.WriteLine("Observer B received message: " + message);
        }

    }

    public interface ISubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify(string message);
    }
    public class Subject : ISubject
    {
        private readonly List<IObserver> list = new List<IObserver>();
        public void Attach(IObserver observer)
        {
            list.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            list.Remove(observer);
        }

        public void Notify(string message)
        {
            foreach(var item in list)
            {
                item.Update(message);
            }
        }
        // 示例方法，触发通知
        public void ChangeState(string newState)
        {
            Console.WriteLine("Subject State Changed: " + newState);
            Notify(newState);
        }
    }
    public class ObserverMode
    {
        public void Create()
        {
            Subject subject = new Subject();

            ObserverA observerA = new ObserverA();
            ObserverB observerB = new ObserverB();

            subject.Attach(observerA);
            subject.Attach(observerB);

            subject.ChangeState("New State 1");
            subject.ChangeState("New State 2");

            subject.Detach(observerA);
            subject.ChangeState("New State 3");
        }
    }
}
